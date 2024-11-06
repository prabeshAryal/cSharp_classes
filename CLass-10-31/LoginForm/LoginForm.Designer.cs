namespace LoginForm
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            usernamelabel = new Label();
            password_label = new Label();
            inputUsername = new TextBox();
            inputUserpassword = new TextBox();
            progressBar1 = new ProgressBar();
            login_button = new Button();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            errorProvider3 = new ErrorProvider(components);
            errorProvider4 = new ErrorProvider(components);
            errorProvider5 = new ErrorProvider(components);
            errorProvider6 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider6).BeginInit();
            SuspendLayout();
            // 
            // usernamelabel
            // 
            usernamelabel.AutoSize = true;
            usernamelabel.Location = new Point(249, 126);
            usernamelabel.Name = "usernamelabel";
            usernamelabel.Size = new Size(60, 15);
            usernamelabel.TabIndex = 0;
            usernamelabel.Text = "Username";
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Location = new Point(249, 155);
            password_label.Name = "password_label";
            password_label.Size = new Size(57, 15);
            password_label.TabIndex = 1;
            password_label.Text = "Password";
            // 
            // inputUsername
            // 
            inputUsername.Location = new Point(327, 118);
            inputUsername.Name = "inputUsername";
            inputUsername.Size = new Size(100, 23);
            inputUsername.TabIndex = 2;
            // 
            // inputUserpassword
            // 
            inputUserpassword.Location = new Point(327, 147);
            inputUserpassword.Name = "inputUserpassword";
            inputUserpassword.Size = new Size(100, 23);
            inputUserpassword.TabIndex = 3;
            inputUserpassword.TextChanged += inputUserpassword_TextChanged;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.White;
            progressBar1.ForeColor = Color.Orange;
            progressBar1.Location = new Point(327, 176);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 10);
            progressBar1.TabIndex = 4;
            progressBar1.Visible = false;
            // 
            // login_button
            // 
            login_button.Location = new Point(249, 213);
            login_button.Name = "login_button";
            login_button.Size = new Size(178, 58);
            login_button.TabIndex = 5;
            login_button.Text = "Login";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_Click;
           
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(login_button);
            Controls.Add(progressBar1);
            Controls.Add(inputUserpassword);
            Controls.Add(inputUsername);
            Controls.Add(password_label);
            Controls.Add(usernamelabel);
            Name = "LoginForm";
            Text = "Login Form";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider4).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider5).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usernamelabel;
        private Label password_label;
        private TextBox inputUsername;
        private TextBox inputUserpassword;
        private ProgressBar progressBar1;
        private Button login_button;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private ErrorProvider errorProvider3;
        private ErrorProvider errorProvider4;
        private ErrorProvider errorProvider5;
        private ErrorProvider errorProvider6;
    }
}
