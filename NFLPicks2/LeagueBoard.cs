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
    public partial class LeagueBoard : Form
    {
        public string LeagueName { get; private set; }
        User currentUser;

        public LeagueBoard(string instruction, User user)
        {
            InitializeComponent();
            currentUser = user;
            InstructionLabel.Text = instruction;
        }
        private void LeagueBoardButton1_Click(object sender, EventArgs e)
        {
            // Set the LeagueName property and close the form
            // Set the LeagueName property
            LeagueName = LeagueNameTextBox.Text;

            // Join the league before closing the form
            currentUser.JoinLeague(new League(LeagueName));

            // Close the form
            Close();
        }
    }
}
