using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFLPicks2
{
    public class User
    {
        // Attributes
        public string Username { get; set; }
        public string Password { get; set; }
        public List<League> Leagues { get; private set; } = new List<League>();
        public List<WinnerSelection> WinnerSelections { get; private set; } = new List<WinnerSelection>();


        // Constructors
        public User()
        {
            // Default constructor
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Methods
        public void JoinLeague(League league)
        {
            if (Leagues.Count >= 4)
            {
                MessageBox.Show("You can only join up to 4 leagues. Please leave a league before joining another.");
            }
            if (!Leagues.Contains(league))
            {
                Leagues.Add(league);
                league.AddMember(this);
            }
        }

        public void LeaveLeague(League league)
        {
            if (Leagues.Contains(league))
            {
                Leagues.Remove(league);
                league.RemoveMember(this);
            }
            else
            {
                MessageBox.Show("You are not a member of the specified league.");
            }

            if (Leagues.Count == 0)
            {
                MessageBox.Show("You are not a member of any league.");
            }
        }
    }
}
