using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class League
    {
        // Attributes
        private int leagueID;
        private string leagueName;
        private string description;
        private List<User> members;
        private string rules;
    }

    // Constructor
    public League(string leagueName, string description, string rules)
    {
        // Initialize attributes and perform necessary setup
    }

    // Methods
    public void CreateLeague()
    {
        // Implement league creation logic
    }

    public void JoinLeague(User user)
    {
        // Implement logic for user joining the league
    }

    public void ManageMembers()
    {
        // Implement logic for managing members
    }

    public void SetRules(string newRules)
    {
        // Implement logic for setting and updating rules
    }
}
