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
        private readonly User currentUser;

        public LeagueBoard(string instruction, User user)
        {
            InitializeComponent();
            currentUser = user;
            InstructionLabel.Text = instruction;
        }

        private void LeagueBoardButton1_Click(object sender, EventArgs e)
        {
            // Set the LeagueName property
            LeagueName = LeagueNameTextBox.Text;

            if (LeagueManager.DoesLeagueExist(LeagueName))
            {
                // League exists, join the league before closing the form
                currentUser.JoinLeague(new League(LeagueName));
            }
            else
            {
                // League doesn't exist, create it and then join
                League newLeague = new League(LeagueName);
                currentUser.JoinLeague(newLeague);

                // Add the league to the existing leagues
                LeagueManager.AddLeague(LeagueName);
            }
            currentUser.IsLeagueAdmin = true;


            // Close the form
            Close();
        }
    }
}

