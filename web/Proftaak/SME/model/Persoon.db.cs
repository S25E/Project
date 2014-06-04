using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace SME
{
    class InvalidTypePersoonException : Exception
    {

    }

    public partial class Persoon
    {
        private static DataTable getPersonenByWhere(string where = "", Dictionary<string, object> parameters = default(Dictionary<string, object>))
        {
            return Database.GetData("SELECT PERSOON.*, KLANT.*, KLANT_BETALEND.*, KLANT.RESERVERINGSNUMMER AS k_RESERVERINGSNUMMER, KLANT_BETALEND.RESERVERINGSNUMMER AS kb_RESERVERINGSNUMMER, KLANT_BETALEND.REKENINGNUMMER AS kb_REKENINGNUMMER, MEDEWERKER.REKENINGNUMMER AS m_REKENINGNUMMER, MEDEWERKER.FUNCTIE FROM PERSOON LEFT JOIN KLANT ON PERSOON.RFID = KLANT.RFID LEFT JOIN KLANT_BETALEND ON PERSOON.RFID = KLANT_BETALEND.RFID LEFT JOIN MEDEWERKER ON PERSOON.RFID = MEDEWERKER.RFID" + (where != "" ? " WHERE " + where : ""), parameters);
        }

        /// <summary>
        /// Het ophalen van een bepaald persoon aan de hand van een nummer
        /// </summary>
        /// <param name="nummer"></param>
        /// <returns>De Persoon</returns>
        public static Persoon GetPersoonBijRFID(string rfid)
        {
            foreach (DataRow row in getPersonenByWhere("PERSOON.RFID = @rfid", new Dictionary<string, object>() { { "@rfid", rfid } }).Rows)
            {
                return rowToPersoon(row);
            }

            return null;
        }

        /// <summary>
        /// Het ophalen van personen aan de hand van een lijst met nummers
        /// </summary>
        /// <param name="nummers"></param>
        /// <returns>Een Dictonary met personen PERSOON_NUMMER => de Persoon</returns>
        public static Dictionary<string, Persoon> GetPersonenBijRFIDs(List<string> rfids)
        {
            Dictionary<string, Persoon> personen = new Dictionary<string, Persoon>();

            if (rfids.Count > 0)
            {
                foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE RFID IN(@rfids)", new Dictionary<string, object>() { { "@rfids", rfids } }).Rows)
                {
                    personen.Add(row["RFID"].ToString(), rowToPersoon(row));
                }
            }

            return personen;
        }

        /// <summary>
        /// Het ophalen van de lijst met personen die een bepaald bestand hebben geliked.
        /// </summary>
        /// <param name="bestand"></param>
        /// <returns>Een lijst met personen.</returns>
        public static List<Persoon> GetLikes(Bestand bestand)
        {
            List<Persoon> likes = new List<Persoon>();

            foreach (DataRow row in getPersonenByWhere("RFID IN (SELECT RFID FROM DISLIKE_LIKE_REPORT WHERE LIKEDISLIKE = 'LIKE' AND BESTAND_ID = " + bestand.Nummer + ")").Rows)
            {
                likes.Add(rowToPersoon(row));
            }

            return likes;
        }

        /// <summary>
        /// Het ophalen van de lijst met personen die een bestand gedisliked hebben.
        /// </summary>
        /// <param name="bestand"></param>
        /// <returns>Een lijst met personen</returns>
        public static List<Persoon> GetDislikes(Bestand bestand)
        {
            List<Persoon> likes = new List<Persoon>();

            foreach (DataRow row in getPersonenByWhere("RFID IN (SELECT RIFD FROM DISLIKE_LIKE_REPORT WHERE LIKEDISLIKE = 'DISLIKE' AND BESTAND_ID = " + bestand.Nummer + ")").Rows)
                likes.Add(rowToPersoon(row));

            return likes;
        }

        /// <summary>
        /// Het ophalen van een lijst met personen die een bestand hebben gereported.
        /// </summary>h
        /// <param name="bestand"></param>
        /// <returns>Een lijst met personen</returns>
        public static List<Persoon> GetReports(Bestand bestand)
        {
            List<Persoon> likes = new List<Persoon>();

            foreach (DataRow row in getPersonenByWhere("RFID IN (SELECT RIFD FROM DISLIKE_LIKE_REPORT WHERE REPORT = 'Y' AND BESTAND_ID = " + bestand.Nummer + ")").Rows)
                likes.Add(rowToPersoon(row));

            return likes;
        }

        /// <summary>
        /// Het converteren van een DataRow naar een Persoon
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Een Persoon</returns>
        private static Persoon rowToPersoon(DataRow row)
        {
            string type = row["TYPE"].ToString().ToUpper();

            // Waardes die voor alle types bestanden relevant zijn, definiëren 
            string rfid = row["RFID"].ToString();
            string wachtwoord = row["WACHTWOORD"].ToString();
            bool aanwezig = row["AANWEZIG"].ToString() == "Y";
            string naam = row["NAAM"].ToString();

            switch (type)
            {
                case "KLANT":
                    return new Bijboeker(
                        rfid,
                        naam,
                        wachtwoord,
                        aanwezig,
                        Convert.ToInt32(row["k_RESERVERINGSNUMMER"])
                    );
                case "KLANT_BETALEND":
                    return new Hoofdboeker(
                        rfid,
                        naam,
                        wachtwoord,
                        aanwezig,
                        Convert.ToInt32(row["kb_RESERVERINGSNUMMER"]),
                        row["STRAAT"].ToString(),
                        row["POSTCODE"].ToString(),
                        row["WOONPLAATS"].ToString(),
                        row["TELEFOON"].ToString(),
                        row["EMAIL"].ToString(),
                        row["kb_REKENINGNUMMER"].ToString(),
                        row["SOFINUMMER"].ToString()
                    );
                case "MEDEWERKER":
                    return new Medewerker(
                        rfid,
                        naam,
                        wachtwoord,
                        aanwezig,
                        row["FUNCTIE"].ToString(),
                        row["REKENINGNUMMER"].ToString()
                    );
                default:
                    throw new InvalidTypePersoonException();
            }
        }
        public static void UpdateAanwezigheid(Persoon persoon)
        {
            Database.Execute("UPDATE PERSOON SET aanwezig= '" + (persoon.Aanwezig ? "Y" : "N") + "' WHERE RFID = @rfid", new Dictionary<string,object>(){{"@rfid", persoon.Nummer}});
        }

        public static void AddPersoon(Persoon persoon)
        {
            string type;
            if (persoon is Hoofdboeker)
            {
                type = "Klant_betalend";
            }
            else if (persoon is Bijboeker)
            {
                type = "Klant";
            }
            else if(persoon is Medewerker)
            {
                type = "Medewerker";
            }
            else
            {
                throw new Exception("Ongeldig type!");
            }

            string procedureNaam = "ADD_" + type.ToUpper();
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add("p_naam", OracleDbType.Varchar2).Value = persoon.Naam;
            cmd.Parameters.Add("p_wachtwoord", OracleDbType.Varchar2).Value = persoon.wachtwoord;
            cmd.Parameters.Add("p_aanwezig", OracleDbType.Varchar2).Value = "N";

            if(persoon is Hoofdboeker)
            {
                Hoofdboeker hoofdboeker = (Hoofdboeker)persoon;
                cmd.Parameters.Add("p_straat", OracleDbType.Varchar2).Value = hoofdboeker.Straat;
                cmd.Parameters.Add("p_postcode", OracleDbType.Varchar2).Value = hoofdboeker.Postcode;
                cmd.Parameters.Add("p_woonplaats", OracleDbType.Varchar2).Value = hoofdboeker.Woonplaats;
                cmd.Parameters.Add("p_telefoon", OracleDbType.Varchar2).Value = hoofdboeker.Telefoon;
                cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = hoofdboeker.Email;
                cmd.Parameters.Add("p_rekeningnummer", OracleDbType.Varchar2).Value = hoofdboeker.Rekeningnummer;
                cmd.Parameters.Add("p_sofinummer", OracleDbType.Varchar2).Value = hoofdboeker.Sofinummer;
                cmd.Parameters.Add("p_reserveringnummer", OracleDbType.Int32).Value = hoofdboeker.ReserveringNummer; //Deze functie werkt niet, als deze niet klopt. gebruik vaste waarde van 60!
                Database.ExecuteProcedure(cmd, procedureNaam);
            }
            else if(persoon is Bijboeker)
            {
                Bijboeker bijboeker = (Bijboeker)persoon;
                cmd.Parameters.Add("p_reserveringsnummer", OracleDbType.Varchar2).Value = bijboeker.ReserveringNummer;
                Database.ExecuteProcedure(cmd, procedureNaam);
            }
            else if(persoon is Medewerker)
            {
                Medewerker medewerker = (Medewerker)persoon;
                cmd.Parameters.Add("p_functie", OracleDbType.Varchar2).Value = medewerker.Functie;
                cmd.Parameters.Add("p_rekeningnummer", OracleDbType.Varchar2).Value = medewerker.Rekeningnummer;
            }
        }

        // NOG TE MAKEN
        public static void DeletePersoon(Persoon persoon)
        {
            // EERST ALLE VERWIJZINGEN NAAR PERSOON VERWIJDEREN.

            // TE BEGINNEN MET DE SUBTYPERING VAN PERSOON.
            if(persoon is Hoofdboeker)
            {
                Database.Execute("DELETE FROM KLANT_BETALEND WHERE RFID = @rfid", new Dictionary<string, object>(){{"@rfid", persoon.Nummer}});
            }
            else if(persoon is Bijboeker)
            {
                Database.Execute("DELETE FROM KLANT WHERE RFID = @rfid", new Dictionary<string, object>(){{"@rfid", persoon.Nummer}});
            }
            else 
            {
                Database.Execute("DELETE FROM MEDEWERKER WHERE RFID = @rfid", new Dictionary<string, object>(){{"@rfid", persoon.Nummer}});
            }

            // DENK AAN ALLE TABELLEN WAARIN RFID GEBRUIKT WORDT.
            //DISLIKE_LIKE_REPORT
            Database.Execute("DELETE FROM DISLIKE_LIKE_REPORT WHERE RFID = @rfid", new Dictionary<string, object>() {{"@rfid", persoon.Nummer}});

            //OPMERKING
            Database.Execute("DELETE FROM OPMERKING WHERE RFID = @rfid", new Dictionary<string, object>() {{"@rfid", persoon.Nummer}});

            //OPMERKINGREPORT
            Database.Execute("DELETE FROM OPMERKINGREPORT WHERE RFID = @rfid", new Dictionary<string, object>() {{"@rfid", persoon.Nummer}});

            // UITEINDELIJK DE PERSOON ZELF VERWIJDEREN
            Database.Execute("DELETE FROM PERSOON WHERE RFID = @rfid", new Dictionary<string, object>() { { "@rfid", persoon.Nummer } });
        }

        public static Hoofdboeker GetHoofdboekerBijReservering(Reservering reservering)
        {
            DataTable dt = getPersonenByWhere("KLANT_BETALEND.RESERVERINGSNUMMER = " + reservering.Nummer);

            foreach(DataRow row in dt.Rows)
            {
                return (Hoofdboeker)rowToPersoon(row);

            }

            return null;
        }

        public static List<Bijboeker> GetBijboekersBijReservering(Reservering reservering)
        {
            List<Bijboeker> Bijboekers = new List<Bijboeker>();
            DataTable dt = getPersonenByWhere("KLANT.RESERVERINGSNUMMER =" + reservering.Nummer);

            foreach(DataRow row in dt.Rows)
            {
                Bijboekers.Add((Bijboeker)rowToPersoon(row));                
            }

            return Bijboekers;
        }

        public static DataTable GetAanwezigePersonen()
        {
            return Database.GetData("SELECT RFID FROM PERSOON WHERE AANWEZIG = 'Y' ORDER BY RFID");
        }
    }
}
