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
using Microsoft.VisualBasic;

namespace Sistema
{
    public partial class Clientes : Form
    {
        private readonly SqlConnection sqlConnection;

        Modulo mod = new Modulo();
        public Clientes()
        {
            InitializeComponent();

            string connectionString = "data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            Buscar("ApellidoClien LIKE'" + textBox1.Text + "%'");
        }
        private void Buscar(string condicion)
        {            
            string consulta2;
            consulta2 = "SELECT id, ApellidoClien, NombreClien, DocumentoClien, CuitClien, DomicilioClien, PostalClien, LocalidadClien, ProvinciaClien, TelefonoClien, FechaNacimientoClien, ComentariosClien, EMailClien," +
            "Estado, UsuarioClien, ClaveClien FROM Clientes WHERE " + condicion + " ORDER BY id";
            //SqlConnection sqlConnection = new SqlConnection("data source = " + mod.LeerHostDB() + "; initial catalog = Comercio; integrated security = true");
            //sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta2, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Clientes");
            bool primeraVez = true;
            if (dataSet.Tables["Clientes"].Rows.Count == 0 && !primeraVez)
            {
                dataGridView1.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                lLegajo.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = dataSet.Tables["Clientes"];
                dataGridView1.Refresh();
                dataGridView1.Visible = true;
                lLegajo.Visible = true;
            }
            primeraVez = false;
        }
        private void dataGridView1_CellEnter(Object sender, DataGridViewCellEventArgs e)
        {
            FilaClick(e.RowIndex);
        }
        private void FilaClick(int fila)
        {
            string tfila;

            if (Information.IsNothing(dataGridView1.Rows[fila].Cells[0].Value))
            {
                lLegajo.Text = "0";
                panel1.Visible = false;
                panel2.Visible = false;
                return;
            }
            else
            {
                tfila = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                lLegajo.Text = tfila.ToString();
                CargarCamposClientes();
            }

        }
        private void CargarCamposClientes()
        {
            if (Conversion.Val(lLegajo.Text) == 0)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                return;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = true;
                //SqlConnection sqlConnection = new SqlConnection("data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true");

                string consulta2;
                consulta2 = "SELECT UPPER(LTRIM(RTRIM(ISNULL(ApellidoClien, '****')))) AS apellido, " +
                "UPPER(LTRIM(RTRIM(ISNULL(NombreClien, '****')))) AS nombre, ISNULL(DocumentoClien, 0) AS documento, ISNULL(CuitClien, 0) AS cuit," +
                "LTRIM(RTRIM(ISNULL(DomicilioClien, ''))) AS domicilio, LTRIM(RTRIM(ISNULL(PostalClien, ''))) AS postal, LTRIM(RTRIM(ISNULL(LocalidadClien, ''))) AS localidad," +
                "LTRIM(RTRIM(ISNULL(ProvinciaClien, ''))) AS provincia, LTRIM(RTRIM(ISNULL(TelefonoClien, ''))) AS telefono, FechaNacimientoClien AS nacimiento," +
                "LTRIM(RTRIM(ISNULL(ComentariosClien, ''))) AS comentarios, LTRIM(RTRIM(ISNULL(EMailClien, ''))) AS email, ISNULL(Estado, 0) AS estado, LTRIM(RTRIM(ISNULL(UsuarioClien, ''))) AS usuario, LTRIM(RTRIM(ISNULL(ClaveClien, ''))) AS clave from Clientes where id=";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta2 + Conversion.Val(lLegajo.Text), sqlConnection);
                //Conversion.Val(label2.Text)
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Clientes");

