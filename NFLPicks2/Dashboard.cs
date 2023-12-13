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
    public partial class Dashboard : Form
    {
        private readonly User currentUser;
        private League currentLeague; // Add a field to store the current league
        private List<Button> leagueButtons; // Maintain a list of league buttons
        private List<Button> gameButtons; // Add this list to store Game buttons

        public Dashboard(User user) 
        {
            InitializeComponent();
            currentUser = user;
            // Set the current league to the first league in the user's list
            currentLeague = currentUser.Leagues.FirstOrDefault();
            UpdateUsernameLabel(currentUser);
            LeagueButtonsLabel.Text = "Leagues:";//Just set the label to this
            LeagueNameLabel2.Text = "League Name";//Set label to currently selected league
            // Initialize the list of league buttons
            leagueButtons = new List<Button> { LeagueButton1, LeagueButton2, LeagueButton3, LeagueButton4 };
            gameButtons = new List<Button>
            {
            GameButton1, GameButton2, GameButton3, GameButton4, GameButton5,
            GameButton6, GameButton7, GameButton8, GameButton9, GameButton10,
            GameButton11, GameButton12, GameButton13, GameButton14, GameButton15,
            GameButton16, GameButton17, GameButton18, GameButton19, GameButton20,
            GameButton21, GameButton22, GameButton23, GameButton24
            };
            // Initialize game buttons
            InitializeGameButtons();
            // Load user's leagues into buttons
            SetupLeagueButtons();
            // Attach the event handler for the SelectedIndexChanged event of your dropdown
            WeeksComboBox.SelectedIndexChanged += WeeksComboBox_SelectedIndexChanged;
            PopulateWeeksComboBox();
            LoadMatchupButtons(GetSelectedWeekNumber());
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
        private void LogoutButton1_Click(object sender, EventArgs e)
        {
            // Close the current dashboard form
            this.Close();
            // Show the login form
            LoginBoard loginForm = new LoginBoard();
            loginForm.Show();
        }
        #region Update Objects
        private void UpdateUsernameLabel(User currentUser)
        {
            UsernameLabel.Text = currentUser.Username;
        }
        private void UpdateLeagueNameLabel()
        {
            LeagueNameLabel2.Text = currentLeague?.LeagueName ?? "League Name";
        }
        #endregion

        #region League Buttons
        private void LeagueButton1_Click(object sender, EventArgs e)
        {
            // Handle click for LeagueButton1
            HandleLeagueButtonClick(LeagueButton1);
            UpdateLeagueButtons();
        }
        private void LeagueButton2_Click(object sender, EventArgs e)
        {
            // Handle click for LeagueButton2
            HandleLeagueButtonClick(LeagueButton2);
            UpdateLeagueButtons();
        }
        private void LeagueButton3_Click(object sender, EventArgs e)
        {
            // Handle click for LeagueButton3
            HandleLeagueButtonClick(LeagueButton3);
            UpdateLeagueButtons();
        }
        private void LeagueButton4_Click(object sender, EventArgs e)
        {
            // Handle click for LeagueButton4
            HandleLeagueButtonClick(LeagueButton4);
            UpdateLeagueButtons();
        }
        private void HandleLeagueButtonClick(Button button)
        {
            // Logic for handling league button click
            // You can use 'button' to identify which league button was clicked
            // and perform the necessary actions.
            currentLeague = currentUser.Leagues.FirstOrDefault(league => league.LeagueName == button.Text);
            UpdateLeagueNameLabel();
            UpdateLeagueButtons();
            ResetButtonColors();
        }
        private void UpdateLeagueButtons()
        {
            // Update the appearance of the league buttons based on the user's leagues
            for (int i = 0; i < leagueButtons.Count; i++)
            {
                if (i < currentUser.Leagues.Count)
                {
                    // Set the text of the button to the league name
                    leagueButtons[i].Text = currentUser.Leagues[i].LeagueName;

                    // Highlight the button if it corresponds to the current league
                    leagueButtons[i].BackColor = (currentUser.Leagues[i] == currentLeague) ? Color.LightGreen : Color.Transparent;

                    // Make the button visible
                    leagueButtons[i].Visible = true;
                }
                else
                {
                    // Hide the button if there is no corresponding league
                    leagueButtons[i].Visible = false;
                }
            }

            // Update the visibility of create/join/leave league buttons
            CreateLeagueButton.Visible = currentUser.Leagues.Count < 4;
            JoinLeagueButton.Visible = currentUser.Leagues.Count < 4;
            LeaveLeagueButton.Visible = currentUser.Leagues.Count > 0;
        }
        private void SetupLeagueButtons()
        {
            int i = 0;
            foreach (League league in currentUser.Leagues)
            {
                if (i < leagueButtons.Count)
                {
                    // Display the button and set its text to the league name
                    leagueButtons[i].Visible = true;
                    leagueButtons[i].Text = league.LeagueName;
                    i++;
                }
            }

            // Hide any remaining buttons
            for (; i < leagueButtons.Count; i++)
            {
                leagueButtons[i].Visible = false;
            }
            UpdateLeagueButtons();
        }
        private void CreateLeagueButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt the user for a new league name using the LeagueBoard
                using (var leagueBoard = new LeagueBoard("Enter the name for the new league:", currentUser))
                {
                    void closedHandler(object s, FormClosedEventArgs args)
                    {
                        // Unsubscribe from the event to avoid multiple updates
                        leagueBoard.FormClosed -= closedHandler;

                        // Update league buttons
                    }

                    leagueBoard.FormClosed += closedHandler;
                    if (leagueBoard.ShowDialog() == DialogResult.OK)
                    {
                        // User clicked ConfirmButton in LeagueBoard
                        string leagueName = leagueBoard.LeagueName;

                        // The league creation and joining logic is now in LeagueForm
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            currentLeague = currentUser.Leagues.FirstOrDefault();
            UpdateLeagueButtons();
            UpdateLeagueNameLabel();
        }
        private void JoinLeagueButton_Click(object sender, EventArgs e)
        {
            // Prompt the user for the league name they want to join using the LeagueBoard
            using (var leagueBoard = new LeagueBoard("Enter the name of the league you want to join:", currentUser))
            {
                leagueBoard.FormClosed += (s, args) => { UpdateLeagueButtons(); };

                if (leagueBoard.ShowDialog() == DialogResult.OK)
                {
                    // User clicked ConfirmButton in LeagueBoard
                    string leagueName = leagueBoard.LeagueName;

                    // The league joining logic is now in LeagueForm
                }
            }
            HandleLeagueButtonClick(LeagueButton1);
        }
        private void LeaveLeagueButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the user is currently in a league
                if (currentLeague != null)
                {
                    // Prompt the user for confirmation
                    DialogResult result = MessageBox.Show($"Are you sure you want to leave the league '{currentLeague.LeagueName}'?",
                                                          "Leave League",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    // If the user confirms, leave the league
                    if (result == DialogResult.Yes)
                    {
                        // Leave the current league
                        currentUser.LeaveLeague(currentLeague);

                        // Display a message or update UI accordingly
                        MessageBox.Show($"You have left the league '{currentLeague.LeagueName}'.");

                        // Find the next league in the user's list or default to the first league
                        currentLeague = currentUser.Leagues.FirstOrDefault();

                        // Update the league buttons on the UI
                        UpdateLeagueButtons();

                        // Update other parts of the UI as needed
                        UpdateLeagueNameLabel(); // Update the league name label

                        // Load the initial matchup buttons for the default week
                        LoadMatchupButtons(GetSelectedWeekNumber());
                    }
                }
                else
                {
                    // Display a message indicating that the user is not currently in a league
                    MessageBox.Show("You are not currently in a league.", "Leave League", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Game Buttons
        private void WeeksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load the matchup buttons for the selected week
            LoadMatchupButtons(GetSelectedWeekNumber());
        }
        private void PopulateWeeksComboBox()
        {
            // Set the DataSource property to your list of weeks
            WeeksComboBox.DataSource = Weeks.GetAllWeeks();

            // Set the DisplayMember to the property you want to display in the combo box
            WeeksComboBox.DisplayMember = "WeekNumber";
        }
        private int GetSelectedWeekNumber()
        {
            // Check if any item is selected
            if (WeeksComboBox.SelectedItem != null)
            {
                // Assuming your dropdown is bound to a list of Weeks
                if (WeeksComboBox.SelectedItem is Weeks selectedWeek)
                {
                    return selectedWeek.WeekNumber;
                }
            }

            // If no item is selected or the cast fails, return a default value (e.g., week 1)
            return 1;
        }
        private void InitializeGameButtons()
        {
            int buttonNumber = 1;

            foreach (var button in gameButtons)
            {
                button.Tag = buttonNumber;
                button.Text = $"Team {buttonNumber}";
                button.Click += GameButton_Click;
                buttonNumber++;
            }
        }
        private void LoadMatchupButtons(int weekNumber)
        {
            // Get the matchups for the specified week
            Weeks currentWeek = Weeks.GetWeekByNumber(weekNumber);

            if (currentWeek != null)
            {
                // Load team names onto the Game buttons
                for (int i = 0; i < gameButtons.Count; i+=2)
                {
                    Button teamButtonA = gameButtons[i];
                    Button teamButtonB = gameButtons[i+1];

                    // Set the text of the buttons to the team names
                    teamButtonA.Text = currentWeek.Matchups[i/2].TeamA;
                    teamButtonB.Text = currentWeek.Matchups[i/2].TeamB;
                }
            }
        }
        private void GameButton_Click(object sender, EventArgs e)
        {
            // This event handler will be triggered when any game button is clicked
            // You can use 'sender' to identify which button was clicked
            if (sender is Button clickedButton)
            {
                int buttonNumber = (int)clickedButton.Tag;

                // Assuming buttonNumber corresponds to a matchup number
                int currentMatchupNumber = (buttonNumber + 1) / 2;  // Convert buttonNumber to matchupNumber

                // Get the selected team from the user
                string selectedTeam = gameButtons[buttonNumber - 1].Text;

                // Save the selected team for the specific matchup in the current week for the current league
                currentUser.WinnerSelections[currentLeague].SelectTeam(GetSelectedWeekNumber(), currentMatchupNumber, selectedTeam);

                // Highlight the selected button and unhighlight the other button in the same matchup
                HighlightSelectedButton(currentMatchupNumber, clickedButton);

                // If PicksCheckBox1 is checked, select the team for every league
                if (PicksCheckBox1.Checked)
                {
                    foreach (League league in currentUser.Leagues)
                    {
                        // Call the WinnerSelection class to store the selected team for this league
                        currentUser.WinnerSelections[league].SelectTeam(GetSelectedWeekNumber(), currentMatchupNumber, selectedTeam);
                    }
                }
            }
        }
        public void ResetButtonColors()
        {
            foreach (Button button in gameButtons)
            {
                // Get the button's matchup number from the Tag property
                if (button.Tag is int buttonNumber)
                {
                    int matchupNumber = (buttonNumber + 1) / 2;  // Convert buttonNumber to matchupNumber

                    // Get the selected team for this matchup in the currently selected league
                    string selectedTeam = currentUser.WinnerSelections[currentLeague].GetSelectedTeam(GetSelectedWeekNumber(), matchupNumber);

                    // Set the button color based on the selected team
                    button.BackColor = (button.Text == selectedTeam) ? Color.LightGreen : Color.Transparent;
                }
            }
        }
        private void HighlightSelectedButton(int matchupNumber, Button selectedButton)
        {
            // Iterate through the buttons for the same matchup
            for (int i = (matchupNumber - 1) * 2; i < matchupNumber * 2; i++)
            {
                Button button = gameButtons[i];
                // Highlight the selected button, unhighlight others
                button.BackColor = (button == selectedButton) ? Color.LightGreen : Color.Transparent;
            }
        }
        #endregion
    }
}
