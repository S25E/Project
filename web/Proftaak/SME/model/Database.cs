using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Windows.Forms;

namespace SME
{
    public class Database
    {
        private OracleConnection oc;

        /// <summary>
        /// Het initiëren van de databaseinstellingen
        /// </summary>
        public Database()
        {
            this.oc = new OracleConnection();
            String pcn = "dbi300480";
            String pw = "HH9VTIT7qf";
            oc.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
        }

        /// <summary>
        /// Het ophalen van informatie uit de database
        /// </summary>
        /// <param name="query"></param>
        /// <returns>En een DataTable met de opgehaalde infromatie</returns>
        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                this.oc.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(query, this.oc);
                adapter.Fill(dt);
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR! " + e.Message + " " + query);
            }
            finally
            {
                this.oc.Close();
            }

            return dt;

        }

        /// <summary>
        /// Het uitvoeren van een SQL-commando
        /// </summary>
        /// <param name="query"></param>
        public void Execute(string query)
        {
            OracleCommand command = new OracleCommand(query, this.oc);

            try
            {
                this.oc.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR! " + e.Message + " " + query);
            }
            finally
            {
                this.oc.Close();
            }

        }

        /// <summary>
        /// Het escapen van een string, zodat hackers geen kans hebben om te hacken.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Escape(string input)
        {
            return input.Replace("'", "\'");
        }
    }
}
