using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class UserAdmin : User
    {
        // Constructor
        public UserAdmin(string username, string password) : base(username, password)
        {
            // Additional setup for UserAdmin if needed
        }

        // Methods specific to UserAdmin
        public void AddMemberToLeague(User user, League league)
        {
            if (league != null)
            {
                league.AddMember(user);
            }
        }

        public void RemoveMemberFromLeague(User user, League league)
        {
            if (league != null)
            {
                league.RemoveMember(user);
            }
        }

        public void OverwriteScoreInLeague(User user, League league, int newScore)
        {
            if (league != null)
            {
                league.UpdateScore(user, newScore);
            }
        }
    }

}
