/* GameData.cs
 * Created By: Christian Hughes
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.BaseballScores
{
    public class GameData
    {
        //Contains the 101 fields from a single line of the game log.
        private string[] gameLogData = new string[101];

        //Contains the data for all of the teams
        private Dictionary<string, TeamData> allData = new Dictionary<string,TeamData>();

        public GameData(string[] gameLogFields, Dictionary<string, TeamData> dict)
        {
            gameLogData = gameLogFields;
            allData = dict;
        }

        /// <summary>
        /// The date of the game. This needs to be of type DateTime.
        /// </summary>
        public DateTime Date
        {
            get
            {
                int year = Convert.ToInt32(gameLogData[0].Substring(0, 4));
                int month = Convert.ToInt32(gameLogData[0].Substring(4, 2));
                int day = Convert.ToInt32(gameLogData[0].Substring(6, 2));
                DateTime temp = new DateTime(year, month, day);
                return temp;
            }
        }

        /// <summary>
        /// A string containing the home team's location and nickname, seperated by a space.
        /// </summary>
        public string HomeTeamLocationAndNickname
        {
            get
            {
                string output = allData[HomeTeamAbbreviation].Location + " " + allData[HomeTeamAbbreviation].Nickname;
                return output;
            }
        }

        /// <summary>
        /// The home team's abbreviation.
        /// </summary>
        public string HomeTeamAbbreviation
        {
            get
            {
                return gameLogData[6];
            }
        }

        /// <summary>
        /// The home team's score.
        /// </summary>
        public string HomeTeamScore
        {
            get
            {
                return gameLogData[10];
            }
        }

        /// <summary>
        /// A string containing the visiting team's location and nickname, sperated by a space.
        /// </summary>
        public string VisitingTeamLocationAndNickname
        {
            get
            {
                string output = allData[VisitingTeamAbbreviation].Location + " " + allData[VisitingTeamAbbreviation].Nickname;
                return output;
            }
        }

        /// <summary>
        /// The visiting team's abbreviation.
        /// </summary>
        public string VisitingTeamAbbreviation
        {
            get
            {
                return gameLogData[3];
            }
        }

        /// <summary>
        /// The visiting team's score.
        /// </summary>
        public string VisitingTeamScore
        {
            get
            {
                return gameLogData[9];
            }
        }

        /// <summary>
        /// The winning pitcher.
        /// </summary>
        public string WinningPitcher
        {
            get
            {
                return gameLogData[94];
            }
        }

        /// <summary>
        /// The losing pitcher.
        /// </summary>
        public string LosingPitcher
        {
            get
            {
                return gameLogData[96];
            }
        }

        /// <summary>
        /// The pitcher credited with a save.
        /// </summary>
        public string PitcherCreditedWithSave
        {
            get
            {
                return gameLogData[98];
            }
        }

        /// <summary>
        /// The batter who drove in the game-winning run.
        /// </summary>
        public string BatterWinningRun
        {
            get
            {
                return gameLogData[100];
            }
        }
    }
}
