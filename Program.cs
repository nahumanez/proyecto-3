using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Modulo mod = new Modulo();
            SqlConnection sqlConnection = new SqlConnection("data source = " + Convert.ToString(mod.LeerHostDB()) + "; initial catalog = Comercio; integrated security = true");
            sqlConnection.Open();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            sqlConnection.Close();
        }
    }
}
