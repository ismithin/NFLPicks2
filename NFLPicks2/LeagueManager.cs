using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public static class LeagueManager
    {
        // Static list to store existing league names
        public static List<string> LeagueExists { get; private set; } = new List<string>();
        // Method to add a league to the existing leagues
        public static void AddLeague(string leagueName)
        {
            if (!LeagueExists.Contains(leagueName))
            {
                LeagueExists.Add(leagueName);
            }
        }
        // Method to check if a league exists
        public static bool DoesLeagueExist(string leagueName)
        {
            return LeagueExists.Contains(leagueName);
        }
    }
}
