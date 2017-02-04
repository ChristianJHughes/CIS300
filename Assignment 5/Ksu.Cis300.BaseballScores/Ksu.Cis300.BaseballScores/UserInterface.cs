/* UserInterface.cs
 * Created By: Christian Hughes
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.BaseballScores
{
    public partial class UserInterface : Form
    {
        //A Dictionary<string, TeamData> to store the information on each team from the "TEAMABR.csv" file.
        private Dictionary<string, TeamData> _teamInformation = new Dictionary<string,TeamData>();

        //A HashSet<string> to store the abbreviation of each team that has been added to the ComboBox.
        private HashSet<string> _abbreviationsUsed = new HashSet<string>();

        //A Dictionary<TeamAndDate, List<GameData>> to store the information on each game from the game logs that have been read.
        private Dictionary<TeamAndDate, List<GameData>> _gameInformation = new Dictionary<TeamAndDate,List<GameData>>();

        /// <summary>
        /// A constructor for the user interface. It reads in the inital team information.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("TEAMABR.csv");
            while (sr.EndOfStream != true)
            {
                string currentLine = sr.ReadLine();
                string[] sArray = new string[5];
                sArray = currentLine.Split(',');
                TeamData tData = new TeamData(sArray);
                _teamInformation.Add(sArray[0], tData);
            }
        }

        /// <summary>
        /// Loads the user interface, and disables some of the controls that require proper data input (from a file).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            uxComboBox.Enabled = false;
            uxGetGameResultsButton.Enabled = false;
        }

        /// <summary>
        /// Reads in a file containing game data, and adds it to a hash table for search purposes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddDataFileButton_Click(object sender, EventArgs e)
        {

            bool gotData = false;
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(uxOpenFileDialog.FileName);
                    while (sr.EndOfStream != true)
                    {
                        int counter = 0;
                        string[] allFields = new string[101];
                        string currentLine = sr.ReadLine();
                        while (counter != 101)
                        {
                            if (currentLine[0] == '"')
                            {
                                currentLine = currentLine.Substring(1);
                                int nextQuoteIndex = currentLine.IndexOf('"');
                                string field = currentLine.Substring(0, nextQuoteIndex);
                                allFields[counter] = field;
                                currentLine = currentLine.Substring(nextQuoteIndex + 2);
                                counter++;
                            }
                            else
                            {
                                int nextCommaIndex = currentLine.IndexOf(',');
                                string field = currentLine.Substring(0, nextCommaIndex);
                                allFields[counter] = field;
                                currentLine = currentLine.Substring(nextCommaIndex + 1);
                                counter++;
                            }
                        }
                        GameData currentLineData = new GameData(allFields, _teamInformation);
                        TeamAndDate homeTeam = new TeamAndDate(currentLineData.HomeTeamAbbreviation, currentLineData.Date);
                        TeamAndDate awayTeam = new TeamAndDate(currentLineData.VisitingTeamAbbreviation, currentLineData.Date);

                        if (_abbreviationsUsed.Contains(currentLineData.HomeTeamAbbreviation) != true)
                        {
                            _abbreviationsUsed.Add(currentLineData.HomeTeamAbbreviation);
                            uxComboBox.Items.Add(_teamInformation[currentLineData.HomeTeamAbbreviation]);
                            gotData = true;
                            uxComboBox.Enabled = true;
                            uxGetGameResultsButton.Enabled = true;
                            

                        }
                        else if (_abbreviationsUsed.Contains(currentLineData.VisitingTeamAbbreviation) != true)
                        {
                            _abbreviationsUsed.Add(currentLineData.VisitingTeamAbbreviation);
                            uxComboBox.Items.Add(_teamInformation[currentLineData.VisitingTeamAbbreviation]);
                            gotData = true;
                            uxComboBox.Enabled = true;
                            uxGetGameResultsButton.Enabled = true;
                            
                        }

                        if (_gameInformation.ContainsKey(homeTeam))
                        {
                            _gameInformation[homeTeam].Add(currentLineData);
                        }
                        else
                        {
                            List<GameData> temp = new List<GameData>();
                            temp.Add(currentLineData);
                            _gameInformation.Add(homeTeam, temp);
                        }
                        
                        if (_gameInformation.ContainsKey(awayTeam))
                        {
                            _gameInformation[awayTeam].Add(currentLineData);
                        }
                        else
                        {
                            List<GameData> temp = new List<GameData>();
                            temp.Add(currentLineData);
                            _gameInformation.Add(awayTeam, temp);
                        }
                    }
                    uxComboBox.SelectedIndex = 0;
                }
                catch (Exception ee)
                {
                    MessageBox.Show("The following error has occured:\r\n" + ee.ToString());
                    if (gotData == true)
                    {
                        uxComboBox.SelectedIndex = 0;
                    }
                }
               
            }
        }

        /// <summary>
        /// The button spawns a new window containing Game Information for the given team on the given date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxGetGameResultsButton_Click(object sender, EventArgs e)
        {
            TeamData currentTeamData = (TeamData)uxComboBox.SelectedItem;
            DateTime currentDateTime = uxDatePicker.Value;
            TeamAndDate currentTeamAndDate = new TeamAndDate(currentTeamData.TeamAbreviation, currentDateTime);

            if (_gameInformation.ContainsKey(currentTeamAndDate) == true)
            {
                List<GameData> allGamesFound = _gameInformation[currentTeamAndDate];

                for (int i = 0; i < allGamesFound.Count; i++)
                {
                    GameInformation GI = new GameInformation(allGamesFound[i]);
                    GI.Show();
                }
            }
            else
            {
                MessageBox.Show("No results for that team on that date.");
            }
        }
    }
}
