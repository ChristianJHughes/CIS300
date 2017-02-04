/* TeamData.cs
 * Created By: Christian Hughes
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.BaseballScores
{
    public class TeamData : IComparable<TeamData>
    {
        //Stores 5 fields from a single line of "TEAMABR.csv".
        private string[] teamField = new string[5];

        /// <summary>
        /// A constructor getting a single line of the data file, and assigning it to the private field "teamField".
        /// </summary>
        /// <param name="fiveFields"></param>
        public TeamData(string[] fiveFields)
        {
            teamField = fiveFields;
        }

        /// <summary>
        /// The team's abbreviation.
        /// </summary>
        public string TeamAbreviation
        {
            get
            {
                return teamField[0];
            }
        }

        /// <summary>
        /// The city or other location in which the team played.
        /// </summary>
        public string Location
        {
            get
            {
                return teamField[1];
            }
        }

        /// <summary>
        /// The team's nickname.
        /// </summary>
        public string Nickname
        {
            get
            {
                return teamField[2];
            }
        }

        /// <summary>
        /// The first year in which the team played in this location.
        /// </summary>
        public string FirstYear
        {
            get
            {
                return teamField[3];
            }
        }

        /// <summary>
        /// The last year in which the team played at this location.
        /// </summary>
        public string LastYear
        {
            get
            {
                return teamField[4];
            }
        }

        /// <summary>
        /// Overwrites the default ToString method, formatting for the combo box.
        /// </summary>
        /// <returns>A string formatted for the combo box.</returns>
        public override string ToString()
        {
            string output = Location + " " + Nickname + " (" + FirstYear + "-" + LastYear + ")";
            return output;
        }

        /// <summary>
        /// Fufills the interface requirements: Compares the current instance to the TeamData being passed in.
        /// </summary>
        /// <param name="t">TeamData to compare to the current TeamData instance.</param>
        /// <returns>Returns an int. Negative if less than, 0 if ewual, positive if more than.</returns>
        public int CompareTo(TeamData t)
        {
            return this.ToString().CompareTo(t.ToString());
        }
    }
}
