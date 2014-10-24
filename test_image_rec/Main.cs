using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace test_image_rec
{
    public partial class Main : Form
    {
        private readonly List<ImageRec> _examples = new List<ImageRec>();   // Эталоны

        public Main()
        {
            InitializeComponent();
            var m = new MessageInfo();
            ResizeOriginalImage();
            m.Show();
            PreparationStandards();
            m.Close();
        }

        private void PreparationStandards()
        {
            string[] names = Directory.GetFiles(@"standart\mug\resize", "*.jpg");
            foreach (string nameFile in names)
                CalculateLevels(nameFile);
        }

        private void ResizeOriginalImage()
        {
            string[] names = Directory.GetFiles(@"standart\mug", "*.jpg");
            for (int i = 0; i < names.Length; i++)
                ResizeImage(names[i], @"standart\mug\resize\" + i + ".jpg", 1024, 768, true);
        }

        private void CalculateLevels(string imageName)
        {
            var image = new ImageRec(new Bitmap(imageName), new List<int>(), new List<int>(), new List<int>());
            Gistogram(image);
            image.ImageSourseBitmap.Dispose();
            _examples.Add(image);
        }

        private static void Gistogram(ImageRec image)
        {
            var bmp = new Bitmap(image.ImageSourseBitmap);
            for (int i = 0; i < bmp.Width; ++i)
            {
                int tmpR = 0, tmpG = 0, tmpB = 0;
                for (int j = 0; j < bmp.Height; ++j)
                {
                    Color color = bmp.GetPixel(i, j);
                    tmpR += color.R;
                    tmpG += color.G;
                    tmpB += color.B;
                }
                image.Red.Add(tmpR);
                image.Green.Add(tmpG);
                image.Blue.Add(tmpB);
            }
            bmp.Dispose();
        }

        private void openImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            ResizeImage(openFileDialog1.FileName, @"tmp.jpg", 1024, 768, true);
            var image = new ImageRec(new Bitmap(@"tmp.jpg"), new List<int>(), new List<int>(),
                new List<int>());
            Gistogram(image);
            var sRed = new List<Double>();
            var sGreen = new List<Double>();
            var sBlue = new List<Double>();
            CompareGistogram(sRed, sGreen, sBlue, image);
            FindMinS(sRed, sGreen, sBlue);
            image.ImageSourseBitmap.Dispose();
            File.Delete(@"tmp.jpg");
        }

        private void FindMinS(IEnumerable<double> sRed, IEnumerable<double> sGreen, IEnumerable<double> sBlue)
        {
            const int max = 400000;
            var minR = sRed.Max();
            var minG = sGreen.Max();
            var minB = sBlue.Max();
            if (minR < max && minG < max && minB < max)
            {
                label1.BackColor = Color.Chartreuse;
                label1.Text = "ОК";
            }
            else
            {
                label1.BackColor = Color.Red;
                label1.Text = "NOT";
            }
        }

        private void CompareGistogram(ICollection<double> sRed, ICollection<double> sGreen, ICollection<double> sBlue,
            ImageRec image)
        {
            foreach (ImageRec imageRec in _examples)
            {
                double s = 0;
                for (int i = 0; i < imageRec.Red.Count; i++)
                    s += Math.Pow(image.Red[i] - imageRec.Red[i], 2);
                sRed.Add(Math.Sqrt(s));
                s = 0;
                for (int i = 0; i < imageRec.Green.Count; i++)
                    s += Math.Pow(image.Green[i] - imageRec.Green[i], 2);
                sGreen.Add(Math.Sqrt(s));
                s = 0;
                for (int i = 0; i < imageRec.Blue.Count; i++)
                    s += Math.Pow(image.Blue[i] - imageRec.Blue[i], 2);
                sBlue.Add(Math.Sqrt(s));
            }
        }

        /// <summary>
        /// Изменение размера изображения
        /// </summary>
        /// <param name="origFile">Входной файл</param>
        /// <param name="newFile">Выходной файл</param>
        /// <param name="newWidth">Новая ширина</param>
        /// <param name="maxHeight">Максимальная высота</param>
        /// <param name="resizeIfWider">Маштабирование</param>
        public void ResizeImage(string origFile, string newFile, int newWidth, int maxHeight, bool resizeIfWider)
        {
            var fullSizeImage = Image.FromFile(origFile);
            // Для буфферизации поворачиваем на 360 градусов
            fullSizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            fullSizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (resizeIfWider)
                if (fullSizeImage.Width <= newWidth)
                    newWidth = fullSizeImage.Width;
            var newHeight = fullSizeImage.Height*newWidth/fullSizeImage.Width;
            // Изменение высоты при необходимости
            if (newHeight > maxHeight)
            {
                newWidth = fullSizeImage.Width*maxHeight/fullSizeImage.Height;
                newHeight = maxHeight;
            }
            // Создаём изображение в новыми размерами
            var newImage = fullSizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
            fullSizeImage.Dispose();
            newImage.Save(newFile);
        }

    }
}