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
            string usuarioIngresado = tUsuario.Text.Trim();
            string contraseñaIngresada = tClave.Text.Trim();
            bool autenticado = false;
            string tipoUsuario = "";
            string nombre = "", apellido = "";

            using (SqlConnection conexion = new SqlConnection("data source=" + mod.LeerHostDB() + "; initial catalog=Comercio; integrated security=true"))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 'Usuario' AS Tipo, NombreUsu AS Nombre, ApellidoUsu AS Apellido 
                FROM Usuarios WHERE UsuarioUsu = @Usuario AND ClaveUsu = @Contraseña
                UNION
                SELECT 'Cliente' AS Tipo, NombreClien AS Nombre, ApellidoClien AS Apellido 
                FROM Clientes WHERE UsuarioClien = @Usuario AND ClaveClien = @Contraseña";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuarioIngresado);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseñaIngresada);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tipoUsuario = reader["Tipo"].ToString();
                                nombre = reader["Nombre"].ToString();
                                apellido = reader["Apellido"].ToString();
                                autenticado = true;
                            }
                        }
                    }

                    if (autenticado)
                    {
                        MenuPrincipal menu = new MenuPrincipal(tipoUsuario);
                        menu.Text = $"Bienvenido {nombre} {apellido} ({tipoUsuario})";
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tClave.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void bRegistrar_Click(object sender, EventArgs e)
            {
                RegistroUsuario registroUsuario = new RegistroUsuario();
                registroUsuario.Show();
            }
        }
    }

