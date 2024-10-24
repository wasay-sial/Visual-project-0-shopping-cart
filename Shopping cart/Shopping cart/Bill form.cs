using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_cart
{
    public partial class Bill_form : Form
    {
        public Bill_form(string message)
        {
            InitializeComponent();

            label1.Text = message;
            label1.Font = new Font("rockwell", 18);
        }

        private void Bill_form_Load(object sender, EventArgs e)
        {

        }
    }
}
