using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SME
{
    public partial class Reservering
    {
        private static Reservering rowToReservering(DataRow row)
        {
            return new Reservering(Convert.ToInt32(row["RESERVERINGSNUMMER"]), Convert.ToDateTime(row["DATUM"]), row["BETAALD"].ToString() == "true");
        }

        public static List<Reservering> GetReserveringen()
        {
            List<Reservering> lijst = new List<Reservering>();

            DataTable dt = Database.GetData("SELECT RESERVERINGSNUMMER, BETAALD, DATUM FROM RESERVERING");
            
            foreach(DataRow row in dt.Rows)
            {
                lijst.Add(rowToReservering(row));
            }

            return lijst;
        }

        public static Reservering GetReserveringBijNummer(int nummer)
        {
            DataTable dt = Database.GetData("SELECT RESERVERINGSNUMMER, BETAALD, DATUM FROM RESERVERING");

            foreach (DataRow row in dt.Rows)
            {
                return rowToReservering(row);
            }

            return (Reservering)null;
        }

        public static void AddReservering(Reservering reservering)
        {
            int insertedId =  Database.GetSequence("SEQ_RESERVERING");
            reservering.Nummer = insertedId;

            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("p_reserveringnummer", OracleDbType.Int32).Value = reservering.Nummer;
            cmd.Parameters.Add("p_betaald", OracleDbType.Varchar2).Value = "false";
            cmd.Parameters.Add("p_datum", OracleDbType.Date).Value = reservering.Datum;
            Database.ExecuteProcedure(cmd, "ADD_RESERVERING");
        }

        // NOG TE MAKEN
        public static void ZetOpBetaald(Reservering reservering)
        {
            Database.Execute("UPDATE RESERVERING SET BETAALD 'Y' WHERE RESERVERING_NUMMER = " + reservering.Nummer);
        }

        // NOG TE MAKEN
        public static void DeleteReservering(Reservering reservering)
        {
            // HIER RESERVERING VERWIJDEREN IN DATABASE
            Database.Execute("DELETE FROM RESERVERING_PLAATS WHERE RESERVERINGSNUMMER = " + reservering.Nummer);
            Database.Execute("DELETE FROM RESERVERING WHERE RESERVERINGSNUMMER = " + reservering.Nummer);

            Persoon.DeletePersoon(reservering.Hoofdboeker);
            foreach (Bijboeker bijboeker in reservering.Bijboekers)
            {
                Persoon.DeletePersoon(bijboeker);
            }
        }
    }
}