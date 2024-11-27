using System.Net.NetworkInformation;
using Microsoft.VisualBasic.ApplicationServices;

namespace LoginForm
{
    partial class WelcomeForm
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
            this.welcomeLabel = new Label();
            this.usernameLabel = new Label();
            this.iconPictureBox = new PictureBox();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.welcomeLabel.ForeColor = Color.MediumPurple;
            this.welcomeLabel.Location = new Point(50, 40);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new Size(250, 32);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Success! You're Logged In ☺️";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.usernameLabel.ForeColor = Color.Gray;
            this.usernameLabel.Location = new Point(50, 80);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new Size(90, 21);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = $"Hello, @{_username}!";
        // 
        // iconPictureBox
        // 
        // Load the avatar based on user index
            try
            {

                // Define the path based on user index (assuming index starts at 0)
                string avatarPath = $"Assets/avatar-{_userIndex + 1}.png";
                string basePath = "C:/Users/prabe/Code/Languages/C#/CLass-10-31/LoginForm";
                string full_avatar_path = basePath + "/" + avatarPath ;
                this.iconPictureBox.Image = Image.FromFile(full_avatar_path);
            }
            catch (FileNotFoundException)
            {
                //MessageBox.Show($"Avatar for user not found at {Path.Combine(Directory.GetCurrentDirectory(), $"Assets/avatar-{_userIndex + 1}.png")}. Using a default icon.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show($"Avatar not found for User {_username} at {$"Assets/avatar-{_userIndex + 1}.png"}. \n Consider Changing varibale 'basePath' to the main project folder. \n Using a Default Icon.");
                this.iconPictureBox.Image = SystemIcons.Information.ToBitmap();  // Fallback icon
            }
            this.iconPictureBox.Location = new Point(100, 120);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new Size(100, 100);
            this.iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 2;
            this.iconPictureBox.TabStop = false;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(480, 320);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "WelcomeForm";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private Label welcomeLabel;
        private Label usernameLabel;
        private PictureBox iconPictureBox;
        #endregion
    }
}