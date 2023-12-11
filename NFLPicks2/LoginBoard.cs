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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            // Perform basic validation, replace with your actual authentication logic
            if (IsValidUser(enteredUsername, enteredPassword))
            {
                // If user is valid, open the main dashboard
                Dashboard mainDashboard = new Dashboard();
                mainDashboard.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private bool IsValidUser(string username, string password)
        {
            return username == "your_username" && password == "your_password";
        }

        private void NFLPicksLoginLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
