using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using NFLGamePredictor;

namespace NFLGamePredictorCode
{
    class Program
    {
        static NFL LoadData()
        {
            string path = @"C:\Users\Ryan Styles\Documents\PythonClass\scraping\Logs\log.txt";
            string[] lines = File.ReadAllLines(path);

            var currentWeek = Convert.ToInt32(lines[0]);
            List<Team> teamList = new List<Team>();

            for (int i = 1; i <= 32; i++)
            {
                string line = lines[i];
                string[] values = line.Split(',');

                string teamName = values[0].ToString();
                List<string> weeksData = new List<string>();
                List<string> opponentNames = new List<string>();
                List<string> results = new List<string>();
                List<int> scoredList = new List<int>();
                List<int> allowedList = new List<int>();

                List<Week> weekList = new List<Week>();
                int weekCounter = 0;

                for (int x = 1; x <= (currentWeek * 5); x += 5)
                {
                    if (values[x] == "end" || values[x + 1] == "end" || values[x + 2] == "end" || values[x + 3] == "end" || values[x + 4] == "end")
                    {
                        break; // if a team has had their bye week already, then they need to break early
                    }
                    weekList.Add(new Week(values[x], values[x + 1], values[x + 2], Int32.Parse(values[x + 3]), Int32.Parse(values[x + 4])));
                    weekCounter++;
                }

                teamList.Add(new Team(teamName, weekList));
            }

            return new NFL(teamList);
        }

        static bool isTeam(string teamName, NFL league)
        {
            bool teamExists = false;

            foreach (Team name in league.allTeams)
            {
                if (name.teamName == teamName)
                {
                    teamExists = true;
                }
            }

            return teamExists;
        }

        static void Predictor(string compTeam1, string compTeam2, NFL nflTeams)
        {
            decimal avgScore1 = 0;
            decimal avgAllowed1 = 0;
            decimal avgScore2 = 0;
            decimal avgAllowed2 = 0;

            foreach (Team teamItem in nflTeams.allTeams)
            {
                if (teamItem.teamName == compTeam1)
                {
                    avgScore1 = teamItem.avgScore;
                    avgAllowed1 = teamItem.avgAllowed;
                }
                else if (teamItem.teamName == compTeam2)
                {
                    avgScore2 = teamItem.avgScore;
                    avgAllowed2 = teamItem.avgAllowed;
                }
            }

            decimal avgScore1Adjusted = Math.Round(((avgScore1 + avgAllowed2) / 2), 1, MidpointRounding.AwayFromZero);
            decimal avgScore2Adjusted = Math.Round(((avgScore2 + avgAllowed1) / 2), 1, MidpointRounding.AwayFromZero);

            if (avgScore1Adjusted > avgScore2Adjusted)
            {
                Console.WriteLine(compTeam1 + " will win by a score of " + avgScore1Adjusted + " - " + avgScore2Adjusted);
            }
            else if (avgScore2Adjusted > avgScore1Adjusted)
            {
                Console.WriteLine(compTeam2 + " will win by a score of " + avgScore2Adjusted + " - " + avgScore1Adjusted);
            }
            else if (avgScore1Adjusted == avgScore2Adjusted)
            {
                Console.WriteLine("TIE! Both " + compTeam1 + " and " + compTeam2 + " will score " + avgScore1Adjusted);
            }
        }
        static void Main(string[] args)
        {
            string compTeam1 = "";
            string compTeam2 = "";
            try
            {
                compTeam1 = args[0];
                compTeam2 = args[1];
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter enter two NFL team names on the command line separated by a space.");
                Console.WriteLine("Example: NFLGamePredictor.exe Bears Packers");
                Console.ReadLine();
                Environment.Exit(1);
            }

            NFL league = LoadData();

            if (isTeam(compTeam1, league) && isTeam(compTeam2, league))
            {
                Console.WriteLine("Predicting winner for " + compTeam1 + " vs " + compTeam2 + "...");
                Predictor(compTeam1, compTeam2, league);
            }
            else
            {
                Console.WriteLine("Please enter enter two NFL team names on the command line separated by a space.");
                Console.WriteLine("Example: NFLGamePredictor.exe Bears Packers");
            }

            Console.ReadLine();
        }
    }
}