using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLGamePredictor
{
    public class Team
    {
        public string teamName;
        public List<Week> weekStats;
        public decimal avgScore = 0;
        public decimal avgAllowed = 0;

        public Team(string teamName, List<Week> weekStats)
        {
            this.teamName = teamName;
            this.weekStats = weekStats;

            avgCalc();
        }

        private void avgCalc()
        {
            int counter = 0;
            foreach (Week weekItem in weekStats)
            {
                counter += 1;
                avgScore += weekItem.pointsScored;
                avgAllowed += weekItem.pointsAllowed;
            }
            avgScore = avgScore / counter;
            avgAllowed = avgAllowed / counter;
        }
    }
}
