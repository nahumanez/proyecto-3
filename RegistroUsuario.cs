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

namespace Sistema
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        Modulo mod = new Modulo();
        private void bRegistrarse_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string usuario = textBox3.Text;
            string contraseña = textBox4.Text;

            // Validar que los campos no estén vacíos (puedes agregar más validaciones según tus necesidades)
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Todos los campos deben ser completados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection("data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true"))
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Insertar el nuevo usuario en la base de datos
                    string query = "INSERT INTO Usuarios (NombreUsu, ApellidoUsu, UsuarioUsu, ClaveUsu) VALUES (@Nombre, @Apellido, @Usuario, @Contraseña)";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellido", apellido);
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
