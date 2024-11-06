using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class WelcomeForm : Form
    {
        private string _username;
        private int _userIndex;


        public WelcomeForm(string username, int userIndex)
        {
            _username = username;
            _userIndex = userIndex;
            InitializeComponent();
        }
    }
}
