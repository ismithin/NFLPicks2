using System;
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
