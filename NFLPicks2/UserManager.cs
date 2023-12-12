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

        // Constructor
        public UserManager()
        {
            // Initialize the user list
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

        // Method to add a new user
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
            if (isLogin && existingUser != null && existingUser.Password != password)
            {
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Return null to indicate failure
            }

            // Create a new user and add it to the list during user creation
            User newUser = new User(username, password);
            userList.Add(newUser);

            return newUser; // Return the added user
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

        // Other user-related methods can be added here
    }
}
