using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.VisualBasic;

namespace Sistema
{
    class Modulo
    {
        private readonly SqlConnection sqlConnection;
        public Modulo()
        {
            // Inicializar la conexión en el constructor
            string connectionString = "data source = " + Convert.ToString(LeerHostDB()) + "; initial catalog = Comercio; integrated security = true";
            sqlConnection = new SqlConnection(connectionString);
        }
        public string LeerHostDB()
        {
            if (File.Exists(@"C:\ABM\ip.txt"))
            {
                StreamReader SR = File.OpenText(@"C:\ABM\ip.txt");

                string Line = SR.ReadLine();
                SR.Close();
                return Line;
            }
            return default;
        }   
        public bool YaExisteSQL(string sql)
        {
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "existe");

            return dataSet.Tables["existe"].Rows.Count >= 1;
        }
        public decimal VNum(string NTexto)
        {
            return System.Convert.ToDecimal(Convert.ToDouble(NTexto.Trim().Replace(",", ".")));
        }
        public bool SQL_Accion(string Sql_de_accion)
        {
            //SqlConnection sqlConnection = new SqlConnection("data source = " + Convert.ToString(LeerHostDB()) + "; initial catalog = Comercio; integrated security = true");
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            bool salida = true;
            try
            {
                sqlConnection.Open();
                if (Sql_de_accion.ToString().ToUpper().IndexOf("INSERT") != -1)
                {
                    dataAdapter.InsertCommand = new SqlCommand(Sql_de_accion, sqlConnection);
                    dataAdapter.InsertCommand.ExecuteNonQuery();
                }               

                else if ((Sql_de_accion.ToUpper().IndexOf("UPDATE")) != -1)
                {
                    dataAdapter.UpdateCommand = new SqlCommand(Sql_de_accion, sqlConnection);
                    dataAdapter.UpdateCommand.ExecuteNonQuery();
                }
                else if ((Sql_de_accion.ToUpper().IndexOf("DELETE")) != -1)
                {
                    dataAdapter.DeleteCommand = new SqlCommand(Sql_de_accion, sqlConnection);
                    dataAdapter.DeleteCommand.ExecuteNonQuery();
                }
                else
                {
                    salida = false;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
                salida = false;
            }
            sqlConnection.Close();
            return salida;
        }
        public string NumSQL(string numero)
        {
            return Convert.ToString(VNum(numero)).Trim().Replace(",", ".");
        }
        public string RellenaNum(int numero , int cantidad)
        {
            string snum = Convert.ToString(numero).Trim();
            return "00000000000000000000".Substring(0, cantidad - snum.Length) + snum;
        }
        public string FechaSQL(DateTime fecha)
        {
            return "'" + RellenaNum(fecha.Year, 4) + RellenaNum(fecha.Month, 2) + RellenaNum(fecha.Day, 2) + "'";
        }
    }
}
