﻿using System;
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
        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                oc.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(query, oc);
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
        public static void Execute(string query)
        {
            OracleCommand command = new OracleCommand(query, this.oc);

            try
            {
                this.oc.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                this.oc.Close();
            }

        }
    }
}