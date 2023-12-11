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
        private User currentUser;
        private League currentLeague; // Add a field to store the current league
        private List<Button> leagueButtons; // Maintain a list of league buttons
        private List<Button> gameButtons; // Add this list to store Game buttons
        private static List<Weeks> allWeeks = new List<Weeks>();

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
            InitializeGameButtons();

            // Load user's leagues into buttons
            SetupLeagueButtons();
            // Attach the event handler for the SelectedIndexChanged event of your dropdown
            WeeksComboBox.SelectedIndexChanged += WeeksComboBox_SelectedIndexChanged;
            // Populate the WeeksComboBox with week numbers or objects containing week information
            PopulateWeeksComboBox();

            // Load the initial matchup buttons for the default week
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
        private void WeeksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load the matchup buttons for the selected week
            LoadMatchupButtons(GetSelectedWeekNumber());
        }
        private void PopulateWeeksComboBox()
        {
            // Set the DataSource property to your list of weeks
            WeeksComboBox.DataSource = allWeeks;

            // Set the DisplayMember to the property you want to display in the combo box
            WeeksComboBox.DisplayMember = "WeekNumber";
        }
        private int GetSelectedWeekNumber()
        {
            // Check if any item is selected
            if (WeeksComboBox.SelectedItem != null)
            {
                // Assuming your dropdown is bound to week numbers
                return (int)WeeksComboBox.SelectedItem;
            }

            // If no item is selected, return a default value (e.g., week 1)
            return 1;
        }
        private Weeks GetWeekByNumber(int weekNumber)
        {
            // Assuming you have a List<Weeks> to store all the weeks
            return allWeeks.FirstOrDefault(week => week.WeekNumber == weekNumber);
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
                    leagueButtons[i].BackColor = (currentUser.Leagues[i] == currentLeague) ? Color.LightBlue : Color.Transparent;

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
        }
        private void CreateLeagueButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt the user for a new league name using the LeagueBoard
                using (var leagueBoard = new LeagueBoard("Enter the name for the new league:", currentUser))
                {
                    FormClosedEventHandler closedHandler = null;
                    closedHandler = (s, args) =>
                    {
                        // Unsubscribe from the event to avoid multiple updates
                        leagueBoard.FormClosed -= closedHandler;

                        // Update league buttons
                        UpdateLeagueButtons();
                    };

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
        }
        private League FindLeagueByName(User user, string leagueName)
        {
            // Helper method to find a league by name within a user's leagues
            return user.Leagues.FirstOrDefault(league => league.LeagueName == leagueName);
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
        private Button GetGameButton(int buttonNumber)
        {
            // Assuming you have a List<Button> to store all the Game buttons
            return gameButtons.FirstOrDefault(button => button.Tag?.ToString() == buttonNumber.ToString());
        }
        private void InitializeGameButtons()
        {
            int buttonNumber = 1; // Start with 1 or adjust as needed

            foreach (var button in gameButtons)
            {
                button.Tag = buttonNumber;
                button.Text = $"Team {buttonNumber}";
                button.Click += GameButton_Click;
                buttonNumber++;
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            // This event handler will be triggered when any game button is clicked
            // You can use 'sender' to identify which button was clicked
            if (sender is Button clickedButton)
            {
                int buttonNumber = (int)clickedButton.Tag;
                // Perform actions based on the clicked button (buttonNumber)
                // ...
            }
        }

        private void LoadMatchupButtons(int weekNumber)
        {
            // Get the matchups for the specified week
            Weeks currentWeek = GetWeekByNumber(weekNumber);

            if (currentWeek != null)
            {
                List<Matchup> matchups = currentWeek.Matchups;

                // Load team names onto the Game buttons
                for (int i = 0; i < matchups.Count; i++)
                {
                    Button teamButtonA = GetGameButton(i * 2 + 1); // Assumes buttons are numbered 1, 3, 5, ...
                    Button teamButtonB = GetGameButton(i * 2 + 2); // Assumes buttons are numbered 2, 4, 6, ...

                    // Set the text of the buttons to the team names
                    teamButtonA.Text = matchups[i].TeamA;
                    teamButtonB.Text = matchups[i].TeamB;
                }
            }
        }

        #endregion


    }
}
