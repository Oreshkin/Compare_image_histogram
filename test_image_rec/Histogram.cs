using System;
using System.Collections.Generic;
using System.Drawing;

namespace test_image_rec
{
    class Histogram
    {
        private int _name;
        private double _rate;

        /// <summary>
        /// Созлание и маштабирование гистограммы
        /// </summary>
        /// <param name="fileName">Изображение</param>
        /// <returns>Гистограмма</returns>
        public static int[,,] GetHistogramm(string fileName)
        {
            using (var image = new Bitmap(fileName))
            {
                var colorScale = new int[11, 11, 11];
                for (int x = 0; x < image.Width; x++)
                    for (int y = 0; y < image.Height; y++)
                    {
                        var pixel = image.GetPixel(x, y);
                        var r = Convert.ToInt32(Math.Round(Convert.ToDouble(pixel.R/25.5)));
                        var g = Convert.ToInt32(Math.Round(Convert.ToDouble(pixel.G/25.5)));
                        var b = Convert.ToInt32(Math.Round(Convert.ToDouble(pixel.B/25.5)));
                        colorScale[r, g, b]++;
                    }

                for (int x = 0; x < 11; x++)
                    for (int y = 0; y < 11; y++)
                        for (int z = 0; z < 11; z++)
                        {
                            double tmp = (Convert.ToDouble(colorScale[x, y, z]) / Convert.ToDouble(image.Width * image.Height)) * 10000000.0;
                            colorScale[x, y, z] = Convert.ToInt32(tmp);
                        }
                return colorScale;
            }
        }

        /// <summary>
        /// Сравнение гистограмм и вывод названия объекта
        /// </summary>
        /// <param name="gist">Гистограмма выбранного изображения</param>
        /// <param name="gistograms">Гистограммы эталонов</param>
        /// <returns>Имя</returns>
        public static int Compare(int[,,] gist, List<List<int[,,]>> gistograms)
        {
            var tmp = new List<Histogram>();
            var result = new List<List<double>>();
            const double delta = 1000000;
            for (int index = 0; index < gistograms.Count; index++)
            {
                result.Add(new List<double>());
                var gistogram = gistograms[index];
                foreach (var gistImage in gistogram)
                {
                    double si = 0;
                    for (int x = 0; x < 11; x++)
                        for (int y = 0; y < 11; y++)
                            for (int z = 0; z < 11; z++)
                                si += Math.Pow(gist[x, y, z] - gistImage[x, y, z], 2);
                    result[index].Add(Math.Sqrt(si));
                }
            }
            for (int index = 0; index < result.Count; index++)
            {
                var si = result[index];
                si.Sort();
                tmp.Add(new Histogram {_name = index, _rate = si[0]});
            }
            tmp.Sort((a, b) => a._rate.CompareTo(b._rate));
            if (tmp[0]._rate < delta)
                return tmp[0]._name;
            return -1;
        }
    }
}
