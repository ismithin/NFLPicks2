using System.Collections.Generic;
using System.Linq;

namespace NFLPicks2
{
    public class Weeks
    {
        public int WeekNumber { get; set; }
        public List<Matchup> Matchups { get; private set; } = new List<Matchup>();

        // Assuming you have a list to store all the weeks
        private static List<Weeks> allWeeks = new List<Weeks>();

        public Weeks(int weekNumber)
        {
            WeekNumber = weekNumber;
            AddMatchup(new Matchup("Team1A", "Team1B"));
            AddMatchup(new Matchup("Team2A", "Team2B"));
        }

        public void AddMatchup(Matchup matchup)
        {
            Matchups.Add(matchup);
        }

        public static Weeks GetWeekByNumber(int weekNumber)
        {
            return allWeeks.FirstOrDefault(week => week.WeekNumber == weekNumber);
        }
    }
}
