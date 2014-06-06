using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

// NOTE: getBestandenByWhere en rowToBestand kunnen samen worden gevoegd?

namespace SME
{
    public partial class Bestand 
    {
        /// <summary>
        /// Het ophalen van bestanden gebeurt in de meeste gevallen op dezelfde manier. Alleen het laatste gedeelte van de WHERE-clause verschilt. Om dit te vermakkelijken: deze methode.
        /// </summary>
        /// <param name="where"></param>
        /// <returns>DataTable met bestanden</returns>
        private static DataTable getBestandenByWhere(string where = ""){
            return Database.GetData("SELECT * FROM BESTAND WHERE (SELECT COUNT(1) FROM DISLIKE_LIKE_REPORT WHERE DISLIKE_LIKE_REPORT.BESTAND_ID = BESTAND.BESTAND_ID AND REPORT = 'Y') <= 3" + (where != "" ? " AND " + where : ""));
        }

        /// <summary>
        /// Geeft bestanden terug gesorteerd bij map.
        /// </summary>
        /// <returns>Dictionary MAP_NUMMER => lijst met BESTANDEN</returns>
        public static Dictionary<int, List<Bestand>> GetBestandenBijMap()
        {
            Dictionary<int, List<Bestand>> bestanden = new Dictionary<int, List<Bestand>>();

            foreach (DataRow row in getBestandenByWhere().Rows)
            {
                Bestand bestand = rowToBestand(row);
                int mapNummer = Convert.ToInt32(row["MAP_ID"]);

                if (bestanden.ContainsKey(mapNummer))
                    bestanden[mapNummer].Add(bestand);
                else
                {
                    List<Bestand> nieuweLijst = new List<Bestand>();
                    nieuweLijst.Add(bestand);
                    bestanden.Add(mapNummer, nieuweLijst);
                }
            }

            return bestanden;
        }

        /// <summary>
        /// Geeft alle bestanden.
        /// </summary>
        /// <returns>Lijst met bestanden</returns>
        public static List<Bestand> GetBestanden()
        {
            List<Bestand> bestanden = new List<Bestand>();

            foreach (DataRow row in getBestandenByWhere().Rows)
                bestanden.Add(rowToBestand(row));

            return bestanden;
        }

        public static Bestand GetBestand(int id)
        {
            foreach (DataRow row in getBestandenByWhere("BESTAND_ID = " + id).Rows)
            {
                return rowToBestand(row);
            }

            return null;
        }

        /// <summary>
        /// Bestanden geven bij map.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Lijst met bestanden</returns>
        public static List<Bestand> GetBestandenBijMap(Map map)
        {
            List<Bestand> bestanden = new List<Bestand>();

            foreach (DataRow row in getBestandenByWhere("MAP_ID = " + map.Nummer).Rows)
            {
                bestanden.Add(rowToBestand(row));
            }

            return bestanden;
        }

        /// <summary>
        /// Het toevoegen van een like bij een bestand
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="persoon"></param>
        public static void AddLike(Bestand bestand, Persoon persoon)
        {
            DataTable dt = Database.GetData("SELECT * FROM DISLIKE_LIKE_REPORT WHERE RFID = " + persoon.Nummer + " AND BESTAND_ID = " + bestand.Nummer);
            if (dt.Rows.Count == 0)
            {
                Database.Execute("INSERT INTO DISLIKE_LIKE_REPORT (RFID, BESTAND_ID, LIKEDISLIKE, REPORT) VALUES (@rfid, " + bestand.Nummer + ", 'Y', 'N')", new Dictionary<string, object>()
                {
                    {"@rfid", persoon.Nummer}
                });
            }
            else
            {
                Database.Execute("UPDATE DISLIKE_LIKE_REPORT SET LIKEDISLIKE = 'Y' WHERE RFID = @rfid AND BESTAND_ID = " + bestand.Nummer, new Dictionary<string, object>()
                {
                    {"@rfid", persoon.Nummer}
                });
            }
            bestand.Rating += 1;
            Database.Execute("UPDATE BESTAND SET RATING = RATING + 1 WHERE BESTAND_ID = " + bestand.Nummer);
        }

