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

        /// <summary>
        /// A method used for finding a path to the exit, and drawing it to the screen.
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
            Cell clickedCell = new Cell(); 
            clickedCell = uxMaze.GetCellFromPixel(e.Location);

            if (uxMaze.IsInMaze(clickedCell) == true)
            {
                uxMaze.EraseAllPaths();
                exitLine(clickedCell);
                uxMaze.Invalidate();
            }
        }


    }
}
