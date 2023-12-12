using System.Collections.Generic;
using System.Linq;

namespace NFLPicks2
{
    public class Weeks
    {
        public int WeekNumber { get; set; }
        public List<Matchup> Matchups { get; private set; } = new List<Matchup>();

        // List to store all the weeks
        private static List<Weeks> allWeeks = new List<Weeks>();

        public Weeks(int weekNumber)
        {
            WeekNumber = weekNumber;
            // No need to add preset matchups here
            allWeeks.Add(this);
        }

        public void AddMatchup(Matchup matchup)
        {
            Matchups.Add(matchup);
        }

        public static List<Weeks> GetAllWeeks()
        {
            return allWeeks;
        }

        public static Weeks GetWeekByNumber(int weekNumber)
        {
            return allWeeks.FirstOrDefault(week => week.WeekNumber == weekNumber);
        }
    }
}

