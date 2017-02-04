/* TrieWithNoChildren.cs
 * Author: Rod Howell
 * 
 * Modified By: Christian Hughes
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// A single trie node having no chldren.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// If the string contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }

        /// <summary>
        /// Gets all of the strings that form words in this trie when appended to the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <returns>A trie containing all of the strings that form words in this trie when appended
        /// to the given prefix.</returns>
        public ITrie GetCompletions(string prefix)
        {
            if (prefix == "")
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Adds all of the strings in this trie alphabetically to the end of the given list, with each
        /// string prefixed by the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="list">The list to which the strings are to be added.</param>
        public void AddAll(StringBuilder prefix, System.Collections.IList list)
        {
            if (_hasEmptyString)
            {
                list.Add(prefix.ToString());
            }
        }

        /// <summary>
        /// This method accepts strings that include wildcard characters (‘?’). The method 
        /// should return true if the trie contains any word that matches s (where ANY 
        /// character can match the ‘?’ characters), and false otherwise. For example, if s was 
        /// “?a?a?a”, then WildcardSearch should return true because “banana” (and 
        /// possibly other words) is a word in the trie and matches that wildcard search, since 
        /// each ‘?’ can be matched by any letter.
        /// </summary>
        /// <param name="s">A String containing wildcard characters</param>
        /// <returns>True if the try could potentially contain the string passed in.</returns>
        public bool WildcardSearch(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
        }
    }
}
