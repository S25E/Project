using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace SME
{
    public static class Database
    {
        private static OracleConnection oc;

        /// <summary>
        /// Het initiëren van de databaseinstellingen
        /// </summary>
        static Database()
        {
            oc = new OracleConnection();
            oc.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SMEConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Het ophalen van informatie uit de database
        /// </summary>
        /// <param name="query"></param>
        /// <returns>En een DataTable met de opgehaalde infromatie</returns>
        public static DataTable GetData(string query, Dictionary<string, object> waardes = default(Dictionary<string, object>))
        {
            DataTable dt = new DataTable();

            try
            {
                oc.Open();
                OracleCommand command = toOracleCommand(query, waardes);
                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(dt);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                oc.Close();
            }

            return dt;

        }

        /// <summary>
        /// Het uitvoeren van een SQL-commando
        /// </summary>
        /// <param name="query"></param>
        public static void Execute(string query, Dictionary<string, object> waardes = default(Dictionary<string, object>))
        {   
            try
            {
                oc.Open();
                OracleCommand command = toOracleCommand(query, waardes);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oc.Close();
            }
        }

        private static OracleCommand toOracleCommand(string query, Dictionary<string, object> waardes = default(Dictionary<string, object>))
        {
            OracleCommand command = new OracleCommand(query, oc);

            if (!waardes.Equals(default(Dictionary<string, object>)))
            {
                foreach (KeyValuePair<string, object> waarde in waardes)
                {
                    command.Parameters.Add(waarde.Key, waarde.Value);
                }
            }

            return command;
        }
    }
}
