using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLPicks2
{
    public class User
    {
        // Attributes
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public string Avatar { get; set; }
    }

    // Constructors
    public User()
    {
        // Default constructor
    }

    public User(int userID, string username, string password, string email, string avatar)
    {
        UserID = userID;
        Username = username;
        Password = password;
        Email = email;
        //Avatar = avatar;
    }
}
