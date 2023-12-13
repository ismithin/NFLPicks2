using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    //I never got to implement this. But now that im lookin at it, I think I would have made the scoredboard alot easier.
    //I would have made a list of users and then a list of scores. Then I would have made a method that would have sorted the scores
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
