using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class AdminUser : User, IUser
    {
        public AdminUser(string username, string password) : base(username, password)
        {
            
        }
        public void AddMemberToLeague(User user, League league)
        {
            if (league != null)
            {
                league.AddMember(user);
            }
        }
        public void AddMemberToLeague(int numberOfUsers, League league)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                User dummyUser = CreateDummyUser(); // Implement CreateDummyUser() to generate a dummy user
                league.AddMember(dummyUser);
            }
        }
        private User CreateDummyUser()
        {
            //I went and found some code for creating multuple dummy users. I'm not sure if I need this or not.
            string dummyUsername = $"DummyUser{Guid.NewGuid().ToString("N").Substring(0, 8)}";
            string dummyPassword = "dummyPassword";

            return new User(dummyUsername, dummyPassword);
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
