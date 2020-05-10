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
using MySql.Data.MySqlClient;

namespace controlDocentes
{
    public partial class Form3 : Form


    {

        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataReader lector;



        public Form3()
        {
            InitializeComponent();
        }

        //ESTO TE PERMITE EL QUE SE PUEDA MOVER LA VENTA DEL LOGIN POR LA PANTALLA 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servidor = "";
            string puerto = "";
            string usuario = "";
            string password = "";

            string cadenaConexion = "server='localhost'" + servidor + "; port='3307'" + puerto + "; user id='root'" + usuario + "; password='root'" + password + "; database=SeguimientoAclase;";


            try
            {

                
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {

                    MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                    conexionBD.Open();
                    try
                    {
                        comando = new MySqlCommand("insert into grupo values(@id_grupo, @jefe_grupo, @carrera)", conexionBD);

                        comando.Parameters.Add("@id_grupo", MySqlDbType.VarChar).Value = textBox1.Text;
                        comando.Parameters.Add("@jefe_grupo", MySqlDbType.VarChar).Value = textBox2.Text;
                        comando.Parameters.Add("@carrera", MySqlDbType.VarChar).Value = textBox3.Text;

                        comando.ExecuteNonQuery(); //Ejecuta la sentencia

                        MessageBox.Show("Registro exitoso!", "Proceso de registro");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }




                }

                    

            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }








        }
    }
}
