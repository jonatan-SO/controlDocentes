using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//CLase para poder mover la ventana del login
using System.Runtime.InteropServices;

namespace controlDocentes
{
    public partial class Form4 : Form
    {


        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataReader lector;

        public Form4()
        {
            InitializeComponent();
        }

        //ESTO TE PERMITE EL QUE SE PUEDA MOVER LA VENTA DEL LOGIN POR LA PANTALLA 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);





        //--------------------AGREGAR----------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            string servidor = "";
            string puerto = "";
            string usuario = "";
            string password = "";

            string cadenaConexion = "server='localhost'" + servidor + "; port='3307'" + puerto + "; user id='root'" + usuario + "; password='root'" + password + "; database=SeguimientoAclase;";


            try
            {


                if (textBox1.Text != "" && textBox2.Text != "" )
                {

                    MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                    conexionBD.Open();
                    try
                    {
                        comando = new MySqlCommand("insert into maestro values(@nombre_maestro, @materia)", conexionBD);

                        comando.Parameters.Add("@nombre_maestro", MySqlDbType.VarChar).Value = textBox1.Text;
                        comando.Parameters.Add("@materia", MySqlDbType.VarChar).Value = textBox2.Text;
                        

                        comando.ExecuteNonQuery(); //Ejecuta la sentencia

                        MessageBox.Show("Registro exitoso!", "Proceso de registro");
                        textBox1.Text = "";
                        textBox2.Text = "";
                       

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //--------------------MODIFICAR----------------------------//
        private void button2_Click(object sender, EventArgs e)
        {
            string servidor = "";
            string puerto = "";
            string usuario = "";
            string password = "";

            string cadenaConexion = "server='localhost'" + servidor + "; port='3307'" + puerto + "; user id='root'" + usuario + "; password='root'" + password + "; database=SeguimientoAclase;";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                conexionBD.Open();

                if (textBox1.Text != "" && textBox2.Text != "" )
                {
                    comando = new MySqlCommand("update maestro set nombre_maestro=@nombre_maestro,materia=@materia where id_grupo=@nombre_maestro", conexionBD); //instruccion sql para modificar
                    comando.Parameters.Add("@nombre_maestro", MySqlDbType.VarChar).Value = textBox1.Text; //lo que se ingrese en el textbox1 se modificará y se almacenará  en el campo  id_Trabajador
                    comando.Parameters.Add("@materia", MySqlDbType.VarChar).Value = textBox2.Text;//lo que se ingrese en el textbox2 se modificará y se almacenará  en el campo nombre
                    

                    comando.ExecuteNonQuery(); // instruccion para ejecutar los comandos para agregar parametros

                    MessageBox.Show("registro correcto, registro modificado");//mensaje al usuario que realizo correctamente la modificacion
                }

                conexionBD.Close(); //se cierra la conexion



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);

            }
        }


        //--------------------ELIMINAR----------------------------//
        private void button3_Click(object sender, EventArgs e)
        {
            string servidor = "";
            string puerto = "";
            string usuario = "";
            string password = "";

            string cadenaConexion = "server='localhost'" + servidor + "; port='3307'" + puerto + "; user id='root'" + usuario + "; password='root'" + password + "; database=SeguimientoAclase;";


            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                conexionBD.Open();


                comando = new MySqlCommand("delete from maestro where nombre_maestro='" + textBox1.Text + "'", conexionBD); // el la varibale comando siempre va la instruccion sql  de lo que se desea hacer, en este caso de eliminar un registro, pormedio del campo id_trabajador
                comando.ExecuteNonQuery(); // se ejecuta el comando, es decir la eliminación
                MessageBox.Show("registro eliminado"); //se manda un mensaje de ke se realizó correctamente la eliminacion
                conexionBD.Close();  // se cierra la conexion, la conexion siempre se debe abrir y cerrar, si se deja abierta puede causar daños

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ELIMINAR EL REGISTTRO: " + ex.Message);
            }
        }


        //--------------------BUSCAR----------------------------//
        private void button4_Click(object sender, EventArgs e)
        {


            string servidor = "";
            string puerto = "";
            string usuario = "";
            string password = "";

            string cadenaConexion = "server='localhost'" + servidor + "; port='3307'" + puerto + "; user id='root'" + usuario + "; password='root'" + password + "; database=SeguimientoAclase;";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                conexionBD.Open();
                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    comando = new MySqlCommand("select * from maestro where nombre_maestro='" + textBox1.Text + "'", conexionBD);// se almacena la instruccion sql(consulta sql) para mostrar todos los datos  de la clave introducida por el usuario en el textbox3 que está aún lado del boton de buscar, todo esto por medio de la variable conexion que almacena la cadena de conexion
                    lector = comando.ExecuteReader(); // la variable lector almacenara los resultados de la ejecucion del comando

                }
                else
                {
                    if (textBox1.Text == "" && textBox2.Text != "" )
                    {
                        comando = new MySqlCommand("select * from maestro where materia='" + textBox2.Text + "'", conexionBD);// se almacena la instruccion sql(consulta sql) para mostrar todos los datos  de la clave introducida por el usuario en el textbox3 que está aún lado del boton de buscar, todo esto por medio de la variable conexion que almacena la cadena de conexion
                        lector = comando.ExecuteReader(); // la variable lector almacenara los resultados de la ejecucion del comando
                    }
                   

                }
                //comando = new MySqlCommand("select * from grupo where id_grupo='" + textBox1.Text + "'", conexionBD);// se almacena la instruccion sql(consulta sql) para mostrar todos los datos  de la clave introducida por el usuario en el textbox3 que está aún lado del boton de buscar, todo esto por medio de la variable conexion que almacena la cadena de conexion
                //lector = comando.ExecuteReader(); // la variable lector almacenara los resultados de la ejecucion del comando

                if (lector.Read()) // si el lector obtiene datos de la consulta, es decir, si el lector lee
                { //entonces
                  //muestra lo que hay en el panel, el panel es un elemento que permite agrupar más elementos, solo es para que se vea más ordenado
                    textBox1.Text = lector["nombre_maestro"].ToString(); // al textbox1 se la va asignar lo que lector haya leído  con el campo id_grupo
                    textBox2.Text = lector["materia"].ToString(); // al textbox2 se le va asignar lo que el lector tenga en el campo jefe_grupo
                  

                    //todo esto es para que en cada elemento donde el usuario modificará posteriormente, se puede consultar los datos que ya están registrados
                }
                else
                { //de lo contrario, es decir si el id_trabajador no existe o no se encuentra registrado 

                    MessageBox.Show("la clave no existe"); // mensaje al usuario de la clave incorrecta
                }
                conexionBD.Close(); //se cierra la



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al BUSCAR: " + ex.Message);
            }

        }
    }
}
