namespace Ksu.Cis300.HomworkAssignment1
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxMaze = new Ksu.Cis300.MazeLibrary.Maze();
            this.uxNewMazeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxMaze
            // 
            this.uxMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMaze.Location = new System.Drawing.Point(15, 15);
            this.uxMaze.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.uxMaze.Name = "uxMaze";
            this.uxMaze.PathColor = System.Drawing.SystemColors.Highlight;
            this.uxMaze.Size = new System.Drawing.Size(914, 701);
            this.uxMaze.TabIndex = 0;
            this.uxMaze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uxMaze_MouseClick);
            // 
            // uxNewMazeButton
            // 
            this.uxNewMazeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxNewMazeButton.Location = new System.Drawing.Point(344, 789);
            this.uxNewMazeButton.Name = "uxNewMazeButton";
            this.uxNewMazeButton.Size = new System.Drawing.Size(218, 55);
            this.uxNewMazeButton.TabIndex = 1;
            this.uxNewMazeButton.Text = "New Maze";
            this.uxNewMazeButton.UseVisualStyleBackColor = true;
            this.uxNewMazeButton.Click += new System.EventHandler(this.uxNewMazeButton_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 856);
            this.Controls.Add(this.uxNewMazeButton);
            this.Controls.Add(this.uxMaze);
            this.Name = "UserInterface";
            this.Text = "Maze Solver";
            this.ResumeLayout(false);

        }

        #endregion

        private MazeLibrary.Maze uxMaze;
        private System.Windows.Forms.Button uxNewMazeButton;
    }
}

