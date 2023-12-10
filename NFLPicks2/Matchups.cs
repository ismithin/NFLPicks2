using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class Matchup
    {
        public Teams TeamA { get; set; }
        public Teams TeamB { get; set; }

        public Matchup(Teams teamA, Teams teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
        }
    }
}
