namespace GUIAPP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text + " " + textBox2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text + " " + textBox2.Text;
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            label4.Text = "Not allowed";
        }
    }
}
