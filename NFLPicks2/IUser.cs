using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        void JoinLeague(League league);
        void LeaveLeague(League league);
        void IsLeagueAdminSet();
    }
}
