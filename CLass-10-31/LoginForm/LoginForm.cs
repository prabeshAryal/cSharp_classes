using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            inputUserpassword.PasswordChar = '*';  // Hide password input
            progressBar1.Visible = false;  // Initially hide progress bar
        }

        private void inputUserpassword_TextChanged(object sender, EventArgs e)
        {
            // Show and update progress bar based on password strength
            progressBar1.Visible = true;
            progressBar1.Value = inputUserpassword.Text.Length < 8 ? (int)(inputUserpassword.Text.Length * 12.5) : 100;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputUsername.Text) || string.IsNullOrWhiteSpace(inputUserpassword.Text))
                {
                    throw new ArgumentException("Username and password cannot be empty.");
                }

                List<User> users = new List<User>
        {
            new User("prabe.sh", "password", "Admin"),
            new User("root", "password", "Admin"),
            new User("test", "test", "User"),
            new User("vuqar", "123", "User"),
            // Add more users as needed
        };

                // Check credentials and get the user index if valid
                var userIndex = users.FindIndex(user => user.Username.ToLower() == inputUsername.Text.ToLower() && user.Password == inputUserpassword.Text);

                if (userIndex >= 0)  // Login successful
                {
                    WelcomeForm welcomeForm = new WelcomeForm(users[userIndex].Username.ToLower(), userIndex);
                    this.Hide();  // Hide the login form
                    welcomeForm.ShowDialog();
                    this.Show();  // Show the login form again after WelcomeForm is closed
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
