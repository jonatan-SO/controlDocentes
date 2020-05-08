using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//CLase para poder mover la ventana del login
using System.Runtime.InteropServices;

namespace controlDocentes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ESTO TE PERMITE EL QUE SE PUEDA MOVER LA VENTA DEL LOGIN POR LA PANTALLA 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void texuser_Enter(object sender, EventArgs e)
        {
            //configuración para cuando se ponga el cursor en el txto user y   que cambie a vacío y viceversa 
            if (txtuser.Text == "USER")
            {
                txtuser.Text = "";
                //se asicna el color 
                txtuser.ForeColor = Color.LightGray;
            }
        }

        //este método es para cuando el cursor del maus sale del cuadro de texto
        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USER";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        //este método no hace nada no sirve 
        private void lineShape2_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "PASSWORD")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                //se oculta la contraseña 
                txtpass.UseSystemPasswordChar = true;
            }
        }
        //este método no hace nada 
        private void lineShape2_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = " PASSWORD";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = false;

            }
        }

        
        //este método es para cuando el cursor del maus esta dentro del cuadro de texto
        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "PASSWORD")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                //se oculta la contraseña 
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_MouseLeave(object sender, EventArgs e)
        {

        }

        //este método es para cuando el cursor del maus sale del cuadro de texto password 
        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "PASSWORD";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = false;

            }

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //el evento del maus al arrastrar la ventana 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
