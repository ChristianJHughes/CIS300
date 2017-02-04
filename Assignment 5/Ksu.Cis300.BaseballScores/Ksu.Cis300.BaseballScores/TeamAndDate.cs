/* TeamAndDate.cs
 * Created By: Christian Hughes
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.BaseballScores
{
    struct TeamAndDate
    {
        //Contains team abreviation.
        private string abbreviation;

        //Contains date of game.
        private DateTime date;

        //The hash code for the stucture.
        private int _hashCode;

        /// <summary>
        /// A constructor initializing the team abbreviation and date fields. 
        /// </summary>
        /// <param name="abbreviationParam"></param>
        /// <param name="dateParam"></param>
        public TeamAndDate(string abbreviationParam, DateTime dateParam)
        {
            abbreviation = abbreviationParam;
            date = dateParam;
            _hashCode = 0;
            unchecked
            {
                _hashCode *= 39;
                _hashCode += abbreviation[0];
                _hashCode *= 39;
                _hashCode += abbreviation[1];
                _hashCode *= 39;
                _hashCode += abbreviation[2];
                _hashCode *= 39;
                _hashCode += date.Year;
                _hashCode *= 39;
                _hashCode += date.Month;
                _hashCode *= 39;
                _hashCode += date.Day;
            }
        }

        /// <summary>
        /// Gets the hash code computed in the constructor.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _hashCode;
        }

        /// <summary>
        /// Compares two TeamAndDate instances for equality.
        /// </summary>
        /// <param name="x">The first TeamAndDate object.</param>
        /// <param name="y">The second TeamAndDate object.</param>
        /// <returns>Returns true if the objects are equal.</returns>
        public static bool operator ==(TeamAndDate x, TeamAndDate y)
        {
            if (x.abbreviation != y.abbreviation || x.date.Year != y.date.Year || x.date.Month != y.date.Month || x.date.Day != y.date.Day)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Computes wheter or not the given objects are not equal.
        /// </summary>
        /// <param name="x">The first TeamAndDate object.</param>
        /// <param name="y">The second TeamAndDate object.</param>
        /// <returns>True if the two objects are not equal.</returns>
        public static bool operator !=(TeamAndDate x, TeamAndDate y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Compares two TeamAndDate instances for equality.
        /// </summary>
        /// <param name="obj">The object being compared to the current object.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TeamAndDate)
            {
                return this == (TeamAndDate)obj;
            }
            else
            {
                return false;
            }
        }

    }
}
