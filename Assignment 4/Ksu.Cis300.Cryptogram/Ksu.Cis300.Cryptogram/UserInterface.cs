/* UserInterface.cs
 * By: Christian Hughes
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
using Ksu.Cis300.WordLookup;
using System.IO;

namespace Ksu.Cis300.Cryptogram
{
    public partial class UserInterface : Form
    {
        //Initialize a new instance of the dictionary.
        private ITrie _dictionary = new TrieWithNoChildren();

        public UserInterface()
        {
            InitializeComponent();
            

            try
            {
                using (StreamReader input = File.OpenText("dictionary.txt"))
                {
                    while (!input.EndOfStream)
                    {
                        string word = input.ReadLine();
                        _dictionary = _dictionary.Add(word);
                    }
                }
                MessageBox.Show("Dictionary successfully read.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// The click event for uxOpenFileButton. Reads in a user selected file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenFileButton_Click(object sender, EventArgs e)
        {
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader input = File.OpenText(uxOpenFileDialog.FileName))
                    {
                        uxInputTextbox.Text = "";
                        while (!input.EndOfStream)
                        {
                            string word = input.ReadLine();
                            uxInputTextbox.Text = word;
                        }
                    }
                    MessageBox.Show("File successfully read.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// A method to decrypt a user seleced cryptogram.
        /// </summary>
        /// <param name="cipher">The Words of the encrypted message.</param>
        /// <param name="partial">The current partial solution to the cipher, 
        /// where each element corresponds to the current partial solution of the 
        /// corresponding element in cipher. Words in partial will have ? for characters 
        /// that have not been decrypted yet, and will have lowercase values for characters 
        /// that have been decrypted. The values in partial will be consistent as a 
        /// possible solution to the cipher (so if two of the same letter appear in cipher, 
        /// and those corresponding letters have been decrypted in partial, they will         /// have the same decrypted values).</param>
        /// <param name="alphaUsed">– a size-26 array that keeps track of which lowercase 
        /// letters have been used in the decryption. Spot 0 corresponds to ‘a’, spot 1 
        /// corresponds to ‘b’, etc. For each non-‘?’ character in partial, that 
        /// corresponding position in alphaUsed will be true.</param>
        /// <returns></returns>
        private bool Decrypt(string[] cipher, StringBuilder[] partial, bool[] alphaUsed)
        {
            //Checks to see if the cipher has been solved.
            if (InDictionary(partial) && NoQuestionMarks(partial))
            {
                return true;
            }

            //Loops to make sure that a valid word can be formed. 
            for (int i = 0; i < partial.Length; i++)
            {
                if (_dictionary.WildcardSearch(partial[i].ToString()) == false)
                {
                    return false;
                }
            }

                        //First Location of a question mark in partial. 
                        int[] indexes = FindNextQuestionMark(partial);

                        //Assign that location to word/char indexes.
                        int wordIndex = indexes[0];
                        int charIndex = indexes[1];

                        //Look through each letter in alphaUsed to see if it is unused.
                        for (int counter = 0; counter < alphaUsed.Length; counter++)
                        {
                            //If said letter is unused...
                            if (alphaUsed[counter] == false)
                            {
                                //Determine what lowercase letter is represented, and assign it to l.
                                char l = (char)('a' + counter);

                                //Find the ciphertext value, v, (in cipher) in that same word and character position
                                char v = cipher[wordIndex][charIndex];

                                //For all such occurrences of v in cipher, replace the corresponding location in partial with l.
                                Substitute(cipher, partial, v, l);
                                alphaUsed[counter] = true;

                                //Recursively call Decrypt with that substitution...
                                if (!Decrypt(cipher, partial, alphaUsed))
                                {
                                    //If necessary, backtrack by undoing the recent substitution
                                    UndoReplace(partial, l);
                                    alphaUsed[counter] = false;
                                }
                                else
                                {
                                    //Returns true if the puzzle has been solved.
                                    return true;
                                }
                             
                                
                            }
                        }
                        return false;
        }


        /// <summary>
        /// Checks to see if the current word int the array is in the dictionary.
        /// </summary>
        /// <param name="partial">StringBuilder containing the words in question.</param>
        /// <returns>True if ALL words are in the dictionary.</returns>
        private bool InDictionary(StringBuilder[] partial)
        {
            for (int i = 0; i < partial.Length; i++)
            {
                if (!_dictionary.Contains(partial[i].ToString()))
                {
                    return false;
                }
            }
            return true;
            
        }

        /// <summary>
        /// Returns if the given StringBuilder[] has question marks. 
        /// </summary>
        /// <param name="partial">StringBuilder containing the words in question.</param>
        /// <returns>True if NO question marks are present in the words.</returns>
        private bool NoQuestionMarks(StringBuilder[] partial)
        {
            for (int i = 0; i < partial.Length; i++)
            {
                for (int j = 0; j < partial[i].Length; j++)
                {
                    if (partial[i][j] == '?')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Backtracks on any substitutions that did not prove fruitful.
        /// </summary>
        /// <param name="partial">The StringBuilder array containing the words to be looked up.</param>
        /// <param name="l">The character that was initally substituted.</param>
        private void UndoReplace(StringBuilder[] partial, char l)
        {
            for (int ii = 0; ii < partial.Length; ii++)
            {
                for (int jj = 0; jj < partial[ii].Length; jj++)
                {
                    if (partial[ii][jj] == l)
                    {
                        partial[ii][jj] = '?';
                    }
                }
            }
        }
        /// <summary>
        /// -Already found the ciphertext value, v, (in cipher) in that same word and character position.
        /// -For all such occurrences of v in cipher, replace the 
        /// corresponding location in partial with l.
        /// </summary>
        /// <param name="cipher">The ciper text.</param>
        /// <param name="partial">The StringBuilder[] that is building the translated message.</param>
        /// <param name="v">Find the ciphertext value, v, (in cipher) in that same word and character position</param>
        /// <param name="l">For all such occurrences of v in cipher, replace the corresponding location in partial with l.</param>
        private void Substitute(string[] cipher, StringBuilder[] partial, char v, char l)
        {
            for (int ii = 0; ii < cipher.Length; ii++)
            {
                for (int jj = 0; jj < cipher[ii].Length; jj++)
                {
                    if (cipher[ii][jj] == v)
                    {
                          partial[ii][jj] = l;
                    }
                }
            }
        }

        /// <summary>
        /// A method for returning the first index (word and char) that a '?' appers at in a given StringBuilder[].
        /// </summary>
        /// <param name="partial">The StringBuilder array being searched through.</param>
        /// <returns>First integer represents word index, second integer represents character index.</returns>
        private int[] FindNextQuestionMark(StringBuilder[] partial)
        {
            int[] intArr = new int[2];

            for (int i = 0; i < partial.Length; i++)
            {
                //Search through each character in each word that we've found.
                for (int j = 0; j < partial[i].Length; j++)
                {
                    //If we reach a question mark...
                    if (partial[i].ToString()[j] == '?')
                    {
                        intArr[0] = i;
                        intArr[1] = j;
                        return intArr;
                    }
                }
            }
            return intArr;
        }

        /// <summary>
        /// The click event for the decrypt button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDecryptButton_Click(object sender, EventArgs e)
        {
            //Break the text from the top text box into seperate words, and store the words in an array.
            string[] inputWordsArray = uxInputTextbox.Text.Split(' ');

            //Create an array of StringBuilders whose elements have the same size as the words from the
            //text box, but whose characters are all '?'.
            StringBuilder[] sbArray = new StringBuilder[inputWordsArray.Length];
            for (int i = 0; i < inputWordsArray.Length; i++)
            {
                sbArray[i] = new StringBuilder(inputWordsArray[i]);

                for (int j = 0; j < sbArray[i].Length; j++)
                {
                    if (!(sbArray[i][j] <= 'z' && sbArray[i][j] >= 'a'))
                    {
                        uxOutputTextBox.Text = "Invalid characters. Only lowercase letters and spaces allowed.";
                        return;
                    }
                    sbArray[i][j] = '?';
                }
            }

            //Creates an array of 26 booleans representing the letters of the alphabet.
            bool[] alphaUsedParameter = new bool[26];
            //Runs the decrypt method.
            bool result = Decrypt(inputWordsArray, sbArray, alphaUsedParameter);

            //If the text was decrypted sucsessfully, we output the decrypted text.
            if (result == true)
            {
                StringBuilder finalOutput = new StringBuilder();
                for (int ii = 0; ii < sbArray.Length; ii++)
                {
                    finalOutput.Append(sbArray[ii].ToString() + " ");
                }

                uxOutputTextBox.Text = finalOutput.ToString();
            }
            //Otherwise, we output text saying that no solution exists. 
            else
            {
                uxOutputTextBox.Text = "No solution exists";
            }

        }
    }
}
