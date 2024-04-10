using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sistema
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Modulo mod = new Modulo();        
        private void bEntrar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true");

            string usuarioIngresado = tUsuario.Text;
            string contraseñaIngresada = tClave.Text;

            try
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE UsuarioUsu = @Usuario AND ClaveUsu = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Usuario", usuarioIngresado);
                cmd.Parameters.AddWithValue("@Contraseña", contraseñaIngresada);

                string consulta = "select NombreUsu, ApellidoUsu from Usuarios where UsuarioUsu =" + "'" + usuarioIngresado + "'" + " AND ClaveUsu =" + "'" + contraseñaIngresada + "'";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, conexion);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Usuarios");

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MenuPrincipal menuPrincipal = new MenuPrincipal();
                    string nombre = dataSet.Tables["Usuarios"].Rows[0]["NombreUsu"].ToString();
                    string apellido = dataSet.Tables["Usuarios"].Rows[0]["ApellidoUsu"].ToString();

                    menuPrincipal.Text = "Bienvenido " + nombre + " " + apellido;

                    menuPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void bRegistrar_Click(object sender, EventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.Show();
        }
    }
}
