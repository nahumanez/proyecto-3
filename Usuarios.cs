using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class Usuarios : Form
    {
        private readonly SqlConnection sqlConnection;
        Modulo mod = new Modulo();
        public Usuarios()
        {
            InitializeComponent();
            string connectionString = "data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            Buscar("ApellidoUsu LIKE'" + textBox1.Text + "%'");
        }
        private void Buscar(string condicion)
        {
            //string consulta1;
            //consulta1 = "data source = " + mod.LeerHostDB() + "; initial catalog = Comercio; integrated security = true";
            string consulta2;
            consulta2 = "SELECT id, NombreUsu, ApellidoUsu, DocumentoUsu, CuitUsu, DomicilioUsu, PostalUsu, LocalidadUsu, ProvinciaUsu, TelefonoUsu, FechaNacimientoUsu, ComentariosUsu, EMailUsu," +
            "Estado, UsuarioUsu, ClaveUsu FROM Usuarios WHERE " + condicion + " ORDER BY id";
            //SqlConnection sqlConnection = new SqlConnection(consulta1);
            //sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta2, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Usuarios");
            if (dataSet.Tables["Usuarios"].Rows.Count == 0)
            {
                dataGridView1.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                lLegajo.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = dataSet.Tables["Usuarios"];
                dataGridView1.Refresh();
                dataGridView1.Visible = true;
                lLegajo.Visible = true;
            }
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
                CargarCamposUsuarios();
            }

        }
        private void CargarCamposUsuarios()
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
                //String consulta1;
                //consulta1 = "data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true";
                //SqlConnection sqlConnection = new SqlConnection(consulta1);

                string consulta2;
                consulta2 = "SELECT UPPER(LTRIM(RTRIM(ISNULL(ApellidoUsu, '****')))) AS apellido, " +
                "UPPER(LTRIM(RTRIM(ISNULL(NombreUsu, '****')))) AS nombre, ISNULL(DocumentoUsu, 0) AS documento, ISNULL(CuitUsu, 0) AS cuit," +
                "LTRIM(RTRIM(ISNULL(DomicilioUsu, ''))) AS domicilio, LTRIM(RTRIM(ISNULL(PostalUsu, ''))) AS postal, LTRIM(RTRIM(ISNULL(LocalidadUsu, ''))) AS localidad," +
                "LTRIM(RTRIM(ISNULL(ProvinciaUsu, ''))) AS provincia, LTRIM(RTRIM(ISNULL(TelefonoUsu, ''))) AS telefono, FechaNacimientoUsu AS nacimiento," +
                "LTRIM(RTRIM(ISNULL(ComentariosUsu, ''))) AS comentarios, LTRIM(RTRIM(ISNULL(EMailUsu, ''))) AS email, ISNULL(Estado, 0) AS estado, LTRIM(RTRIM(ISNULL(UsuarioUsu, ''))) AS usuario, LTRIM(RTRIM(ISNULL(ClaveUsu, ''))) AS clave from Usuarios where NUsu=";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta2 + Conversion.Val(lLegajo.Text), sqlConnection);
                //Conversion.Val(label2.Text)
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Usuarios");

                textBox2.Text = dataSet.Tables["Usuarios"].Rows[0]["apellido"].ToString();
                textBox3.Text = dataSet.Tables["Usuarios"].Rows[0]["nombre"].ToString();
                textBox4.Text = dataSet.Tables["Usuarios"].Rows[0]["documento"].ToString();
                textBox5.Text = dataSet.Tables["Usuarios"].Rows[0]["cuit"].ToString();
                textBox6.Text = dataSet.Tables["Usuarios"].Rows[0]["domicilio"].ToString();
                textBox7.Text = dataSet.Tables["Usuarios"].Rows[0]["postal"].ToString();
                textBox11.Text = dataSet.Tables["Usuarios"].Rows[0]["localidad"].ToString();
                textBox12.Text = dataSet.Tables["Usuarios"].Rows[0]["provincia"].ToString();
                textBox8.Text = dataSet.Tables["Usuarios"].Rows[0]["telefono"].ToString();
                dateTimePicker1.Value = (DateTime)dataSet.Tables["Usuarios"].Rows[0]["nacimiento"];
                textBox10.Text = dataSet.Tables["Usuarios"].Rows[0]["comentarios"].ToString();
                textBox9.Text = dataSet.Tables["Usuarios"].Rows[0]["email"].ToString();
                checkBox1.Checked = Convert.ToBoolean(dataSet.Tables["Usuarios"].Rows[0]["estado"]);
                textBox13.Text = dataSet.Tables["Usuarios"].Rows[0]["usuario"].ToString();
                textBox14.Text = dataSet.Tables["Usuarios"].Rows[0]["clave"].ToString();
            }
        }
        private void bBuscar_Click(object sender, EventArgs e)
        {
            Buscar("LocalidadUsu LIKE'" + textBox1.Text + "%'");

        }
        private void pBorrar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Buscar("LocalidadUsu LIKE'" + textBox1.Text + "%'");
        }
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está por ELIMINAR definitivamente el Usuario: " + textBox2.Text.Trim().ToUpper() +
            ", Es algo EXTREMO Está SEGURO ? ", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            // Ejecutamos el Delete

            if (mod.SQL_Accion("DELETE FROM Usuarios WHERE NUsu=" + Conversion.Val(lLegajo.Text)) == false)
            {
                MessageBox.Show(" Hubo un Errar al intentar Borrar el usuario, Reintente, y Si el Error Persiste, " +
                "Anote Todos los Datos que Quizo Ingresar y Comuníquese con el Programador(Otra Vez)", "Eliminar Usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Buscar(" NUsu =" + Conversion.Val(lLegajo.Text));
                MessageBox.Show("El Usuario fue ELIMINADO de la Base de Datos. ");
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
            if (mod.SQL_Accion("UPDATE Usuarios SET ApellidoUsu='" + textBox2.Text.Trim().ToUpper().Replace("'", "´") +
                "', NombreUsu = '" + textBox3.Text.Trim().ToUpper().Replace("'", "´") +
                "',DocumentoUsu = '" + Conversion.Val(textBox4.Text.Trim().Replace(".", "").Replace(" ", "").Replace(",", "")) +
                "', CuitUsu = '" + textBox5.Text.Trim().ToUpper().Replace("'", "´") +
                "', DomicilioUsu = '" + textBox6.Text.Trim().ToUpper().Replace("'", "´") +
                "', PostalUsu = '" + textBox7.Text.Trim().ToUpper().Replace("'", "´") +
                "', LocalidadUsu = '" + textBox11.Text.Trim().ToUpper().Replace("'", "´") +
                "', ProvinciaUsu = '" + textBox12.Text.Trim().ToUpper().Replace("'", "´") +
                "', TelefonoUsu = '" + textBox8.Text.Trim().Replace(".", "´") +
                "', FechaNacimientoUsu = " + mod.FechaSQL(dateTimePicker1.Value) +
                ", ComentariosUsu = '" + textBox10.Text.Trim().ToUpper().Replace("'", "´") +
                "', EmailUsu = '" + textBox9.Text.Trim().ToUpper().Replace("'", "´") +
                "', UsuarioUsu = '" + textBox13.Text.Trim().ToUpper().Replace("'", "´") +
                "', ClaveUsu = '" + textBox14.Text.Trim().ToUpper().Replace("'", "´") +
                "', Estado = '" + checkBox1.Checked +
                "' WHERE NUsu = " + mod.VNum(lLegajo.Text)) == true)
            {
                MessageBox.Show("Cambios Realizados Correctamente.", "Editar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar(" NUsu =" + mod.VNum(lLegajo.Text));
            }
            else
            {
                MessageBox.Show("Se Produjo un Error al Querer Guardar los Datos del Usuario, Reintente, y si el Error Persiste, " +
                " Anote Todos los Datos que Quizo Ingresar y Comuniquese con el Programador (0tra Vez).",
                "Editar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bNuevo_Click(object sender, EventArgs e)
        {
            string consulta;
            consulta = "insert into Usuarios (apellidousu, nombreusu, documentousu, cuitusu, domiciliousu, postalusu, localidadusu, provinciausu, telefonousu, fechanacimientousu, comentariosusu, emailusu, estado) values('*****', '*****', 0, '', '', '', '', '', '',  getdate(), '', '', 1)";
            if (mod.SQL_Accion(consulta))
            {
                Buscar(" ApeYNom LIKE '%' ");
                MessageBox.Show("Se ha creado un nuevo registro para el usuario que desea ingresar, seleccione la línea nueva," +
                "cargue los datos y luego confirme con el botón 'Aceptar Cambios'.");
            }
        }
    }
}
