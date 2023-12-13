using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class WinnerSelection
    {
        private Dictionary<int, Dictionary<int, string>> WeekMatchupSelections { get; } = new Dictionary<int, Dictionary<int, string>>();

        public void SelectTeam(int weekNumber, int matchupNumber, string team)
        {
            if (!WeekMatchupSelections.ContainsKey(weekNumber))
            {
                WeekMatchupSelections[weekNumber] = new Dictionary<int, string>();
            }

            WeekMatchupSelections[weekNumber][matchupNumber] = team;
        }
        public string GetSelectedTeam(int weekNumber, int matchupNumber)
        {
            if (WeekMatchupSelections.TryGetValue(weekNumber, out var weekSelections) &&
                weekSelections.TryGetValue(matchupNumber, out var selectedTeam))
            {
                return selectedTeam;
            }

            return null;
        }
    }
}
