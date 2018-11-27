using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFLGamePredictor;
using Newtonsoft.Json;

namespace NFLGamePredictorCode
{
    class Program
    {
        static void LoadJson()
        {
            string json;
            using (StreamReader r = new StreamReader(@"C:\Users\Ryan Styles\Documents\PythonClass\scraping\Logs\log1541999589.json"))
            {
                json = r.ReadToEnd();
            }

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    team TeamOne = new team();
                    TeamOne.teamName = (reader.TokenType).ToString();
                    Console.WriteLine(TeamOne.teamName);
                    TeamOne.teamName = (reader.Value).ToString();
                    Console.WriteLine(TeamOne.teamName);
                }
            }
        }
            static void Main(string[] args)
        {
            LoadJson();

            Console.ReadLine();
        }
    }
}