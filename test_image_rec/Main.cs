using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace test_image_rec
{
    public partial class Main : Form
    {
        private readonly List<List<string>> _standart = new List<List<string>>();
        private readonly List<List<int[,,]>> _gistograms = new List<List<int[,,]>>();

        public Main()
        {
            InitializeComponent();
            SystemHelper.GetCountObjects(ref _standart);
        }

        /// <summary>
        /// Запуск вычисления гистограмм
        /// </summary>
        private void СalculateHistogramStandardsButton_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < _standart.Count; index++)
            {
                _gistograms.Add(new List<int[,,]>());
                var standart = _standart[index];
                foreach (var image in standart)
                    _gistograms[index].Add(Histogram.GetHistogramm(image));
            }
        }

        /// <summary>
        /// Открытие и сравнение изображения
        /// </summary>
        private void openImage_Click(object sender, EventArgs e)
        {
            if (openFileImage.ShowDialog() == DialogResult.OK)
            {
                int[,,] gist = Histogram.GetHistogramm(openFileImage.FileName);
                var rezult = Histogram.Compare(gist, _gistograms);
                MessageBox.Show(Convert.ToString(rezult));
                GrawHistogram(gist);
            }
        }

        /// <summary>
        /// Вывод гисторгаммы
        /// </summary>
        /// <param name="gist">Гистограмма изображения</param>
        private void GrawHistogram(int[,,] gist)
        {
            var bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.BackgroundImage = bmp;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Brush pik = new SolidBrush(Color.CornflowerBlue);
                int xPanel = 1;
                int number = 0;
                int tmp = 0;
                for (int x = 0; x < 11; x++)
                    for (int y = 0; y < 11; y++)
                        for (int z = 0; z < 11; z++)
                        {
                            tmp = tmp + gist[x, y, z];
                            number++;
                            if (number != 4) continue;
                            var m = tmp/350;
                            g.FillRectangle(pik, xPanel, 350-m, 1, m);
                            xPanel += 1;
                            tmp = 0;
                            number = 0;
                        }
                pik.Dispose();
            }
        }
    }
}