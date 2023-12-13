using NFLPicks2;
using System.Collections.Generic;
using System.Windows.Forms;

public class User : IUser
{
    // Attributes
    public string Username { get; set; }
    public string Password { get; set; }
    public List<League> Leagues { get; private set; } = new List<League>();
    public bool IsLeagueAdmin { get; set; } = false;
    public Dictionary<League, WinnerSelection> WinnerSelections { get; private set; } = new Dictionary<League, WinnerSelection>();

    // Constructors
    public User()
    { 
    }
    public User(string username, string password)
    {
        Username = username;
        Password = password;
        IsLeagueAdminSet();
    }
    public void IsLeagueAdminSet()
    {
        IsLeagueAdmin = false;
    }
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

            // Create a new WinnerSelection for this league
            WinnerSelections[league] = new WinnerSelection();
        }
    }

    public void LeaveLeague(League league)
    {
        if (Leagues.Contains(league))
        {
            Leagues.Remove(league);
            league.RemoveMember(this);

            // Remove the WinnerSelection for this league
            WinnerSelections.Remove(league);
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
