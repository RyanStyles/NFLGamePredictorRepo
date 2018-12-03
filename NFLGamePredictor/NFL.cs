using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLGamePredictor
{
    public class NFL
    {
        public List<Team> allTeams;
        public decimal pointsScoredPerGame = 0;
        public decimal pointsAllowedPerGame = 0;

        public NFL(List<Team> allTeams)
        {
            this.allTeams = allTeams;
        }

        private void calcLeagueAverages(List<Team> allTeams)
        {
            int counter = 0;
            foreach (Team team in allTeams)
            {
                pointsScoredPerGame += team.avgScore;
                pointsAllowedPerGame += team.avgAllowed;

                counter++;
            }
            pointsScoredPerGame = Math.Round((pointsScoredPerGame / counter), 1, MidpointRounding.AwayFromZero);
            pointsAllowedPerGame = Math.Round((pointsAllowedPerGame / counter), 1, MidpointRounding.AwayFromZero);
        }
    }
}
