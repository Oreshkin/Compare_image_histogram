using System.Collections.Generic;
using System.IO;

namespace test_image_rec
{
    class SystemHelper
    {
        /// <summary>
        /// Метод загрузки данных о содержимом папки standart
        /// (подсчет классов объектов и считывание имен файлов)
        /// </summary>
        /// <param name="standart">Список объектов</param>
        public static void GetCountObjects(ref List<List<string>> standart)
        {
            string[] namesDir = Directory.GetDirectories(@"standart/");
            for (int index = 0; index < namesDir.Length; index++)
            {
                standart.Add(new List<string>());
                var dir = Directory.GetFiles(@"" + namesDir[index] + "/", "*.jpg");
                foreach (var file in dir)
                    standart[index].Add(file);
            }
        }

    }
}
