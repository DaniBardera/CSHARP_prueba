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
using MySql.Data.MySqlClient;

namespace EjemploConexionBBDD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();

            MySqlCommand comando = new MySqlCommand("" +
                "SELECT * FROM usuarios WHERE" +
                " usuario = '" + textBox1.Text +
                "' AND pass = '" + textBox2.Text +
                "' ;", conexion);

            MySqlDataReader resultado = comando.ExecuteReader();

            if (resultado.Read())
            {
                // ocultamos la ventana en la que estamos
                this.Visible = false;
               
                // creamos una nueva ventana dek tipo VentanaPrincipal
                VentanaInicio ventana = new VentanaInicio();
                ventana.Visible = true;

                MessageBox.Show("Acceso Correcto", "USUARIO OK");
                this.Visible = false; //Oculta la ventana de login
            }
            else
            {
                MessageBox.Show("Accceso Denegado", "USUARIO O CONTRASEÑA ERRONEOS");
            }
        }
    }
}
