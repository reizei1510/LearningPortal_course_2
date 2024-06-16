using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace course
{
    public partial class Form_Again : Form
    {
        internal bool yes = false;

        public Form_Again()
        {
            InitializeComponent();
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            yes = true;
            Close();
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
