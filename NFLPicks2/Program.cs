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
        static Teams lions = new Teams("Lions");
        static Teams bears = new Teams("Bears");
        static Teams vikings = new Teams("Vikings");
        static Teams packers = new Teams("Packers");
        static Teams cowboys = new Teams("Cowboys");
        static Teams eagles = new Teams("Eagles");
        static Teams commanders = new Teams("Commanders");
        static Teams giants = new Teams("Giants");
        static Teams buccaneers = new Teams("Buccaneers");
        static Teams falcons = new Teams("Falcons");
        static Teams panthers = new Teams("Panthers");
        static Teams saints = new Teams("Saints");
        static Teams rams = new Teams("Rams");
        static Teams seahawks = new Teams("Seahawks");
        static Teams cardinals = new Teams("Cardinals");
        static Teams niners = new Teams("49ers");
        static Teams chiefs = new Teams("Chiefs");
        static Teams chargers = new Teams("Chargers");
        static Teams broncos = new Teams("Broncos");
        static Teams raiders = new Teams("Raiders");
        static Teams patriots = new Teams("Patriots");
        static Teams jets = new Teams("Jets");
        static Teams dolphins = new Teams("Dolphins");
        static Teams bills = new Teams("Bills");
        static Teams steelers = new Teams("Steelers");
        static Teams ravens = new Teams("Ravens");
        static Teams bengals = new Teams("Bengals");
        static Teams browns = new Teams("Browns");
        static Teams texans = new Teams("Texans");
        static Teams colts = new Teams("Colts");
        static Teams titans = new Teams("Titans");
        static Teams jaguars = new Teams("Jaguars");
        #endregion

        static List<Teams> allTeams = new List<Teams>
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

                // Shuffle teams to create random matchups
                List<Teams> shuffledTeams = new List<Teams>(allTeams);
                shuffledTeams.Shuffle(); // Implement a shuffle extension method

                // Generate matchups for the week
                for (int i = 0; i < shuffledTeams.Count; i += 2)
                {
                    Matchup matchup = new Matchup(shuffledTeams[i], shuffledTeams[i + 1]);
                    week.AddMatchup(matchup);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
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
