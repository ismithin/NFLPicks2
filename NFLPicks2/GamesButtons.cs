using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NFLPicks2
{
	public class GamesButtons
	{
		public int GameID { get; set; }
		public string TeamA { get; set; }
		public string TeamB { get; set; }

		public GamesButtons(string team)
		{
            TeamA = team;
        }
	}
}
