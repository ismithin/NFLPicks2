using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class Game
    {
        public ButtonInfo ButtonA { get; set; }
        public ButtonInfo ButtonB { get; set; }
        public Game( Matchup matchup)
        {
            ButtonA = new ButtonInfo(matchup.TeamA);
            ButtonB = new ButtonInfo(matchup.TeamB);
        }
    }
    public class ButtonInfo
    {
        public string Team { get; set; }
        public ButtonInfo(string team)
        {
            Team = team;
        }
    }
}
