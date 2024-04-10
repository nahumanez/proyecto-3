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
    public partial class Proveedores : Form
    {
        private readonly SqlConnection sqlConnection;
        Modulo mod = new Modulo();
        public Proveedores()
        {
            InitializeComponent();

            string connectionString = "data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void Proveedores_Load(object sender, EventArgs e)
        {
            Buscar("ApeYNom LIKE'" + textBox1.Text + "%'");

            //this.Text = "Bienvenido ";
        }        
        private void Buscar(string condicion)
        {
            //string consulta1;
            // consulta1 = "data source = " + mod.LeerHostDB() + "; initial catalog = Comercio; integrated security = true";
            string consulta2;            
            consulta2 = "SELECT NProvee, ApeYNom, DocumentoProvee, CuitProvee, DomicilioProvee, PostalProvee, LocalidadProvee, ProvinciaProvee, TelefonoProvee, FechaNacimientoProvee, ComentariosProvee, EMailProvee," +
            "Estado FROM vista_proveedores WHERE " + condicion + " ORDER BY ApeYNom";          
            //SqlConnection sqlConnection = new SqlConnection(consulta1);
            //sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta2, sqlConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Proveedores");
            if (dataSet.Tables["Proveedores"].Rows.Count == 0)
            {
                dataGridView1.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                label2.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = dataSet.Tables["Proveedores"];
                dataGridView1.Refresh();
                dataGridView1.Visible = true;
                label2.Visible = true;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FilaClick(e.RowIndex);
        }
        private void dataGridView1_RowEnter(Object sender, DataGridViewCellEventArgs e)
        {
            FilaClick(e.RowIndex);
        }        
        private void FilaClick(int fila)
        {                                    
            string tfila;

            if (Information.IsNothing(dataGridView1.Rows[fila].Cells[0].Value))
            {
                label2.Text = "0";
                panel1.Visible = false;
                panel2.Visible = false;
                return;
            }
            else
            {
                tfila = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                label2.Text = tfila.ToString();
                CargarCamposProveedores();
            }

        }
        private void CargarCamposProveedores()
        {
            if (Conversion.Val(label2.Text) == 0)
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
                consulta2 = "SELECT UPPER(LTRIM(RTRIM(ISNULL(ApellidoProvee, '****')))) AS apellido, " +
                "UPPER(LTRIM(RTRIM(ISNULL(NombreProvee, '****')))) AS nombre, ISNULL(DocumentoProvee, 0) AS documento, ISNULL(CuitProvee, 0) AS cuit," +
                "LTRIM(RTRIM(ISNULL(DomicilioProvee, ''))) AS domicilio, LTRIM(RTRIM(ISNULL(PostalProvee, ''))) AS postal, LTRIM(RTRIM(ISNULL(LocalidadProvee, ''))) AS localidad," +
                "LTRIM(RTRIM(ISNULL(ProvinciaProvee, ''))) AS provincia, LTRIM(RTRIM(ISNULL(TelefonoProvee, ''))) AS telefono, FechaNacimientoProvee AS nacimiento," +
                "LTRIM(RTRIM(ISNULL(ComentariosProvee, ''))) AS comentarios, LTRIM(RTRIM(ISNULL(EMailProvee, ''))) AS email, ISNULL(Estado, 0) AS estado from Proveedores where NProvee=";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta2 + Conversion.Val(label2.Text), sqlConnection);
                //Conversion.Val(label2.Text)
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Proveedores");

                textBox2.Text = dataSet.Tables["Proveedores"].Rows[0]["apellido"].ToString();
                textBox3.Text = dataSet.Tables["Proveedores"].Rows[0]["nombre"].ToString();
                textBox4.Text = dataSet.Tables["Proveedores"].Rows[0]["documento"].ToString();
                textBox5.Text = dataSet.Tables["Proveedores"].Rows[0]["cuit"].ToString();
                textBox6.Text = dataSet.Tables["Proveedores"].Rows[0]["domicilio"].ToString();
                textBox7.Text = dataSet.Tables["Proveedores"].Rows[0]["postal"].ToString();
                textBox11.Text = dataSet.Tables["Proveedores"].Rows[0]["localidad"].ToString();
                textBox12.Text = dataSet.Tables["Proveedores"].Rows[0]["provincia"].ToString();
                textBox8.Text = dataSet.Tables["Proveedores"].Rows[0]["telefono"].ToString();
                dateTimePicker1.Value = (DateTime)dataSet.Tables["Proveedores"].Rows[0]["nacimiento"];
                textBox10.Text = dataSet.Tables["Proveedores"].Rows[0]["comentarios"].ToString();
                textBox9.Text = dataSet.Tables["Proveedores"].Rows[0]["email"].ToString();
                checkBox1.Checked = Convert.ToBoolean(dataSet.Tables["Proveedores"].Rows[0]["estado"]);
            }
        }        
        private void bBuscar_Click(object sender, EventArgs e)
        {
            Buscar("ApeYNom LIKE'" + textBox1.Text + "%'");
            
        }
        private void pBorrar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Buscar("ApeYNom LIKE'" + textBox1.Text + "%'");
        }
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está por ELIMINAR definitivamente el Proveedor: " + textBox2.Text.Trim().ToUpper() +
            ", Es algo EXTREMO Está SEGURO ? ", "Eliminar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            // Ejecutamos el Delete

            if (mod.SQL_Accion("DELETE FROM Proveedores WHERE NProvee=" + Conversion.Val(label2.Text)) == false)
            {
                MessageBox.Show(" Hubo un Errar al intentar Borrar el cliente, Reintente, y Si el Error Persiste, " +
                "Anote Todos los Datos que Quizo Ingresar y Comuníquese con el Programador(Otra Vez)", "Eliminar Proveedor",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Buscar(" NProvee=" + Conversion.Val(label2.Text));
                MessageBox.Show("El Proveedor fue ELIMINADO de la Base de Datos. ");
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
            if (mod.SQL_Accion("UPDATE Proveedores SET ApellidoProvee='" + textBox2.Text.Trim().ToUpper().Replace("'", "´") +
                "', NombreProvee = '" + textBox3.Text.Trim().ToUpper().Replace("'", "´") +
                "',DocumentoProvee = '" + Conversion.Val(textBox4.Text.Trim().Replace(".", "").Replace(" ", "").Replace(",", "")) +
                "', CuitProvee = '" + textBox5.Text.Trim().ToUpper().Replace("'", "´") +
                "', DomicilioProvee = '" + textBox6.Text.Trim().ToUpper().Replace("'", "´") +
                "', PostalProvee = '" + textBox7.Text.Trim().ToUpper().Replace("'", "´") +
                "', LocalidadProvee = '" + textBox11.Text.Trim().ToUpper().Replace("'", "´") +
                "', ProvinciaProvee = '" + textBox12.Text.Trim().ToUpper().Replace("'", "´") +
                "', TelefonoProvee = '" + textBox8.Text.Trim().Replace(".", "´") +
                "', FechaNacimientoProvee = " + mod.FechaSQL(dateTimePicker1.Value) +
                ", ComentariosProvee = '" + textBox10.Text.Trim().ToUpper().Replace("'", "´") +
                "', EmailProvee = '" + textBox9.Text.Trim().ToUpper().Replace("'", "´") +
                "', Estado = '" + checkBox1.Checked +
                "' WHERE NProvee = " + mod.VNum(label2.Text)) == true)
            {
                MessageBox.Show("Cambios Realizados Correctamente.", "Editar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar(" NProvee =" + mod.VNum(label2.Text));
            }
            else
            {
                MessageBox.Show("Se Produjo un Error al Querer Guardar los Datos del Proveedor, Reintente, y si el Error Persiste, " +
                " Anote Todos los Datos que Quizo Ingresar y Comuniquese con el Programador (0tra Vez).",
                "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }        
        private void bNuevo_Click(object sender, EventArgs e)
        {
            string consulta; 
            consulta = "insert into Proveedores (apellidoprovee, nombreprovee, documentoprovee, cuitprovee, domicilioprovee, postalprovee, localidadprovee, provinciaprovee, telefonoprovee, fechanacimientoprovee, comentariosprovee, emailprovee, estado) values('*****', '*****', 0, '', '', '', '', '', '',  getdate(), '', '', 1)";
            if (mod.SQL_Accion(consulta))
            {
                Buscar(" ApeYNom LIKE '****%' ");
                MessageBox.Show("Se ha creado un nuevo registro para el proveedor que desea ingresar, seleccione la línea nueva," +
                "cargue los datos y luego confirme con el botón 'Aceptar Cambios'.");
            }
        }       
    }
}