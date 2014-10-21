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
        private readonly List<ImageRec> _examples = new List<ImageRec>();
        
        public Main()
        {
            InitializeComponent();
            var m = new MessageInfo();
            m.Show();
            PreparationStandards();
            m.Close();
        }

        private void PreparationStandards()
        {
            var names = Directory.GetFiles(@"standart\mug", "*.jpg");
            foreach (var nameFile in names)
                CalculateLevels(nameFile);
        }

        private void CalculateLevels(string imageName)
        {
            var image = new ImageRec(new Bitmap(imageName), new List<int>(), new List<int>(), new List<int>());
            Gistogram(image);
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
                    var color = bmp.GetPixel(i, j);
                    tmpR += color.R;
                    tmpG += color.G;
                    tmpB += color.B;
                }
                image.Red.Add(tmpR);
                image.Green.Add(tmpG);
                image.Blue.Add(tmpB);
            }
        }

        private void openImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var image = new ImageRec(new Bitmap(openFileDialog1.FileName), new List<int>(), new List<int>(), new List<int>());
            Gistogram(image);
            var sRed = new List<Double>();
            var sGreen = new List<Double>();
            var sBlue = new List<Double>();
            CompareGistogram(sRed, sGreen, sBlue, image);
            FindMinS(sRed, sGreen, sBlue);

        }

        private void FindMinS(IEnumerable<double> sRed, IEnumerable<double> sGreen, IEnumerable<double> sBlue)
        {
            var minR = sRed.Min();
            var minG = sGreen.Min();
            var minB = sBlue.Min();
            if (minR < 400000 && minG < 400000 && minB < 400000)
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

        private void CompareGistogram(ICollection<double> sRed, ICollection<double> sGreen, ICollection<double> sBlue, ImageRec image)
        {
            foreach (var imageRec in _examples)
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

    }
}
