using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO.Ports;

namespace test_image_rec
{
    public partial class Main : Form
    {
        private FilterInfoCollection _videoCaptureDevices; // Список видео девайсов
        private VideoCaptureDevice _finalVideo; // Выбранное видео устройство

        private List<string> _standartName = new List<string>(); // Имена стандартов
        private List<List<string>> _standart = new List<List<string>>(); // Имена фотографий стандартов
        private List<List<int[]>> _gistograms = new List<List<int[]>>(); // Гистограммы изображений

        private SerialPort _arduinoPort; // Порт для соединения с роботом (ARDUINO)
        private int _counterPhoto; // Номер сделанной фотографии

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запуск вычисления гистограмм
        /// </summary>
        private void СalculateHistogramStandardsButton_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < _standart.Count; index++)
            {
                _gistograms.Add(new List<int[]>());
                var standart = _standart[index];
                foreach (var image in standart)
                {
                    var bitmap = new Bitmap(image);
                    _gistograms[index].Add(Histogram.GetHistogramm(bitmap));
                }
            }
            SystemHelper.Serialize(_standartName, _gistograms);
        }

        /// <summary>
        /// Открытие и сравнение изображения
        /// </summary>
        private void openImage_Click(object sender, EventArgs e)
        {
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                var bitmap = new Bitmap(openFileImage.FileName);
                int[] gist = Histogram.GetHistogramm(bitmap);
                var rezult = Histogram.Compare(gist, _gistograms, _standartName);
                GrawHistogram(gist);
                MessageBox.Show(rezult);
                if (rezult != "NULL" || !trainingMode.Checked) return;
                var form = new Traning(ref _standartName, ref _gistograms, gist);
                using (form) form.ShowDialog();
            }
        }

        /// <summary>
        /// Вывод гисторгаммы
        /// </summary>
        /// <param name="gist">Гистограмма изображения</param>
        private void GrawHistogram(IEnumerable<int> gist)
        {
            var bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.BackgroundImage = bmp;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Brush pik = new SolidBrush(Color.CornflowerBlue);
                var xPanel = 1;
                var number = 0;
                var tmp = 0;
                foreach (int value in gist)
                {
                    tmp = tmp + value;
                    number++;
                    if (number != 4) continue;
                    var m = tmp/350;
                    g.FillRectangle(pik, xPanel, 350 - m, 2, m);
                    xPanel += 2;
                    tmp = 0;
                    number = 0;
                }
                pik.Dispose();
            }
        }

        /// <summary>
        /// Загрузка гистограмм с диска
        /// </summary>
        private void loadingButton_Click(object sender, EventArgs e)
        {
            _standartName.Clear();
            _gistograms.Clear();
            SystemHelper.Desirealise(ref _standartName, ref _gistograms);
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            // Кнопки
            Wbutton.Enabled = false;
            Abutton.Enabled = false;
            Sbutton.Enabled = false;
            Dbutton.Enabled = false;
            Xbutton.Enabled = false;

            // Поиск эталонов
            SystemHelper.GetCountObjects(ref _standart, ref _standartName);
            infoLabel.Text = "Колличество объектов: " + _standartName.Count + "\n";
            for (int index = 0; index < _standartName.Count; index++)
            {
                var name = _standartName[index];
                infoLabel.Text += name + " ";
                infoLabel.Text += "Эталонов - " + _standart[index].Count + "\n";
            }

            // Поиск видео устройств
            _videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoCaptureDevice in _videoCaptureDevices)
                comboBox1.Items.Add(videoCaptureDevice.Name);

            // Поиск активных COM портов
            var ports = SerialPort.GetPortNames();
            foreach (var port in ports)
                portsComboBox.Items.Add(port);

            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                comboBox1.Enabled = false;
                startCaptureButton.Enabled = false;
                stopCameraButton.Enabled = false;
            }

            try
            {
                portsComboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {
                portsComboBox.Enabled = false;
                connectButton.Enabled = false;
            }
        }

        /// <summary>
        /// Запуск захвата видео
        /// </summary>
        private void startCaptureButton_Click(object sender, EventArgs e)
        {
            _finalVideo = new VideoCaptureDevice(_videoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
            _finalVideo.NewFrame += FinalVideo_NewFrame;
            _finalVideo.Start();
        }

        /// <summary>
        /// Событие по приходу нового кадра
        /// </summary>
        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            var video = (Bitmap) eventargs.Frame.Clone();
            if (cameraOnlineCheckBox.Checked)
                pictureBox1.Image = video;
            else
            {
                int[] gist = Histogram.GetHistogramm(video);
                var rezult = Histogram.Compare(gist, _gistograms, _standartName);
                rezultLabel.Text = rezult;
                GrawHistogram(gist);
            }
        }

        /// <summary>
        /// Остановка захвата видео
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (_finalVideo.IsRunning)
                _finalVideo.Stop();
            pictureBox1.Dispose();
            panel1.Dispose();
        }

        /// <summary>
        /// Подключение к выбранному порту
        /// </summary>
        private void connectButton_Click(object sender, EventArgs e)
        {
            _arduinoPort = new SerialPort(portsComboBox.Text, 57600);
            _arduinoPort.Open();
            Wbutton.Enabled = true;
            Abutton.Enabled = true;
            Sbutton.Enabled = true;
            Dbutton.Enabled = true;
            Xbutton.Enabled = true;
        }

        /// <summary>
        /// Комманды движения робота
        /// </summary>
        private void Wbutton_Click(object sender, EventArgs e)
        {
            _arduinoPort.Write("W");
            transportLabel.Text = "Робот движется вперёд";
        }

        private void Sbutton_Click(object sender, EventArgs e)
        {
            _arduinoPort.Write("S");
            transportLabel.Text = "Робот движется назад";
        }

        private void Abutton_Click(object sender, EventArgs e)
        {
            _arduinoPort.Write("A");
            transportLabel.Text = "Робот поворачивает влево";
        }

        private void Dbutton_Click(object sender, EventArgs e)
        {
            _arduinoPort.Write("D");
            transportLabel.Text = "Робот поворачивает вправо";
        }

        private void Xbutton_Click(object sender, EventArgs e)
        {
            _arduinoPort.Write("x");
            transportLabel.Text = "Робот остановился";
        }

        /// <summary>
        /// Сделать снимок
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            var bmpSave = (Bitmap) pictureBox1.Image;
            bmpSave.Save(@"1234/" + _counterPhoto + ".png");
            _counterPhoto++;
        }
    }
}