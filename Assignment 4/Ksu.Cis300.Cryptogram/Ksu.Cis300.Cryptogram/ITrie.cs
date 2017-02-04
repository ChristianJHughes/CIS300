/* ITrie.cs
 * Author: Rod Howell
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// An interface for a trie.
    /// </summary>
    public interface ITrie
    {
        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        bool Contains(string s);

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// If the string contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        ITrie Add(string s);

        /// <summary>
        /// Gets all of the strings that form words in this trie when appended to the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <returns>A trie containing all of the strings that form words in this trie when appended
        /// to the given prefix.</returns>
        ITrie GetCompletions(string prefix);

        /// <summary>
        /// Adds all of the strings in this trie alphabetically to the end of the given list, with each
        /// string prefixed by the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="list">The list to which the strings are to be added.</param>
        void AddAll(StringBuilder prefix, IList list);

        /// <summary>
        /// This method accepts strings that include wildcard characters (‘?’). The method 
        /// should return true if the trie contains any word that matches s (where ANY 
        /// character can match the ‘?’ characters), and false otherwise. For example, if s was 
        /// “?a?a?a”, then WildcardSearch should return true because “banana” (and 
        /// possibly other words) is a word in the trie and matches that wildcard search, since         /// each ‘?’ can be matched by any letter.
        /// </summary>
        /// <param name="s">A String containing wildcard characters</param>
        /// <returns>True if the try could potentially contain the string passed in.</returns>
        bool WildcardSearch(string s);
    }
}
