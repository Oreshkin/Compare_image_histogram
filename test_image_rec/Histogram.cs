using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading; 

namespace test_image_rec
{
    class Histogram
    {
        public static Semaphore Mutex = new Semaphore(1, 1);
        private string _name;
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
                var width = image.Width;
                var height = image.Height;
                var colorScale = new int[11, 11, 11];
                var T = new Thread[3];
                for (int i = 0; i < 3; i++)
                {
                    T[i] = new Thread(() => { GetValue(image, height, width, ref colorScale, i); });
                    T[i].Start();
                }
                for (int i = 0; i < 3; i++)
                    T[i].Join();

                for (int x = 0; x < 11; x++)
                    for (int y = 0; y < 11; y++)
                        for (int z = 0; z < 11; z++)
                        {
                            var tmp = (colorScale[x, y, z] / Convert.ToDouble(image.Width * image.Height)) * 10000000.0;
                            colorScale[x, y, z] = Convert.ToInt32(tmp);
                        }
                return colorScale;
            }
        }

        private static void GetValue(Bitmap image, int height, int width, ref int[,,] colorScale, int step)
        {
            for (int x = step; x < width; x = x + step)
                for (int y = step; y < height; y = y + step)
                {
                    Mutex.WaitOne();
                    var pixel = image.GetPixel(x, y);
                    Mutex.Release();
                    var r = (int)Math.Round(pixel.R / 25.5);
                    var g = (int)Math.Round(pixel.G / 25.5);
                    var b = (int)Math.Round(pixel.B / 25.5);
                    Interlocked.Increment(ref colorScale[r, g, b]);
                }
        }

        /// <summary>
        /// Сравнение гистограмм и вывод названия объекта
        /// </summary>
        /// <param name="gist">Гистограмма выбранного изображения</param>
        /// <param name="gistograms">Гистограммы эталонов</param>
        /// <param name="standartName">Имя объектов</param>
        /// <returns>Имя</returns>
        public static string Compare(int[,,] gist, List<List<int[,,]>> gistograms, List<string> standartName)
        {
            var tmp = new List<Histogram>();
            var result = new List<List<double>>();
            const double delta = 1000000;
            for (int index = 0; index < gistograms.Count; index++)
            {
                result.Add(new List<double>());
                foreach (var gistImage in gistograms[index])
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
                tmp.Add(new Histogram {_name = standartName[index], _rate = si[0]});
            }
            tmp.Sort((a, b) => a._rate.CompareTo(b._rate));
            return tmp[0]._rate < delta ? tmp[0]._name : "NULL";
        }
    }
}
