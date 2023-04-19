using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac15
{
    internal class y
    {
        public static T Deserialize<T>(string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = "";
            if (File.Exists(desktop + "\\" + FileName))
                json = File.ReadAllText(desktop + "\\" + FileName);
            else
            {
                File.Create(desktop + "\\" + FileName);
                json = File.ReadAllText(desktop + "\\" + FileName);
            }
            T CurrentList = JsonConvert.DeserializeObject<T>(json);
            return CurrentList;
        }
        public static List<ElementModel> Elements = y.Deserialize<List<ElementModel>>("Elements.json");
        public static void Serialize<T>(T CurrentList, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(CurrentList);
            if (File.Exists(desktop + "\\" + FileName))
                File.WriteAllText(desktop + "\\" + FileName, json);
            else
            {
                File.Create(desktop + "\\" + FileName);
                File.WriteAllText(desktop + "\\" + FileName, json);
            }
        }
    }
}
