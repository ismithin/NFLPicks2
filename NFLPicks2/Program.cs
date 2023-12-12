using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFLPicks2
{
    internal static class Program
    {

        #region TeamInstances
        static string lions =  ("Lions");
        static string bears =  ("Bears");
        static string vikings =  ("Vikings");
        static string packers =  ("Packers");
        static string cowboys =  ("Cowboys");
        static string eagles =  ("Eagles");
        static string commanders =  ("Commanders");
        static string giants =  ("Giants");
        static string buccaneers =  ("Buccaneers");
        static string falcons =  ("Falcons");
        static string panthers =  ("Panthers");
        static string saints =  ("Saints");
        static string rams =  ("Rams");
        static string seahawks =  ("Seahawks");
        static string cardinals =  ("Cardinals");
        static string niners =  ("49ers");
        static string chiefs =  ("Chiefs");
        static string chargers =  ("Chargers");
        static string broncos =  ("Broncos");
        static string raiders =  ("Raiders");
        static string patriots =  ("Patriots");
        static string jets =  ("Jets");
        static string dolphins =  ("Dolphins");
        static string bills =  ("Bills");
        static string steelers =  ("Steelers");
        static string ravens =  ("Ravens");
        static string bengals =  ("Bengals");
        static string browns =  ("Browns");
        static string texans =  ("Texans");
        static string colts =  ("Colts");
        static string titans =  ("Titans");
        static string jaguars =  ("Jaguars");
        #endregion

        static List<string> allstring = new List<string>
        {
            lions, bears, vikings, packers, cowboys, eagles, commanders, giants, buccaneers, falcons, panthers, saints, rams, seahawks, cardinals, niners, chiefs, chargers, broncos, raiders, patriots, jets, dolphins, bills, steelers, ravens, bengals, browns, texans, colts, titans, jaguars
        };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Generate matchups for 18 weeks
            for (int weekNumber = 1; weekNumber <= 18; weekNumber++)
            {
                Weeks week = new Weeks(weekNumber);

                // Shuffle string to create random matchups
                List<string> shuffledstring = new List<string>(allstring);
                shuffledstring.Shuffle(); // Implement a shuffle extension method

                // Generate matchups for the week
                for (int i = 0; i < shuffledstring.Count; i += 2)
                {
                    Matchup matchup = new Matchup(shuffledstring[i], shuffledstring[i + 1]);
                    week.AddMatchup(matchup);
                }

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Start with the login form
            LoginBoard LoginBoard = new LoginBoard();
            Application.Run(LoginBoard);
        }
    }
    #region Shuffle 
    // Extension method to shuffle a list
    static class ListExtensions
    {
        private static Random random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
    #endregion
}
