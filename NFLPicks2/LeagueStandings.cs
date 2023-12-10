using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class LeagueStandings
    {
        public int LeagueID { get; }
        private Dictionary<User, int> userScores;

        public LeagueStandings(int leagueID)
        {
            LeagueID = leagueID;
            userScores = new Dictionary<User, int>();
        }
        public void AddUser(User user)
        {
            // Initialize the score for a new user
            userScores.Add(user, 0);
        }

        public int GetScore(User user)
        {
            // Get the score for a user
            return userScores.ContainsKey(user) ? userScores[user] : 0;
        }
    }
}
