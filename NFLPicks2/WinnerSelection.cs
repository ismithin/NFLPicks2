using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class WinnerSelection
    {
        public Dictionary<int, string> MatchupSelections { get; } = new Dictionary<int, string>();

        public void SelectTeam(int matchupNumber, string team)
        {
            // Check if the matchup is already in the dictionary
            if (MatchupSelections.ContainsKey(matchupNumber))
            {
                // If it is, update the selected team
                MatchupSelections[matchupNumber] = team;
            }
            else
            {
                // If not, add the matchup and selected team
                MatchupSelections.Add(matchupNumber, team);
            }
        }

        public string GetSelectedTeam(int matchupNumber)
        {
            // Get the selected team for a specific matchup
            return MatchupSelections.ContainsKey(matchupNumber) ? MatchupSelections[matchupNumber] : null;
        }
    }
}
