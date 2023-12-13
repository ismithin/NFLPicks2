using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NFLPicks2
{
    public class UserManager
    {
        private static UserManager instance;
        private List<User> userList;
        public UserManager()
        {
            userList = new List<User>();
        }
        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }
        public User AddUser(string username, string password, bool isLogin = false)
        {
            // Check if the username is already taken during user creation
            if (!isLogin && userList.Exists(user => user.Username == username))
            {
                MessageBox.Show("Username is already taken. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Return null to indicate failure
            }

            // For login, check if the username exists and the password is correct
            User existingUser = GetUserByUsername(username);
            if (isLogin)
            {
                if (existingUser == null)
                {
                    // If the username doesn't exist during login, create a new user
                    existingUser = new User(username, password);
                    userList.Add(existingUser);
                }
                else if (existingUser.Password != password)
                {
                    MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null; // Return null to indicate failure
                }
            }

            // If the code reaches here, it means the user is successfully logged in or created
            return existingUser;
        }
        // Method to retrieve all users
        public List<User> GetUsers()
        {
            return userList;
        }
        public User GetUserByUsername(string username)
        {
            return userList.FirstOrDefault(user => user.Username == username);
        }
    }
}
