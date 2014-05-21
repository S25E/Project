using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SME
{
    class InvalidTypePersoonException : Exception
    {

    }

    public partial class Persoon
    {
        private static DataTable getPersonenByWhere(string where = "")
        {
            return Database.GetData("SELECT PERSOON.*, KLANT.*, KLANT_BETALEND.*, KLANT.RESERVERINGSNUMMER AS k_RESERVERINGSNUMMER, KLANT_BETALEND.RESERVERINGSNUMMER AS kb_RESERVERINGSNUMMER, KLANT_BETALEND.REKENINGNUMMER AS kb_REKENINGNUMMER, MEDEWERKER.REKENINGNUMMER AS m_REKENINGNUMMER FROM PERSOON LEFT JOIN KLANT ON PERSOON.RFID = KLANT.RFID LEFT JOIN KLANT_BETALEND ON PERSOON.RFID = KLANT_BETALEND.RFID LEFT JOIN MEDEWERKER ON PERSOON.RFID = MEDEWERKER.RFID" + (where != "" ? " WHERE " + where : ""));
        }

        /// <summary>
        /// Het ophalen van een bepaald persoon aan de hand van een nummer
        /// </summary>
        /// <param name="nummer"></param>
        /// <returns>De Persoon</returns>
        public static Persoon GetPersoonBijRFID(int rfid)
        {
            foreach (DataRow row in getPersonenByWhere("RFID = " + rfid).Rows)
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
        public static Dictionary<int, Persoon> GetPersonenBijRFIDs(List<int> rfids)
        {
            Dictionary<int, Persoon> personen = new Dictionary<int, Persoon>();

            if (rfids.Count > 0)
                foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE RFID IN(" + string.Join(",", rfids) + ")").Rows)
                    personen.Add(Convert.ToInt32(row["RFID"]), rowToPersoon(row));

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
                likes.Add(rowToPersoon(row));

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
        /// </summary>
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
            int rfid = Convert.ToInt32(row["RFID"]);
            string wachtwoord = row["WACHTWOORD"].ToString();
            bool aanwezig = row["AANWEZIG"].ToString() == "Y";
            string naam = row["NAAM"].ToString();

            switch (type)
            {
                case "Klant":
                    return new Bijboeker(
                        rfid,
                        naam,
                        wachtwoord,
                        aanwezig,
                        Convert.ToInt32(row["k_RESERVERINGSNUMMER"])
                    );
                case "Klant_betalend":
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
                case "Medewerker":
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
            Database.Execute("UPDATE PERSOON SET aanwezig= " + (persoon.Aanwezig ? "Y" : "N") + " WHERE RFID = " + persoon.Nummer);
        }

        // NOG TE MAKEN
        public static void AddPersoon(Persoon persoon)
        {


        }

        // NOG TE MAKEN
        public static void DeletePersoon(Persoon persoon)
        {
            // DENK AAN ALLE TABELLEN WAARIN RFID GEBRUIKT WORDT.            
        }

        // NOG TE MAKEN
        public static Hoofdboeker GetHoofdboekerBijReservering(Reservering reservering)
        {
            return (Hoofdboeker)null;
        }

        public static List<Bijboeker> GetBijboekersBijReservering(Reservering reservering)
        {
            return (List<Bijboeker>)null;
        }
    }
}
