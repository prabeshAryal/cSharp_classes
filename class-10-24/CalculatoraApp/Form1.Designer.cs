namespace CalculatoraApp
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(34, 48);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Calc_Buttons_Click;
            // 
            // button2
            // 
            button2.Location = new Point(115, 48);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Calc_Buttons_Click;

            // 
            // button3
            // 
            button3.Location = new Point(206, 48);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Calc_Buttons_Click;

            // 
            // button4
            // 
            button4.Location = new Point(206, 86);
            button4.Name = "button6";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "6";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Calc_Buttons_Click;

            // 
            // button5
            // 
            button5.Location = new Point(115, 86);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Calc_Buttons_Click;

            // 
            // button6
            // 
            button6.Location = new Point(34, 86);
            button6.Name = "button4";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 3;
            button6.Text = "4";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Calc_Buttons_Click;

            // 
            // button7
            // 
            button7.Location = new Point(206, 131);
            button7.Name = "button9";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 8;
            button7.Text = "9";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Calc_Buttons_Click;

            // 
            // button8
            // 
            button8.Location = new Point(115, 131);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Calc_Buttons_Click;

            // 
            // button9
            // 
            button9.Location = new Point(34, 131);
            button9.Name = "button7";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 6;
            button9.Text = "7";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Calc_Buttons_Click;

            // 
            // button10
            // 
            button10.Location = new Point(206, 170);
            button10.Name = "button00";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 11;
            button10.Text = "00";
            button10.UseVisualStyleBackColor = true;
            button10.Click += Calc_Buttons_Click;

            // 
            // button11
            // 
            button11.Location = new Point(115, 170);
            button11.Name = "buttonDot";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 10;
            button11.Text = ".";
            button11.UseVisualStyleBackColor = true;
            button11.Click += Calc_Buttons_Click;

            // 
            // button12
            // 
            button12.Location = new Point(34, 170);
            button12.Name = "button0";
            button12.Size = new Size(75, 23);
            button12.TabIndex = 9;
            button12.Text = "0";
            button12.UseVisualStyleBackColor = true;
            button12.Click += Calc_Buttons_Click;

            // 
            // button13
            // 
            button13.Location = new Point(227, 217);
            button13.Name = "buttonequal";
            button13.Size = new Size(75, 175);
            button13.TabIndex = 12;
            button13.Text = "=";
            button13.UseVisualStyleBackColor = true;
            button13.Click += Equal_Button_Pressed;

            // 
            // button14
            // 
            button14.Location = new Point(36, 217);
            button14.Name = "buttonplus";
            button14.Size = new Size(75, 80);
            button14.TabIndex = 13;
            button14.Text = "+";
            button14.UseVisualStyleBackColor = true;
            button14.Click += Calc_Buttons_Click;

            // 
            // button15
            // 
            button15.Location = new Point(36, 315);
            button15.Name = "buttonminus";
            button15.Size = new Size(75, 77);
            button15.TabIndex = 14;
            button15.Text = "-";
            button15.UseVisualStyleBackColor = true;
            button15.Click += Calc_Buttons_Click;

            // 
            // button16
            // 
            button16.Location = new Point(127, 315);
            button16.Name = "buttonasteric";
            button16.Size = new Size(75, 77);
            button16.TabIndex = 16;
            button16.Text = "*";
            button16.UseVisualStyleBackColor = true;
            button16.Click += Calc_Buttons_Click;

            // 
            // button17
            // 
            button17.Location = new Point(127, 217);
            button17.Name = "buttondiv";
            button17.Size = new Size(75, 80);
            button17.TabIndex = 15;
            button17.Text = "/";
            button17.UseVisualStyleBackColor = true;
            button17.Click += Calc_Buttons_Click;

            // 
            // textBox1
            // 
            textBox1.Location = new Point(467, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 23);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(591, 108);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 18;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button16);
            Controls.Add(button17);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(button12);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private TextBox textBox1;
        private Label label1;
    }
}
