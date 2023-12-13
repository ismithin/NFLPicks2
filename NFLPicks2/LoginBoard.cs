using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFLPicks2
{
    public partial class LoginBoard : Form
    {
        private User loggedInUser;
        public LoginBoard()
        {
            InitializeComponent();
        }

        private void LoginButton1_Click(object sender, EventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            // Perform basic validation, replace with your actual authentication logic
            if (string.IsNullOrEmpty(enteredUsername))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Try to log in the user
                User loggedInUser = UserManager.Instance.AddUser(enteredUsername, enteredPassword, isLogin: true);

                if (loggedInUser != null)
                {
                    // If login is successful, show the dashboard
                    Dashboard mainDashboard = new Dashboard(loggedInUser);
                    mainDashboard.Show();
                    this.Hide(); // Hide the login form
                }
            }
        }

        private bool IsValidUser(string username, string password)
        {
            List<User> allUsers = UserManager.Instance.GetUsers();
            return allUsers.Any(user => user.Username == username && user.Password == password);
        }
    }
}
