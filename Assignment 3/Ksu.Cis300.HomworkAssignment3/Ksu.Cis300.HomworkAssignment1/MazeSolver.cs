/* MazeSolver.cs
 * Author: Christian J. Hughes
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
using Ksu.Cis300.MazeLibrary;

namespace Ksu.Cis300.HomworkAssignment1
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Initializes the user interface.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }        

        /*
        /// <summary>
        /// A method used for finding a path to the exit, and drawing it to the screen. From Homework 1. Not called in this assignment. 
        /// </summary>
        /// <param name="loc"></param>
        public void exitLine(Cell loc)
        {
            Cell location = new Cell(loc.Row, loc.Column);
            Stack<Direction> pathTracker = new Stack<Direction>(); 
            bool[,] visitedCord = new bool[uxMaze.MazeHeight, uxMaze.MazeWidth];
            visitedCord[location.Row, location.Column] = true;
            Direction goNext = Direction.North;

            //While we're still in the maze
            while (uxMaze.IsInMaze(location) == true)
            {
                //And we haven't cycled through all of the directions.
                if (goNext <= Direction.West)
                {
                    //If the coast is clear and we've never been to that spot...
                    if (uxMaze.IsClear(location, goNext) == true && (uxMaze.IsInMaze(uxMaze.Step(location, goNext)) == false || visitedCord[uxMaze.Step(location, goNext).Row, uxMaze.Step(location, goNext).Column] == false))
                    {
                        uxMaze.DrawPath(location, goNext);
                        location = uxMaze.Step(location, goNext);
                        pathTracker.Push(goNext);
                        goNext = Direction.North;

                        if (uxMaze.IsInMaze(location) == true)
                        {
                            visitedCord[location.Row, location.Column] = true;
                        }

                    }
                    else
                    {
                        goNext++;
                    }
                }
                else if (goNext > Direction.West && pathTracker.Count > 0)
                {
                    goNext = pathTracker.Pop();             //goNext might need to be opposite here?
                    location = uxMaze.ReverseStep(location, goNext);
                    uxMaze.ErasePath(location, goNext);
                    goNext++;
                }
                else
                {
                    MessageBox.Show("You cannot escape the maze from this point.");
                    return;
                }
            }
        }
        */
        
        /// <summary>
        /// Click event for the "New Maze" button. It causes a new, random maze to be generated. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewMazeButton_Click(object sender, EventArgs e)
        {
            uxMaze.Generate(); 
        }

        /// <summary>
        /// A line is drawn from the point clicked in the maze, to the maze exit. New locations can be clicked for replacement/new paths.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            //Finds the cell that the user clicked on.
            Cell clickedCell = new Cell(); 
            clickedCell = uxMaze.GetCellFromPixel(e.Location);
            //Creates an array for all of the cells in the maze. To be passed into the DrawLineOutRec() Method.
            bool[,] boolarray = new bool[uxMaze.MazeHeight, uxMaze.MazeWidth];

            //If the user clicked in the maze...
            if (uxMaze.IsInMaze(clickedCell) == true)
            {
                //Erase all paths currently in the maze. 
                uxMaze.EraseAllPaths();

                //Draw a Path out of the maze
                bool foundPath = DrawLineOutRec(clickedCell, boolarray);

                //If there is no exit from the current cell, alert the user with a message box. 
                if (foundPath == false)
                {
                    uxMaze.Invalidate();
                    MessageBox.Show("You cannot escape the maze from this point.");
                }
                uxMaze.Invalidate();
            }
        }
        /// <summary>
        /// A method for drawing a line out of the maze. Uses a preorder traversal. 
        /// </summary>
        /// <param name="c">The cell in the maze that the user selected.</param>
        /// <param name="boolarr">A bool array keeping track of which cells in the maze have been visited.</param>
        /// <returns></returns>
        private bool DrawLineOutRec(Cell c, bool[,] boolarr)
        {
            //Establishing that the current cell has been analyzed
            boolarr[c.Row, c.Column] = true;

            //Cycles through all the directions from North to West
            for (Direction d = Direction.North; d <= Direction.West; d++)
            {
                //If the next cell in the direction we are facing is clear...
                if (uxMaze.IsClear(c, d))
                {
                    //If the cell that we are facing is not in the maze...We have found an exit  BASE CASE
                    if (uxMaze.IsInMaze(uxMaze.Step(c, d)) == false)
                    {
                        //Then we have found an exit! Draw a line from the current cell to the exit, and return true.
                        uxMaze.DrawPath(c, d);
                        return true;
                    }

                    //Creates a cell containing the cell adjacent from the current cell in the given direction. 
                    Cell cNext = new Cell();
                    cNext = uxMaze.Step(c, d);

                    //If we have not yet visited the next cell...
                    if (boolarr[cNext.Row, cNext.Column] == false)
                    {
                        //Recursively call the function.
                        bool recResult = DrawLineOutRec(cNext, boolarr);

                        //If the result of that recursive function is true (We found an exit) then draw a path from the current cell to then next cell in the current direction. 
                        if (recResult == true)
                        {
                            uxMaze.DrawPath(c, d);
                            return true; 
                        }
                    }
                }
            }
            return false; 
        }
    }
}
