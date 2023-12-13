using System.Collections.Generic;
using System.Linq;

namespace NFLPicks2
{
    public class League
    {
        public string LeagueName { get; private set; }
        private List<LeagueMember> members = new List<LeagueMember>();

        public League(string leagueName)
        {
            this.LeagueName = leagueName;
        }

        public void AddMember(User user)
        {
            if (!members.Any(member => member.Username == user.Username))
            {
                members.Add(new LeagueMember { Username = user.Username, Score = 0 });
            }
        }

        public void RemoveMember(User user)
        {
            var memberToRemove = members.FirstOrDefault(member => member.Username == user.Username);
            if (memberToRemove != null)
            {
                members.Remove(memberToRemove);
            }
        }

        public int GetScore(User user)
        {
            var member = members.FirstOrDefault(m => m.Username == user.Username);
            return member != null ? member.Score : 0;
        }

        public void UpdateScore(User user, int newScore)
        {
            var member = members.FirstOrDefault(m => m.Username == user.Username);
            if (member != null)
            {
                member.Score = newScore;
            }
        }
        public List<LeagueMember> GetMembers()
        {
            return members.ToList();
        }
    }
}