using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SME
{
    public static class Database
    {
        private static OracleConnection oc;

        /// <summary>
        /// Het initiëren van de databaseinstellingen
        /// </summary>
        public Database()
        {
            oc = new OracleConnection();
            oc.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SMEConnectionString"].ConnectionString;
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
