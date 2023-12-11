using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class Weeks
    {
        public int WeekNumber { get; }
        public List<Matchup> Matchups { get; }

        public Weeks(int weekNumber)
        {
            WeekNumber = weekNumber;
            Matchups = new List<Matchup>();
        }

        public void AddMatchup(Matchup matchup)
        {
            Matchups.Add(matchup);
        }
    }
}
