/* TrieWithManyChildren.cs
 * Author: Rod 
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
    /// A single trie node having 2-26 children.
    /// </summary>
    public class TrieWithManyChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// The children of this node.
        /// </summary>
        private ITrie[] _children = new ITrie[26];

        /// <summary>
        /// Constructs a trie containing (1) the given string; (2) all of the strings in the
        /// given ITrie, with the given char added as a prefix to each; and (3) the empty string
        /// the given bool is true.
        /// </summary>
        /// <param name="s">The string that the trie should include.</param>
        /// <param name="hasEmpty">Indicates whether the trie should contain the empty string.</param>
        /// <param name="childLabel">A label for one of the children of the trie.</param>
        /// <param name="child">The child that should have the above label.</param>
        public TrieWithManyChildren(string s, bool hasEmpty, char childLabel, ITrie child)
        {
            if (childLabel < 'a' || childLabel > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            int index = childLabel - 'a';
            _children[index] = child;
            Add(s);
        }

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
            
            else if (s[0] < 'a' || s[0] > 'z')
            {
                return false;
            }
            else
            {
                int index = s[0] - 'a';
                if (_children[index] == null)
                {
                    return false;
                }
                else
                {
                    return _children[index].Contains(s.Substring(1));
                }
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
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                int index = s[0] - 'a';
                if (_children[index] == null)
                {
                    _children[index] = new TrieWithNoChildren();
                }
                _children[index] = _children[index].Add(s.Substring(1));
            }
            return this;
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
                int index = prefix[0] - 'a';
                if (index < 0 || index > 25 || _children[index] == null)
                {
                    return null;
                }
                else
                {
                    return _children[index].GetCompletions(prefix.Substring(1));
                }
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
            for (int i = 0; i < _children.Length; i++)
            {
                if (_children[i] != null)
                {
                    prefix.Append((char)(i + 'a'));
                    _children[i].AddAll(prefix, list);
                    prefix.Length--;
                }
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
                if (s[0] == '?')
                {
                    for (int i = 0; i < _children.Length; i++)
                    {
                        if (_children[i] != null)
                        {
                            if (_children[i].WildcardSearch(s.Substring(1)) == true)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    int index = s[0] - 'a';
                    if (_children[index] == null)
                    {
                        return false;
                    }
                    else
                    {
                        return _children[index].WildcardSearch(s.Substring(1));
                    }
                }
            }
        }
    }
}
