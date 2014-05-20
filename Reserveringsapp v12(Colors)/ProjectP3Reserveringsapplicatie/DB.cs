using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ProjectP3Reserveringsapplicatie
{
    class DB
    {
        public OracleConnection conn;

        /// <summary>
        /// Alle verbindingen gaan via deze database class
        /// </summary>
        public DB()
        {
            //de verbindingsgegevens voor de connectie met oracle (vereist vpn verbinding)
            conn = new OracleConnection();
            String pcn = "dbi300480";
            String pw = "HH9VTIT7qf";
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//192.168.15.50:1521/fhictora" + ";";
            
        }

        /// <summary>
        /// Er wordt geprobeerd verbinding te maken met de oracle database
        /// </summary>
        private void Open()
        {
            bool verbonden = false;
            while (!verbonden)
            {
                try
                {
                    conn.Open();
                    verbonden = true;
                }
                catch
                {
                    MessageBox.Show("Geen verbinding, er wordt opnieuw verbonden");
                }
            }
            
        }

        /// <summary>
        /// De verbinding wordt gesloten
        /// </summary>
        public void Close()
        {
           conn.Close();
        }

        /// <summary>
        /// wordt gebruikt om meerdere records uit de database te halen met bijv. een SELECT QUERY
        /// </summary>
        /// <param name="query">De query die uitgevoerd moet worden</param>
        /// <returns></returns>
        public DataTable getData(string query)
        {
            Open();
            OracleDataAdapter adap = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            Close();
            return dt;
        }

        /// <summary>
        /// wordt gebruikt voor data te inserten in de database (Bijvoorbeeld bij een nieuwe reservering)
        /// </summary>
        /// <param name="query">De query die uitgevoerd moet worden</param>
        public void InsertData(string query)
        {
            Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            Close();
        }

        /// <summary>
        /// wordt gebruikt om 1 resultaat terug te geven. het return type is object die kan omgezet worden naar een string of een int
        /// </summary>
        /// <param name="query">De query die uitgevoerd moet worden</param>
        /// <returns>Het resultaat van de query van het type object. Deze kan met Convert.To.Int & .ToString gebruikt worden</returns>
        public object SelectData(string query)
        {
            Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            object resultaat = cmd.ExecuteScalar();
            Close();
            return resultaat;
        }
    }
}
