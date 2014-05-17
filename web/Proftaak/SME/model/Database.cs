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
        public static DataTable GetData(OracleCommand command, Dictionary<string, string> waardes = default(Dictionary<string, string>))
        {
            DataTable dt = new DataTable();

            try
            {
                oc.Open();
                command.Connection = oc;

                if (!waardes.Equals(default(Dictionary<string, string>)))
                {
                    foreach(KeyValuePair<string, string> waarde in waardes){
                        command.Parameters.Add(waarde.Key, waarde.Value);
                    }
                }

                OracleDataAdapter adapter = new OracleDataAdapter(command);

                adapter.Fill(dt);
            }
            catch(Exception e)
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
        public static void Execute(OracleCommand command)
        {   
            try
            {
                oc.Open();
                command.Connection = oc;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                oc.Close();
            }
        }
    }
}
