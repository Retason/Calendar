using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp3
{
    internal static class SaveLoad
    {
        private const string fileName = "Data.xml";
        public static void SaveData(List<DayItem> arg)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<DayItem>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, arg);
            }
        }
        public static List<DayItem> LoadData()
        {
            if (File.Exists(fileName))
            {

                XmlSerializer formatter = new XmlSerializer(typeof(List<DayItem>));
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        List<DayItem> result = (List<DayItem>)formatter.Deserialize(fs);
                        return result ?? new List<DayItem>();
                    }
                    catch
                    {
                        MessageBox.Show("Error", "ошибка чтения файла", MessageBoxButton.OK, MessageBoxImage.Error);
                        return new List<DayItem>();
                    }
                }
            }
            else
            {
                return new List<DayItem>();
            }
        }
    }
}
