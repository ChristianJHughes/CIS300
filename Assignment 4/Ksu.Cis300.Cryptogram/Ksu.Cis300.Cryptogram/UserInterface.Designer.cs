namespace Ksu.Cis300.Cryptogram
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
            this.uxInputTextbox = new System.Windows.Forms.TextBox();
            this.uxOpenFileButton = new System.Windows.Forms.Button();
            this.uxDecryptButton = new System.Windows.Forms.Button();
            this.uxOutputTextBox = new System.Windows.Forms.TextBox();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxInputTextbox
            // 
            this.uxInputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxInputTextbox.Location = new System.Drawing.Point(12, 14);
            this.uxInputTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxInputTextbox.Multiline = true;
            this.uxInputTextbox.Name = "uxInputTextbox";
            this.uxInputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxInputTextbox.Size = new System.Drawing.Size(448, 130);
            this.uxInputTextbox.TabIndex = 1;
            // 
            // uxOpenFileButton
            // 
            this.uxOpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOpenFileButton.Location = new System.Drawing.Point(104, 157);
            this.uxOpenFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOpenFileButton.Name = "uxOpenFileButton";
            this.uxOpenFileButton.Size = new System.Drawing.Size(94, 34);
            this.uxOpenFileButton.TabIndex = 2;
            this.uxOpenFileButton.Text = "Open File";
            this.uxOpenFileButton.UseVisualStyleBackColor = true;
            this.uxOpenFileButton.Click += new System.EventHandler(this.uxOpenFileButton_Click);
            // 
            // uxDecryptButton
            // 
            this.uxDecryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxDecryptButton.Location = new System.Drawing.Point(238, 157);
            this.uxDecryptButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxDecryptButton.Name = "uxDecryptButton";
            this.uxDecryptButton.Size = new System.Drawing.Size(93, 34);
            this.uxDecryptButton.TabIndex = 3;
            this.uxDecryptButton.Text = "Decrypt";
            this.uxDecryptButton.UseVisualStyleBackColor = true;
            this.uxDecryptButton.Click += new System.EventHandler(this.uxDecryptButton_Click);
            // 
            // uxOutputTextBox
            // 
            this.uxOutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOutputTextBox.Location = new System.Drawing.Point(12, 209);
            this.uxOutputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxOutputTextBox.Multiline = true;
            this.uxOutputTextBox.Name = "uxOutputTextBox";
            this.uxOutputTextBox.ReadOnly = true;
            this.uxOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxOutputTextBox.Size = new System.Drawing.Size(448, 141);
            this.uxOutputTextBox.TabIndex = 4;
            // 
            // uxOpenFileDialog
            // 
            this.uxOpenFileDialog.FileName = "dictionary.txt";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 361);
            this.Controls.Add(this.uxOutputTextBox);
            this.Controls.Add(this.uxDecryptButton);
            this.Controls.Add(this.uxOpenFileButton);
            this.Controls.Add(this.uxInputTextbox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserInterface";
            this.Text = "Crypto Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxInputTextbox;
        private System.Windows.Forms.Button uxOpenFileButton;
        private System.Windows.Forms.Button uxDecryptButton;
        private System.Windows.Forms.TextBox uxOutputTextBox;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
    }
}

