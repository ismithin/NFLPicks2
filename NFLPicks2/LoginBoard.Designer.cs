namespace NFLPicks2
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameLoginLabel = new System.Windows.Forms.Label();
            this.passwordLoginLabel = new System.Windows.Forms.Label();
            this.LoginButton1 = new System.Windows.Forms.Button();
            this.NFLPicksLoginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(359, 156);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(168, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(359, 218);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(168, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // usernameLoginLabel
            // 
            this.usernameLoginLabel.AutoSize = true;
            this.usernameLoginLabel.Location = new System.Drawing.Point(411, 140);
            this.usernameLoginLabel.Name = "usernameLoginLabel";
            this.usernameLoginLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLoginLabel.TabIndex = 2;
            this.usernameLoginLabel.Text = "Username:";
            // 
            // passwordLoginLabel
            // 
            this.passwordLoginLabel.AutoSize = true;
            this.passwordLoginLabel.Location = new System.Drawing.Point(411, 202);
            this.passwordLoginLabel.Name = "passwordLoginLabel";
            this.passwordLoginLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLoginLabel.TabIndex = 3;
            this.passwordLoginLabel.Text = "Password:";
            // 
            // LoginButton1
            // 
            this.LoginButton1.Location = new System.Drawing.Point(359, 377);
            this.LoginButton1.Name = "LoginButton1";
            this.LoginButton1.Size = new System.Drawing.Size(168, 55);
            this.LoginButton1.TabIndex = 4;
            this.LoginButton1.Text = "Login";
            this.LoginButton1.UseVisualStyleBackColor = true;
            // 
            // NFLPicksLoginLabel
            // 
            this.NFLPicksLoginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NFLPicksLoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.NFLPicksLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NFLPicksLoginLabel.Location = new System.Drawing.Point(342, 9);
            this.NFLPicksLoginLabel.Name = "NFLPicksLoginLabel";
            this.NFLPicksLoginLabel.Size = new System.Drawing.Size(209, 83);
            this.NFLPicksLoginLabel.TabIndex = 5;
            this.NFLPicksLoginLabel.Text = "NFL Pick\'em";
            this.NFLPicksLoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NFLPicksLoginLabel.Click += new System.EventHandler(this.NFLPicksLoginLabel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(889, 620);
            this.Controls.Add(this.NFLPicksLoginLabel);
            this.Controls.Add(this.LoginButton1);
            this.Controls.Add(this.passwordLoginLabel);
            this.Controls.Add(this.usernameLoginLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "LoginBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernameLoginLabel;
        private System.Windows.Forms.Label passwordLoginLabel;
        private System.Windows.Forms.Button LoginButton1;
        private System.Windows.Forms.Label NFLPicksLoginLabel;
    }
}