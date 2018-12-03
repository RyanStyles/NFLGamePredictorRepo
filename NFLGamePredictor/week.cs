using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLGamePredictor
{
    public class Week
    {
        public string weekNumber;
        public string opponent;
        public string result;
        public int pointsScored;
        public int pointsAllowed;

        public Week(string weekNumber, string opponent, string result, int pointsScored, int pointsAllowed)
        {
            this.weekNumber = weekNumber;
            this.opponent = opponent;
            this.result = result;
            this.pointsScored = pointsScored;
            this.pointsAllowed = pointsAllowed;
        }
    }
}