        /// <summary>
        /// Het toevoegen van een dislike bij een bestand.
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="persoon"></param>
        public static void AddDislike(Bestand bestand, Persoon persoon)
        {
            DataTable dt = Database.GetData("SELECT * FROM DISLIKE_LIKE_REPORT WHERE RFID = " + persoon.Nummer + " AND BESTAND_ID = " + bestand.Nummer);
            if (dt.Rows.Count == 0)
            {
                Database.Execute("INSERT INTO DISLIKE_LIKE_REPORT (RFID, BESTAND_ID, LIKEDISLIKE, REPORT) VALUES (@rfid, " + bestand.Nummer + ", 'N', 'N')", new Dictionary<string, object>()
                {
                    {"@rfid", persoon.Nummer}
                });
            }
            else
            {
                Database.Execute("UPDATE DISLIKE_LIKE_REPORT SET LIKEDISLIKE = 'N' WHERE RFID = @rfid AND BESTAND_ID = " + bestand.Nummer, new Dictionary<string, object>()
                    {
                        {"@rfid", persoon.Nummer}
                    });
            }
            bestand.Rating -= 1;
            Database.Execute("UPDATE BESTAND SET RATING = RATING - 1 WHERE BESTAND_ID = " + bestand.Nummer);
        }

        /// <summary>
        /// Het toevoegne van een report bij een bestand.
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="persoon"></param>
        public static void AddReport(Bestand bestand, Persoon persoon)
        {
            DataTable dt = Database.GetData("SELECT * FROM DISLIKE_LIKE_REPORT WHERE RFID = " + persoon.Nummer + " AND BESTAND_ID = " + bestand.Nummer);
            if (dt.Rows.Count == 0)
            {
                Database.Execute("INSERT INTO DISLIKE_LIKE_REPORT (RFID, BESTAND_ID, LIKEDISLIKE, REPORT) VALUES (@rfid, " + bestand.Nummer + ", NULL, 'Y')", new Dictionary<string, object>()
                {
                    {"@rfid", persoon.Nummer}
                });
            }
            else
            {
                Database.Execute("UPDATE DISLIKE_LIKE_REPORT SET REPORT = 'Y' WHERE RFID = @rfid AND BESTAND_ID = " + bestand.Nummer, new Dictionary<string, object>()
                {
                    {"@rfid", persoon.Nummer}
                });
            }
        }

        /// <summary>
        /// Het toevoegen van een bestand
        /// </summary>
        /// <param name="bestand"></param>
        /// <returns>Het nummer van het toegevoegde bestand</returns>
        public static void AddBestand(Bestand bestand)
        {
            int insertedId = Database.GetSequence("SEQ_BESTAND");
            Database.Execute("INSERT INTO BESTAND (BESTAND_ID, MAP_ID, NAAM, BESCHRIJVING, EXTENSIE, GROOTTE, RFID, DATUM, PAD, IMGINDEX) VALUES (@nummer, @map_nummer, @naam, @beschrijving, @extensie, @grootte, @rfid, TO_DATE(@datum, 'SYYYY-MM-DD HH24:MI:SS'), @pad, @imgindex)", new Dictionary<string, object>()
            {
                {"@nummer", insertedId},
                {"@map_nummer", bestand.MapNummer},
                {"@naam", bestand.Naam},
                {"@beschrijving", bestand.Beschrijving},
                {"@extensie", bestand.Extensie},
                {"@grootte", bestand.Grootte},
                {"@rfid", bestand.Uploader.Nummer},
                {"@datum", bestand.Datum.ToString("yyyy-MM-dd HH:mm:ss")},
                {"@pad", bestand.Pad},
                {"@imgindex", bestand.Image}
            });
            bestand.Nummer = insertedId;
        }
          
        /// <summary>
        /// Het verwijderen van een bestand
        /// </summary>
        /// <param name="bestand"></param>
        public static void DeleteBestand(Bestand bestand)
        {
            Database.Execute("DELETE FROM REACTIE WHERE BESTAND_ID = " + bestand.Nummer);
            Database.Execute("DELETE FROM DISLIKE_LIKE_REPORT WHERE BESTAND_ID = " + bestand.Nummer);
            Database.Execute("DELETE FROM BESTAND WHERE BESTAND_ID = " + bestand.Nummer);
        }

        /// <summary>
        /// Het converteren van een DataRow naar een Bestand
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Het bestand</returns>
        private static Bestand rowToBestand(DataRow row)
        {
            return new Bestand(
                Convert.ToInt32(row["BESTAND_ID"]),
                Convert.ToInt32(row["MAP_ID"]),
                row["BESCHRIJVING"].ToString(),
                row["NAAM"].ToString(),
                row["EXTENSIE"].ToString(),
                Convert.ToInt32(row["GROOTTE"]),
                row["RFID"].ToString(),
                Convert.ToDateTime(row["DATUM"]),
                Convert.ToInt32(row["GEDOWNLOAD"]),
                Convert.ToInt32(row["RATING"]),
                row["PAD"].ToString(),
                Convert.ToInt32(row["IMGINDEX"])
            );
        }

        public static void Download(Bestand bestand)
        {
            Database.Execute("UPDATE BESTAND SET GEDOWNLOAD = GEDOWNLOAD + 1 WHERE BESTAND_ID = " + bestand.Nummer);
            bestand.Gedownload += 1;
        }
    }
}
