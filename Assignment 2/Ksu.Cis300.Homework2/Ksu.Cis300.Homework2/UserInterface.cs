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

namespace Ksu.Cis300.Homework2
{
    /// <summary>
    /// A class for the User Interface. 
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructor initilaizes the label text, and creates the User Interface. 
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            uxFileOneLabel.Text = "No File Loaded.";
            uxFileTwoLabel.Text = "No File Loaded.";
        }

        //Contains all of the phone numbers and phone number counts from file one. 
        private LinkedListCell<PhoneCount> _linkedCellOne;

        //Contains all of the phone numbers and phone number counts from file two. 
        private LinkedListCell<PhoneCount> _linkedCellTwo;

        //Booleans keeping track of whether or not the user has selected a file yet. Allows the program to determine when to enable the uxFindOverlapsButton. 
        private Boolean foundFileOne = false;
        private Boolean foundFileTwo = false;

        /// <summary>
        /// The Click Event for the File 1 Button. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoadFileOneButton_Click(object sender, EventArgs e)
        {

            //Opens a File Dialog. If the user selects a valid file, it is read into _linkedCellOne via the ReadIntoList() method. The label is changed.
            if (uxOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
               string fileNameOne = uxOpenFileDialog1.FileName;
               _linkedCellOne = ReadIntoList(fileNameOne);
               uxFileOneLabel.Text = "File loaded.";
               foundFileOne = true;
            }           
            if (foundFileTwo == true)
            {
                uxFindOverlapsButton.Enabled = true; 
            }
        }

        /// <summary>
        /// A method that reads in the content of a given file containing phone numbers. A linkedlist is returned containing PhoneNumber opbjects.
        /// </summary>
        /// <param name="fileName">The name of the file to be read in.</param>
        /// <returns></returns>
        public LinkedListCell<PhoneCount> ReadIntoList(string fileName)
        {
            //Creates a stream reader to get the input.
            StreamReader input = new StreamReader(fileName);
            
            //A string containing the current phone number being read from the file.
            string currentNumber = "";

            //The LinkedListCell that will ultimatly be returned. Contains all PhoneNumber Information. 
            LinkedListCell<PhoneCount> cell = new LinkedListCell<PhoneCount>();
            cell = null;
            //Temporary LinkedListCell created for searching purposes. 
            LinkedListCell<PhoneCount> temp = new LinkedListCell<PhoneCount>();
            
            //Keeps track of whether the number is already in the list. 
            Boolean foundRepeat;

            //Loop iterates as long as there are still phone numbers in the file.
            while (input.EndOfStream == false)
            {
                //Reads in line from the file.
                currentNumber = input.ReadLine();

                temp = cell; 
                foundRepeat = false;

                //Loop searches to see if the phone number that was just read is already in the LinkedList.
                while (temp != null)
                {
                    //If it is in the current cell, we increase the count of that phone number by one, and break out of the loop.
                    if ((temp.Data.PhoneNumber).CompareTo(currentNumber) == 0)
                    {
                        temp.Data.PhoneNumberCount++;
                        foundRepeat = true;
                        break;
                    }
                    //Otherwise, we move on to the next cell. 
                    else
                    {
                        temp = temp.Next;
                    }
                }
                //If the phone number was not already in the linked list, we add the phone number to the begining of the list. 
                if (foundRepeat == false)
                {
                    LinkedListCell<PhoneCount> temp2 = new LinkedListCell<PhoneCount>();
                    temp2.Data= new PhoneCount(currentNumber, 1);
                    temp2.Next = cell;
                    cell = temp2;
                }  
            }
            return cell;
        }

        /// <summary>
        /// The Click Event for the File 2 Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoadFileTwoButton_Click(object sender, EventArgs e)
        {
            //Opens a File Dialog. If the user selects a valid file, it is read into _linkedCellTwo via the ReadIntoList() method. The label is changed.
            if (uxOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileNameTwo = uxOpenFileDialog1.FileName;
                _linkedCellTwo = ReadIntoList(fileNameTwo);
                uxFileTwoLabel.Text = "File loaded.";
                foundFileTwo = true; 
            }
            if (foundFileOne == true)
            {
                uxFindOverlapsButton.Enabled = true;
            }
        }

        /// <summary>
        /// A method that determines overlap between two phone number logs. It prints out the resulting counts of phone numbers that meet the user defined minimum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindOverlapsButton_Click(object sender, EventArgs e)
        {
            //Creates a temporary linkedList for searching purposes.
            LinkedListCell<PhoneCount> temp1 = new LinkedListCell<PhoneCount>();
            temp1 = _linkedCellOne;

            LinkedListCell<PhoneCount> temp2 = new LinkedListCell<PhoneCount>();
            
            //Initializes Output String. 
            string output = "";

            //While there are still elements to search from the first list...
            while (temp1 != null)
            {
                //And while there are still items in the second list to compare...
                temp2 = _linkedCellTwo;
                while (temp2 != null)
                {
                    if (temp1.Data.PhoneNumberCount >= uxNumericUpDown.Value)
                    {
                        if ((temp1.Data.PhoneNumber).CompareTo(temp2.Data.PhoneNumber) == 0 && temp2.Data.PhoneNumberCount >= uxNumericUpDown.Value)
                        {
                            output += (temp1.Data.PhoneNumber + "\r\n\t" + temp1.Data.PhoneNumberCount + " times (file 1)" + "\r\n\t" + temp2.Data.PhoneNumberCount + " times (file 2)" + "\r\n\r\n");
                        }
                    }
                    temp2 = temp2.Next;
                 }
                temp1 = temp1.Next;
            }
            //If no matches were found, print a message saying so. 
            if (output == "")
            {
                output = "No overlaps found.";
            }
            uxTextBox.Text = output;
        }


    }
}
