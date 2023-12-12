using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class Matchup
    {
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string Winner { get; set; }

        public Matchup(string teamA, string teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
            RandomlySelectWinner();
        }

        private void RandomlySelectWinner()
        {
            // Randomly choose a winner between TeamA and TeamB
            Random random = new Random();
            Winner = (random.Next(2) == 0) ? TeamA : TeamB;
        }
    }
}
