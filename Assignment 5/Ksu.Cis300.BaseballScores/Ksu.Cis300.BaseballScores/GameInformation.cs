/* GameInformation.cs
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

namespace Ksu.Cis300.BaseballScores
{
    public partial class GameInformation : Form
    {
        /// <summary>
        /// Constructor intitilizes the text boxes on the form that is to be created with the given GameData.
        /// </summary>
        /// <param name="g">GameData that is used to populate the various fields on the form.</param>
        public GameInformation(GameData g)
        {
            InitializeComponent();
            uxHomeScoreTextBox.Text = g.HomeTeamScore;
            uxHomeTextBox.Text = g.HomeTeamLocationAndNickname;
            uxVisitorScoreTextBox.Text = g.VisitingTeamScore;
            uxWinningPitcherTextBox.Text = g.WinningPitcher;
            uxLosingPitcherTextBox.Text = g.LosingPitcher;
            uxVisitorTextBox.Text = g.VisitingTeamLocationAndNickname;
            AssignValues = g;
            uxSaveTextBox.Text = g.PitcherCreditedWithSave;
            uxGameWinningRBITextBox.Text = g.BatterWinningRun;
        }
        
        /// <summary>
        /// Property that puts the proper date on the header of the GameInformation window.
        /// </summary>
        public GameData AssignValues
        {
            set
            {
                this.Text = value.Date.ToShortDateString();
            }
        }
    }
}
