using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace test_image_rec
{
    class SystemHelper
    {
        /// <summary>
        /// Метод загрузки данных о содержимом папки standart
        /// и созранение имен объектов
        /// (подсчет классов объектов и считывание имен файлов)
        /// </summary>
        /// <param name="standart">Список объектов</param>
        /// <param name="standartName"></param>
        public static void GetCountObjects(ref List<List<string>> standart, ref List<string> standartName)
        {
            string[] namesDir = Directory.GetDirectories(@"standart/");
            for (int index = 0; index < namesDir.Length; index++)
            {
                standartName.Add(namesDir[index]);
                standart.Add(new List<string>());
                var dir = Directory.GetFiles(namesDir[index] + "/", "*.png");
                foreach (var file in dir)
                    standart[index].Add(file);
            }
        }

        /// <summary>
        /// Сохранение эталонов на диске
        /// </summary>
        /// <param name="standartName">Имена объектов</param>
        /// <param name="gistograms">Гистограммы</param>
        public static void Serialize(List<string> standartName, List<List<int[]>> gistograms)
        {
            var file = new FileStream(@"standartName.xml", FileMode.Create);
            var ser = new XmlSerializer(typeof(List<string>));
            using (file)
            {
                ser.Serialize(file, standartName);
            }
            file = new FileStream(@"gistograms.xml", FileMode.Create);
            ser = new XmlSerializer(typeof(List<List<int[]>>));
            using (file)
            {
                ser.Serialize(file, gistograms);
            }
        }

        /// <summary>
        /// Загрузка эталонов с диска
        /// </summary>
        /// <param name="standartName">Имена объектов</param>
        /// <param name="gistograms">Гистограммы</param>
        public static void Desirealise(ref List<string> standartName, ref List<List<int[]>> gistograms)
        {
            FileStream file;
            XmlSerializer serializer;
            if (File.Exists(@"standartName.xml"))
            {
                file = new FileStream(@"standartName.xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(List<string>));
                using (file)
                {
                    var obj = serializer.Deserialize(file);
                    standartName = obj as List<string>;
                }
            }
            if (File.Exists(@"gistograms.xml"))
            {
                file = new FileStream(@"gistograms.xml",  FileMode.Open);
                serializer = new XmlSerializer(typeof(List<List<int[]>>));
                using (file)
                {
                    var obj = serializer.Deserialize(file);
                    gistograms = obj as List<List<int[]>>;
                }
            }
        }
    }
}
