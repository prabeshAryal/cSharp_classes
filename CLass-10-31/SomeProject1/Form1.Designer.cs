namespace SomeProject1
{
    partial class Form1
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernamelabel = new Label();
            password_label = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            progressBar1 = new ProgressBar();
            login_button = new Button();
            signup_button = new Button();
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
            usernamelabel.Click += label1_Click;
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
            // textBox1
            // 
            textBox1.Location = new Point(327, 118);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(327, 147);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
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
            login_button.Location = new Point(271, 206);
            login_button.Name = "login_button";
            login_button.Size = new Size(75, 23);
            login_button.TabIndex = 5;
            login_button.Text = "Login";
            login_button.UseVisualStyleBackColor = true;
            // 
            // signup_button
            // 
            signup_button.Location = new Point(352, 206);
            signup_button.Name = "signup_button";
            signup_button.Size = new Size(75, 23);
            signup_button.TabIndex = 6;
            signup_button.Text = "Signup";
            signup_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(signup_button);
            Controls.Add(login_button);
            Controls.Add(progressBar1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(password_label);
            Controls.Add(usernamelabel);
            Name = "Form1";
            Text = "Codechod";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usernamelabel;
        private Label password_label;
        private TextBox textBox1;
        private TextBox textBox2;
        private ProgressBar progressBar1;
        private Button login_button;
        private Button signup_button;
    }
}
