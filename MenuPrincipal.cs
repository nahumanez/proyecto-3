﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Sistema
{
    public partial class MenuPrincipal : Form
    {
        private string tipoUsuario;

        public MenuPrincipal(string tipoUsuario) // Nuevo constructor que recibe tipo de usuario
        {
            InitializeComponent();
            this.tipoUsuario = tipoUsuario;
            ConfigurarInterfaz();
        }

        private void ConfigurarInterfaz()
        {
            if (tipoUsuario == "Cliente")
            {
                bUsuarios.Visible = false;     // Ocultar gestión de usuarios
                bProveedores.Visible = false;  // Ocultar gestión de proveedores
            }
        }

        private void bClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
        }

        private void bProveedores_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
        }

        private void bUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
        }
    }

}
