using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NFLGamePredictorCode
{
    class Program
    {
        static void LoadJson()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Ryan Styles\\Documents\\PythonClass\\scraping\\Logs\\log1541999589.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                //Console.WriteLine(items[0]);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            LoadJson();
            Console.ReadLine();
        }
    }
}