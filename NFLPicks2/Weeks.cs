using System.Collections.Generic;
using System.Linq;

namespace NFLPicks2
{
    public class Weeks
    {
        public int WeekNumber { get; private set; }
        public List<Matchup> Matchups { get; private set; } = new List<Matchup>();

        // Assuming you have a list to store all the weeks
        private static List<Weeks> allWeeks = new List<Weeks>();

        public Weeks(int weekNumber)
        {
            WeekNumber = weekNumber;
            allWeeks.Add(this); // Add the current week to the list
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
