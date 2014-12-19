using System;
using System.Collections.Generic;
using System.Drawing;

namespace test_image_rec
{
    class Histogram
    {
        private string _name;
        private double _rate;

        /// <summary>
        /// Созлание и маштабирование гистограммы
        /// </summary>
        /// <param name="image">Bitmap изображения</param>
        /// <returns>Гистограмма</returns>
        public static int[] GetHistogramm(Bitmap image)
        {
            using (image)
            {
                const int step = 1;
                var scale = new int[11, 11, 11];
                for (int x = 160; x < 481; x = x + step)
                    for (int y = 120; y < 361; y = y + step)
                    {
                        var pixel = image.GetPixel(x, y);
                        var r = (int)Math.Round(pixel.R / 25.5);
                        var g = (int)Math.Round(pixel.G / 25.5);
                        var b = (int)Math.Round(pixel.B / 25.5);
                        scale[r, g, b]++;
                    }
                var colorScale = new int[1331];
                var count = 0;
                for (int x = 0; x < 11; x++)
                    for (int y = 0; y < 11; y++)
                        for (int z = 0; z < 11; z++)
                        {
                            var tmp = (scale[x, y, z] / Convert.ToDouble(image.Width * image.Height)) * 10000000.0;
                            colorScale[count] = Convert.ToInt32(tmp);
                            count++;
                        }
                return colorScale;
            }
        }

        /// <summary>
        /// Сравнение гистограмм и вывод названия объекта
        /// </summary>
        /// <param name="gist">Гистограмма выбранного изображения</param>
        /// <param name="gistograms">Гистограммы эталонов</param>
        /// <param name="standartName">Имя объектов</param>
        /// <returns>Имя</returns>
        public static string Compare(int[] gist, List<List<int[]>> gistograms, List<string> standartName)
        {
            var tmp = new List<Histogram>();
            var result = new List<List<double>>();
            const double delta = 300000;
            for (int index = 0; index < gistograms.Count; index++)
            {
                result.Add(new List<double>());
                foreach (var gistImage in gistograms[index])
                {
                    double si = 0;
                    for (int x = 0; x < 1331; x++)
                                si += Math.Pow(gist[x] - gistImage[x], 2);
                    result[index].Add(Math.Sqrt(si));
                }
            }
            for (int index = 0; index < result.Count; index++)
            {
                var si = result[index];
                si.Sort();
                tmp.Add(new Histogram {_name = standartName[index], _rate = si[0]});
            }
            tmp.Sort((a, b) => a._rate.CompareTo(b._rate));
            return tmp[0]._rate < delta ? tmp[0]._name : "NULL";
        }
    }
}
