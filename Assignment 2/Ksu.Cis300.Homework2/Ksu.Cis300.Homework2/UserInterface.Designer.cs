namespace Ksu.Cis300.Homework2
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
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxLoadFileOneButton = new System.Windows.Forms.Button();
            this.uxLoadFileTwoButton = new System.Windows.Forms.Button();
            this.uxFileOneLabel = new System.Windows.Forms.Label();
            this.uxFileTwoLabel = new System.Windows.Forms.Label();
            this.uxStaticLabel = new System.Windows.Forms.Label();
            this.uxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uxFindOverlapsButton = new System.Windows.Forms.Button();
            this.uxOpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uxTextBox
            // 
            this.uxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTextBox.Location = new System.Drawing.Point(366, 12);
            this.uxTextBox.Multiline = true;
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTextBox.Size = new System.Drawing.Size(347, 326);
            this.uxTextBox.TabIndex = 0;
            // 
            // uxLoadFileOneButton
            // 
            this.uxLoadFileOneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLoadFileOneButton.Location = new System.Drawing.Point(13, 13);
            this.uxLoadFileOneButton.Name = "uxLoadFileOneButton";
            this.uxLoadFileOneButton.Size = new System.Drawing.Size(103, 30);
            this.uxLoadFileOneButton.TabIndex = 1;
            this.uxLoadFileOneButton.Text = "Load File 1";
            this.uxLoadFileOneButton.UseVisualStyleBackColor = true;
            this.uxLoadFileOneButton.Click += new System.EventHandler(this.uxLoadFileOneButton_Click);
            // 
            // uxLoadFileTwoButton
            // 
            this.uxLoadFileTwoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLoadFileTwoButton.Location = new System.Drawing.Point(13, 49);
            this.uxLoadFileTwoButton.Name = "uxLoadFileTwoButton";
            this.uxLoadFileTwoButton.Size = new System.Drawing.Size(103, 30);
            this.uxLoadFileTwoButton.TabIndex = 2;
            this.uxLoadFileTwoButton.Text = "Load File 2";
            this.uxLoadFileTwoButton.UseVisualStyleBackColor = true;
            this.uxLoadFileTwoButton.Click += new System.EventHandler(this.uxLoadFileTwoButton_Click);
            // 
            // uxFileOneLabel
            // 
            this.uxFileOneLabel.AutoSize = true;
            this.uxFileOneLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxFileOneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFileOneLabel.Location = new System.Drawing.Point(157, 19);
            this.uxFileOneLabel.Name = "uxFileOneLabel";
            this.uxFileOneLabel.Size = new System.Drawing.Size(48, 20);
            this.uxFileOneLabel.TabIndex = 3;
            this.uxFileOneLabel.Text = "label1";
            // 
            // uxFileTwoLabel
            // 
            this.uxFileTwoLabel.AutoSize = true;
            this.uxFileTwoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uxFileTwoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFileTwoLabel.Location = new System.Drawing.Point(157, 55);
            this.uxFileTwoLabel.Name = "uxFileTwoLabel";
            this.uxFileTwoLabel.Size = new System.Drawing.Size(48, 20);
            this.uxFileTwoLabel.TabIndex = 4;
            this.uxFileTwoLabel.Text = "label1";
            // 
            // uxStaticLabel
            // 
            this.uxStaticLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStaticLabel.Location = new System.Drawing.Point(12, 129);
            this.uxStaticLabel.Name = "uxStaticLabel";
            this.uxStaticLabel.Size = new System.Drawing.Size(130, 42);
            this.uxStaticLabel.TabIndex = 5;
            this.uxStaticLabel.Text = "Minimum calls per number:";
            // 
            // uxNumericUpDown
            // 
            this.uxNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumericUpDown.Location = new System.Drawing.Point(157, 129);
            this.uxNumericUpDown.Name = "uxNumericUpDown";
            this.uxNumericUpDown.Size = new System.Drawing.Size(120, 24);
            this.uxNumericUpDown.TabIndex = 6;
            this.uxNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // uxFindOverlapsButton
            // 
            this.uxFindOverlapsButton.Enabled = false;
            this.uxFindOverlapsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFindOverlapsButton.Location = new System.Drawing.Point(101, 196);
            this.uxFindOverlapsButton.Name = "uxFindOverlapsButton";
            this.uxFindOverlapsButton.Size = new System.Drawing.Size(148, 30);
            this.uxFindOverlapsButton.TabIndex = 7;
            this.uxFindOverlapsButton.Text = "Find Overlaps";
            this.uxFindOverlapsButton.UseVisualStyleBackColor = true;
            this.uxFindOverlapsButton.Click += new System.EventHandler(this.uxFindOverlapsButton_Click);
            // 
            // uxOpenFileDialog1
            // 
            this.uxOpenFileDialog1.FileName = "openFileDialog1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 350);
            this.Controls.Add(this.uxFindOverlapsButton);
            this.Controls.Add(this.uxNumericUpDown);
            this.Controls.Add(this.uxStaticLabel);
            this.Controls.Add(this.uxFileTwoLabel);
            this.Controls.Add(this.uxFileOneLabel);
            this.Controls.Add(this.uxLoadFileTwoButton);
            this.Controls.Add(this.uxLoadFileOneButton);
            this.Controls.Add(this.uxTextBox);
            this.Name = "UserInterface";
            this.Text = "Phone Matcher";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.Button uxLoadFileOneButton;
        private System.Windows.Forms.Button uxLoadFileTwoButton;
        private System.Windows.Forms.Label uxFileOneLabel;
        private System.Windows.Forms.Label uxFileTwoLabel;
        private System.Windows.Forms.Label uxStaticLabel;
        private System.Windows.Forms.NumericUpDown uxNumericUpDown;
        private System.Windows.Forms.Button uxFindOverlapsButton;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog1;
    }
}

