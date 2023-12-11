namespace NFLPicks2
{
    partial class LeagueBoard
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
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.LeagueNameTextBox = new System.Windows.Forms.TextBox();
            this.LeagueBoardButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(122, 79);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(82, 13);
            this.InstructionLabel.TabIndex = 0;
            this.InstructionLabel.Text = "InstructionLabel";
            // 
            // LeagueNameTextBox
            // 
            this.LeagueNameTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeagueNameTextBox.Location = new System.Drawing.Point(125, 112);
            this.LeagueNameTextBox.Name = "LeagueNameTextBox";
            this.LeagueNameTextBox.Size = new System.Drawing.Size(154, 20);
            this.LeagueNameTextBox.TabIndex = 1;
            // 
            // LeagueBoardButton1
            // 
            this.LeagueBoardButton1.Location = new System.Drawing.Point(125, 150);
            this.LeagueBoardButton1.Name = "LeagueBoardButton1";
            this.LeagueBoardButton1.Size = new System.Drawing.Size(154, 40);
            this.LeagueBoardButton1.TabIndex = 2;
            this.LeagueBoardButton1.Text = "Create/Join";
            this.LeagueBoardButton1.UseVisualStyleBackColor = true;
            this.LeagueBoardButton1.Click += new System.EventHandler(this.LeagueBoardButton1_Click);
            // 
            // LeagueBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 288);
            this.Controls.Add(this.LeagueBoardButton1);
            this.Controls.Add(this.LeagueNameTextBox);
            this.Controls.Add(this.InstructionLabel);
            this.Name = "LeagueBoard";
            this.Text = "LeagueBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.TextBox LeagueNameTextBox;
        private System.Windows.Forms.Button LeagueBoardButton1;
    }
}