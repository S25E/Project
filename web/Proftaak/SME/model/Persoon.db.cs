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
        /// <summary>
        /// Het ophalen van een bepaald persoon aan de hand van een nummer
        /// </summary>
        /// <param name="nummer"></param>
        /// <returns>De Persoon</returns>
        public static Persoon GetPersoonBijNummer(int nummer)
        {
            foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE PERSOON_NUMMER = " + nummer).Rows)
                return rowToPersoon(row);

            return null;
        }

        /// <summary>
        /// Het ophalen van personen aan de hand van een lijst met nummers
        /// </summary>
        /// <param name="nummers"></param>
        /// <returns>Een Dictonary met personen PERSOON_NUMMER => de Persoon</returns>
        public static Dictionary<int, Persoon> GetPersonenBijNummers(List<int> nummers)
        {
            Dictionary<int, Persoon> personen = new Dictionary<int, Persoon>();

            if(nummers.Count > 0)
                foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE PERSOON_NUMMER IN(" + string.Join(",", nummers) + ")").Rows)
                    personen.Add(Convert.ToInt32(row["PERSOON_NUMMER"]), this.rowToPersoon(row));

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

            foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE PERSOON_NUMMER IN (SELECT PERSOON_NUMMER FROM DISLIKE_LIKE_REPORT WHERE LIKEDISLIKE = 'LIKE' AND BESTAND_NUMMER = " + bestand.Nummer + ")").Rows)
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

            foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE PERSOON_NUMMER IN (SELECT PERSOON_NUMMER FROM DISLIKE_LIKE_REPORT WHERE LIKEDISLIKE = 'DISLIKE' AND BESTAND_NUMMER = " + bestand.Nummer + ")").Rows)
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

            foreach (DataRow row in Database.GetData("SELECT * FROM PERSOON WHERE PERSOON_NUMMER IN (SELECT PERSOON_NUMMER FROM DISLIKE_LIKE_REPORT WHERE REPORT = 'Y' AND BESTAND_NUMMER = " + bestand.Nummer + ")").Rows)
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
            string soort = row["SOORT"].ToString().ToUpper();

            // Waardes die voor alle types bestanden relevant zijn, definiëren 
            int nummer = Convert.ToInt32(row["PERSOON_NUMMER"]);
            string naam = row["NAAM"].ToString();
            string wachtwoord = row["WACHTWOORD"].ToString();

            switch (soort)
            {
                case "BIJBOEKER":
                    return new Bijboeker(
                        nummer,
                        naam,
                        wachtwoord
                    );
                case "HOOFDBOEKER":
                    return new Hoofdboeker(
                        nummer,
                        naam,
                        wachtwoord
                    );
                case "MEDEWERKER":
                    return new Medewerker(
                        nummer,
                        naam,
                        wachtwoord
                    );
                default:
                    throw new InvalidTypePersoonException();
            }
        }
    
    }
}
