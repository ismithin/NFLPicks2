using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class Game
    {
        public int GameID { get; set; }
        public GamesButtons ButtonA { get; set; }
        public GamesButtons ButtonB { get; set; }

    }


    public Game(int gameID, Teams teamA, Teams teamB)
    {
        GameID = gameID;
        ButtonA = new Button(teamA);
        ButtonB = new Button(teamB);
    }
}
