namespace Ksu.Cis300.BaseballScores
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
            this.uxAddDataFileButton = new System.Windows.Forms.Button();
            this.uxGetGameResultsButton = new System.Windows.Forms.Button();
            this.uxComboBox = new System.Windows.Forms.ComboBox();
            this.uxDatePicker = new System.Windows.Forms.DateTimePicker();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxAddDataFileButton
            // 
            this.uxAddDataFileButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAddDataFileButton.Location = new System.Drawing.Point(20, 13);
            this.uxAddDataFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.uxAddDataFileButton.Name = "uxAddDataFileButton";
            this.uxAddDataFileButton.Size = new System.Drawing.Size(352, 38);
            this.uxAddDataFileButton.TabIndex = 0;
            this.uxAddDataFileButton.Text = "Add Data File";
            this.uxAddDataFileButton.UseVisualStyleBackColor = true;
            this.uxAddDataFileButton.Click += new System.EventHandler(this.uxAddDataFileButton_Click);
            // 
            // uxGetGameResultsButton
            // 
            this.uxGetGameResultsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGetGameResultsButton.Location = new System.Drawing.Point(155, 99);
            this.uxGetGameResultsButton.Margin = new System.Windows.Forms.Padding(4);
            this.uxGetGameResultsButton.Name = "uxGetGameResultsButton";
            this.uxGetGameResultsButton.Size = new System.Drawing.Size(217, 36);
            this.uxGetGameResultsButton.TabIndex = 1;
            this.uxGetGameResultsButton.Text = "Get Game Results";
            this.uxGetGameResultsButton.UseVisualStyleBackColor = true;
            this.uxGetGameResultsButton.Click += new System.EventHandler(this.uxGetGameResultsButton_Click);
            // 
            // uxComboBox
            // 
            this.uxComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxComboBox.FormattingEnabled = true;
            this.uxComboBox.Location = new System.Drawing.Point(20, 63);
            this.uxComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.uxComboBox.Name = "uxComboBox";
            this.uxComboBox.Size = new System.Drawing.Size(352, 26);
            this.uxComboBox.Sorted = true;
            this.uxComboBox.TabIndex = 2;
            // 
            // uxDatePicker
            // 
            this.uxDatePicker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.uxDatePicker.Location = new System.Drawing.Point(20, 102);
            this.uxDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.uxDatePicker.MaxDate = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            this.uxDatePicker.MinDate = new System.DateTime(1871, 1, 1, 0, 0, 0, 0);
            this.uxDatePicker.Name = "uxDatePicker";
            this.uxDatePicker.Size = new System.Drawing.Size(127, 26);
            this.uxDatePicker.TabIndex = 3;
            this.uxDatePicker.Value = new System.DateTime(2013, 12, 31, 0, 0, 0, 0);
            // 
            // uxOpenFileDialog
            // 
            this.uxOpenFileDialog.FileName = "openFileDialog1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 146);
            this.Controls.Add(this.uxDatePicker);
            this.Controls.Add(this.uxComboBox);
            this.Controls.Add(this.uxGetGameResultsButton);
            this.Controls.Add(this.uxAddDataFileButton);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Baseball Scores";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxAddDataFileButton;
        private System.Windows.Forms.Button uxGetGameResultsButton;
        private System.Windows.Forms.ComboBox uxComboBox;
        private System.Windows.Forms.DateTimePicker uxDatePicker;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
    }
}

