namespace SomeProject1
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = textBox2.Text.Length < 8 ? (int)(textBox2.Text.Length * 12.5) : 100;
        }


    }
}