                textBox2.Text = dataSet.Tables["Clientes"].Rows[0]["apellido"].ToString();
                textBox3.Text = dataSet.Tables["Clientes"].Rows[0]["nombre"].ToString();
                textBox4.Text = dataSet.Tables["Clientes"].Rows[0]["documento"].ToString();
                textBox5.Text = dataSet.Tables["Clientes"].Rows[0]["cuit"].ToString();
                textBox6.Text = dataSet.Tables["Clientes"].Rows[0]["domicilio"].ToString();
                textBox7.Text = dataSet.Tables["Clientes"].Rows[0]["postal"].ToString();
                textBox11.Text = dataSet.Tables["Clientes"].Rows[0]["localidad"].ToString();
                textBox12.Text = dataSet.Tables["Clientes"].Rows[0]["provincia"].ToString();
                textBox8.Text = dataSet.Tables["Clientes"].Rows[0]["telefono"].ToString();
                dateTimePicker1.Value = (DateTime)dataSet.Tables["Clientes"].Rows[0]["nacimiento"];
                textBox10.Text = dataSet.Tables["Clientes"].Rows[0]["comentarios"].ToString();
                textBox9.Text = dataSet.Tables["Clientes"].Rows[0]["email"].ToString();
                checkBox1.Checked = Convert.ToBoolean(dataSet.Tables["Clientes"].Rows[0]["estado"]);
                textBox13.Text = dataSet.Tables["Clientes"].Rows[0]["usuario"].ToString();
                textBox14.Text = dataSet.Tables["Clientes"].Rows[0]["clave"].ToString();
            }
        }
        private void bBuscar_Click(object sender, EventArgs e)
        {
            Buscar("LocalidadClien LIKE'" + textBox1.Text + "%'");

        }
        private void pBorrar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Buscar("LocalidadClien LIKE'" + textBox1.Text + "%'");
        }
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está por ELIMINAR definitivamente el Cliente: " + textBox2.Text.Trim().ToUpper() +
            ", Es algo EXTREMO Está SEGURO ? ", "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            // Ejecutamos el Delete

            if (mod.SQL_Accion("DELETE FROM Clientes WHERE id=" + Conversion.Val(lLegajo.Text)) == false)
            {
                MessageBox.Show(" Hubo un Errar al intentar Borrar el cliente, Reintente, y Si el Error Persiste, " +
                "Anote Todos los Datos que Quizo Ingresar y Comuníquese con el Programador(Otra Vez)", "Eliminar Cliente",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Buscar(" id=" + Conversion.Val(lLegajo.Text));
                MessageBox.Show("El Cliente fue ELIMINADO de la Base de Datos. ");
            }
        }
        private void bAceptar_Click(object sender, EventArgs e)
        {
            // Para Guardar los Errores que Surjan
            string errores = "";
            //Guardamos el caracter del enter
            string enter = Constants.vbCrLf;
            if (textBox2.Text.Trim().Length < 3)
            {
                errores += "Debe completar el apellido." + enter;
            }

            if (textBox3.Text.Trim().Length < 3)
            {
                errores += "Debe Completar el nombre." + enter;
            }

            // Ejecutamos el Update
            if (mod.SQL_Accion("UPDATE Clientes SET ApellidoClien='" + textBox2.Text.Trim().ToUpper().Replace("'", "´") +
                "', NombreClien = '" + textBox3.Text.Trim().ToUpper().Replace("'", "´") +
                "',DocumentoClien = '" + Conversion.Val(textBox4.Text.Trim().Replace(".", "").Replace(" ", "").Replace(",", "")) +
                "', CuitClien = '" + textBox5.Text.Trim().ToUpper().Replace("'", "´") +
                "', DomicilioClien = '" + textBox6.Text.Trim().ToUpper().Replace("'", "´") +
                "', PostalClien = '" + textBox7.Text.Trim().ToUpper().Replace("'", "´") +
                "', LocalidadClien = '" + textBox11.Text.Trim().ToUpper().Replace("'", "´") +
                "', ProvinciaClien = '" + textBox12.Text.Trim().ToUpper().Replace("'", "´") +
                "', TelefonoClien = '" + textBox8.Text.Trim().Replace(".", "´") +
                "', FechaNacimientoClien = " + mod.FechaSQL(dateTimePicker1.Value) +
                ", ComentariosClien = '" + textBox10.Text.Trim().ToUpper().Replace("'", "´") +
                "', UsuarioClien = '" + textBox13.Text.Trim().ToUpper().Replace("'", "´") +
                "', ClaveClien = '" + textBox14.Text.Trim().ToUpper().Replace("'", "´") +
                "', EmailClien = '" + textBox9.Text.Trim().ToUpper().Replace("'", "´") +
                "', Estado = '" + checkBox1.Checked +
                "' WHERE id = " + mod.VNum(lLegajo.Text)) == true)
            {
                MessageBox.Show("Cambios Realizados Correctamente.", "Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar(" id =" + mod.VNum(lLegajo.Text));
            }
            else
            {
                MessageBox.Show("Se Produjo un Error al Querer Guardar los Datos del Cliente, Reintente, y si el Error Persiste, " +
                " Anote Todos los Datos que Quizo Ingresar y Comuniquese con el Programador (0tra Vez).",
                "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bNuevo_Click(object sender, EventArgs e)
        {
            string consulta;
            consulta = "insert into Clientes (apellidoclien, nombreclien, documentoclien, cuitclien, domicilioclien, postalclien, localidadclien, provinciaclien, telefonoclien, fechanacimientoclien, comentariosclien, emailclien, estado) values('*****', '*****', 0, '', '', '', '', '', '',  getdate(), '', '', 1)";
            if (mod.SQL_Accion(consulta))
            {
                Buscar(" ApellidoClien LIKE '%' ");
                MessageBox.Show("Se ha creado un nuevo registro para el cliente que desea ingresar, seleccione la línea nueva," +
                "cargue los datos y luego confirme con el botón 'Aceptar Cambios'.");
            }
        }
    }
}
