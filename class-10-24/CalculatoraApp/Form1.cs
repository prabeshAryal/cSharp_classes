namespace CalculatoraApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calc_Buttons_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            textBox1.Text += clickedButton.Text;
        }

        private void Equal_Button_Pressed(object sender, EventArgs e)
        {
    
            label1.Text ="Equal Button Pressed";
        }


    }
    }
