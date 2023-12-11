using NFLPicks2;
using System.Collections.Generic;

public class League
{
    // Attributes
    public string LeagueName;
    private List<User> members = new List<User>();
    private Dictionary<User, int> userScores = new Dictionary<User, int>();

    // Constructor
    public League(string leagueName)
    {
        // Initialize attributes and perform necessary setup
        this.LeagueName = leagueName;
    }

    // Methods
    public void AddMember(User user)
    {
        if (!members.Contains(user))
        {
            members.Add(user);
            userScores.Add(user, 0); // Initialize score for the user
        }
    }

    public void RemoveMember(User user)
    {
        members.Remove(user);
        userScores.Remove(user);
    }

    public int GetScore(User user)
    {
        return userScores.ContainsKey(user) ? userScores[user] : 0;
    }

    public void UpdateScore(User user, int newScore)
    {
        if (userScores.ContainsKey(user))
        {
            userScores[user] = newScore;
        }
    }
}
