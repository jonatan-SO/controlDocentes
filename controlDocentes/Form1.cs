using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlDocentes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }

        private void texuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USER")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USER";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void lineShape2_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "PASSWORD")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void lineShape2_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = " PASSWORD";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;

            }
        }
    }
}
