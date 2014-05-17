using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
            return Database.GetData("SELECT * FROM BESTAND LEFT JOIN GELUIDSFRAGMENT ON BESTAND.BESTAND_NUMMER = GELUIDSFRAGMENT.BESTAND_NUMMER LEFT JOIN FILM ON BESTAND.BESTAND_NUMMER = FILM.BESTAND_NUMMER LEFT JOIN BOEK ON BESTAND.BESTAND_NUMMER = BOEK.BESTAND_NUMMER LEFT JOIN AFBEELDING ON BESTAND.BESTAND_NUMMER = AFBEELDING.BESTAND_NUMMER WHERE (SELECT COUNT(1) FROM DISLIKE_LIKE_REPORT WHERE DISLIKE_LIKE_REPORT.BESTAND_NUMMER = BESTAND.BESTAND_NUMMER AND REPORT = 'Y') <= 3" + (where != "" ? " AND " + where : ""));
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
                Bestand bestand = this.rowToBestand(row);
                int mapNummer = Convert.ToInt32(row["MAP_NUMMER"]);

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
                bestanden.Add(this.rowToBestand(row));

            return bestanden;
        }

        /// <summary>
        /// Bestanden geven bij map.
        /// </summary>
        /// <param name="map"></param>
        /// <returns>Lijst met bestanden</returns>
        public static List<Bestand> GetBestandenBijMap(Map map)
        {
            List<Bestand> bestanden = new List<Bestand>();

            foreach (DataRow row in getBestandenByWhere("MAP_NUMMER = " + map.Nummer).Rows)
                bestanden.Add(this.rowToBestand(row));

            return bestanden;
        }

        /// <summary>
        /// Het toevoegen van een like bij een bestand
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="persoon"></param>
        public static void AddLike(Bestand bestand, Persoon persoon)
        {
            DataTable dt = Database.GetData("SELECT * FROM DISLIKE_LIKE_REPORT WHERE PERSOON_NUMMER = " + persoon.Nummer + " AND BESTAND_NUMMER = " + bestand.Nummer);
            if (dt.Rows.Count == 0)
                Database.Execute("INSERT INTO DISLIKE_LIKE_REPORT (PERSOON_NUMMER, BESTAND_NUMMER, LIKEDISLIKE, REPORT) VALUES (" + persoon.Nummer + ", " + bestand.Nummer + ", 'LIKE', 'N')");
            else
                Database.Execute("UPDATE DISLIKE_LIKE_REPORT SET LIKEDISLIKE = 'LIKE' WHERE PERSOON_NUMMER = " + persoon.Nummer + " AND BESTAND_NUMMER = " + bestand.Nummer);
        }

        /// <summary>
        /// Het toevoegen van een dislike bij een bestand.
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="persoon"></param>
        public static void AddDislike(Bestand bestand, Persoon persoon)
        {
            DataTable dt = Database.GetData("SELECT * FROM DISLIKE_LIKE_REPORT WHERE PERSOON_NUMMER = " + persoon.Nummer + " AND BESTAND_NUMMER = " + bestand.Nummer);
            if (dt.Rows.Count == 0)
                Database.Execute("INSERT INTO DISLIKE_LIKE_REPORT (PERSOON_NUMMER, BESTAND_NUMMER, LIKEDISLIKE, REPORT) VALUES (" + persoon.Nummer + ", " + bestand.Nummer + ", 'DISLIKE', 'N')");
            else
                Database.Execute("UPDATE DISLIKE_LIKE_REPORT SET LIKEDISLIKE = 'DISLIKE' WHERE PERSOON_NUMMER = " + persoon.Nummer + " AND BESTAND_NUMMER = " + bestand.Nummer);
        }

        /// <summary>
        /// Het toevoegne van een report bij een bestand.
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="persoon"></param>
        public static void AddReport(Bestand bestand, Persoon persoon)
        {
            DataTable dt = Database.GetData("SELECT * FROM DISLIKE_LIKE_REPORT WHERE PERSOON_NUMMER = " + persoon.Nummer + " AND BESTAND_NUMMER = " + bestand.Nummer);
            if (dt.Rows.Count == 0)
                Database.Execute("INSERT INTO DISLIKE_LIKE_REPORT (PERSOON_NUMMER, BESTAND_NUMMER, LIKEDISLIKE, REPORT) VALUES (" + persoon.Nummer + ", " + bestand.Nummer + ", NULL, 'Y')");
            else
                Database.Execute("UPDATE DISLIKE_LIKE_REPORT SET REPORT = 'Y' WHERE PERSOON_NUMMER = " + persoon.Nummer + " AND BESTAND_NUMMER = " + bestand.Nummer);
        }

        /// <summary>
        /// Het toevoegen van een bestand
        /// </summary>
        /// <param name="bestand"></param>
        /// <returns>Het nummer van het toegevoegde bestand</returns>
        public static int AddBestand(Bestand bestand)
        {
            string type = null;
            if (bestand is Geluidsfragment)
                type = "GELUIDSFRAGMENT";
            else if (bestand is Film)
                type = "FILM";
            else if (bestand is Boek)
                type = "BOEK";
            else if (bestand is Afbeelding)
                type = "AFBEELDING";

            int insertedId = Convert.ToInt32(Database.GetData("SELECT bestand1.nextval FROM dual").Rows[0]["NEXTVAL"]);
            Database.Execute("INSERT INTO BESTAND (BESTAND_NUMMER, DATUM, NAAM, MAP_NUMMER, PERSOON_NUMMER, GROOTTE, OPMERKING, BESTANDSLOCATIE, TYPE) VALUES (" + insertedId + ", TO_DATE('" + bestand.UploadDatum.ToString("yyyy-MM-dd HH:mm:ss") + "', 'SYYYY-MM-DD HH24:MI:SS'), '" + this.Escape(bestand.Bestandsnaam) + "', " + bestand.MapNummer + ", " + bestand.GeuploadDoor.Nummer + ", " + bestand.Grootte + ", '" + this.Escape(bestand.Opmerking) + "', '" + this.Escape(bestand.Bestandslocatie) + "', '" + type + "')");

            switch (type)
            {
                case "GELUIDSFRAGMENT":
                    Geluidsfragment geluidsfragment = bestand as Geluidsfragment;
                    Database.Execute("INSERT INTO GELUIDSFRAGMENT (BESTAND_NUMMER, ARTIEST, SPEELDUUR) VALUES (" + insertedId + ", '" + this.Escape(geluidsfragment.Artiest) + "', " + geluidsfragment.Speelduur + ")");
                    break;
                case "FILM":
                    Film film = bestand as Film;
                    Database.Execute("INSERT INTO FILM (BESTAND_NUMMER, FILMDUUR, MAKER) VALUES (" + insertedId + ", " + film.Duur + ", '" + this.Escape(film.Maker) + "')");
                    break;
                case "BOEK":
                    Boek boek = bestand as Boek;
                    Database.Execute("INSERT INTO BOEK (BESTAND_NUMMER, AANTAL_PAGINAS, SCHRIJVER, TAAL, GENRE) VALUES (" + insertedId + ", " + boek.AantalPaginas + ", '" + this.Escape(boek.Schrijver) + "', '" + this.Escape(boek.Taal) + "', '" + this.Escape(boek.Genre) + "')");
                    break;
                case "AFBEELDING":
                    Afbeelding afbeelding = bestand as Afbeelding;
                    Database.Execute("INSERT INTO AFBEELDING (BESTAND_NUMMER, AFMETING) VALUES (" + insertedId + ", '" + this.Escape(afbeelding.Afmeting) + "')");
                    break;
            }
            return insertedId;
        }

        /// <summary>
        /// Het verwijderen van een bestand
        /// </summary>
        /// <param name="bestand"></param>
        public static void DeleteBestand(Bestand bestand)
        {
            Database.Execute("DELETE FROM FILM WHERE BESTAND_NUMMER = " + bestand.Nummer);
            Database.Execute("DELETE FROM GELUIDSFRAGMENT WHERE BESTAND_NUMMER = " + bestand.Nummer);
            Database.Execute("DELETE FROM BOEK WHERE BESTAND_NUMMER = " + bestand.Nummer);
            Database.Execute("DELETE FROM AFBEELDING WHERE BESTAND_NUMMER = " + bestand.Nummer);
            Database.Execute("DELETE FROM REACTIE WHERE BESTAND_NUMMER = " + bestand.Nummer);
            Database.Execute("DELETE FROM DISLIKE_LIKE_REPORT WHERE BESTAND_NUMMER = " + bestand.Nummer);
            Database.Execute("DELETE FROM BESTAND WHERE BESTAND_NUMMER = " + bestand.Nummer);
        }

        /// <summary>
        /// Het converteren van een DataRow naar een Bestand
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Het bestand</returns>
        private Bestand rowToBestand(DataRow row)
        {
            string type = row["TYPE"].ToString().ToUpper();

            // Waardes die voor alle types bestanden relevant zijn, definiëren 
            int nummer = Convert.ToInt32(row["BESTAND_NUMMER"]);
            string bestandnaam = row["NAAM"].ToString();
            string bestandslocatie = row["BESTANDSLOCATIE"].ToString();
            int grootte = Convert.ToInt32(row["GROOTTE"]);
            string opmerking = row["OPMERKING"].ToString();
            DateTime uploaddatum = Convert.ToDateTime(row["DATUM"]);
            int geuploaddoor = Convert.ToInt32(row["PERSOON_NUMMER"]);
            int mapnummer = Convert.ToInt32(row["MAP_NUMMER"]);

            switch (type)
            {
                case "GELUIDSFRAGMENT":
                    return new Geluidsfragment(
                        nummer,
                        bestandnaam,
                        bestandslocatie,
                        grootte,
                        opmerking,
                        uploaddatum,
                        geuploaddoor,
                        mapnummer,
                        row["ARTIEST"].ToString(),
                        Convert.ToInt32(row["SPEELDUUR"])
                    );
                case "FILM": 
                    return new Film(
                        nummer,
                        bestandnaam,
                        bestandslocatie,
                        grootte,
                        opmerking,
                        uploaddatum,
                        geuploaddoor,
                        mapnummer,
                        row["MAKER"].ToString(),
                        Convert.ToInt32(row["FILMDUUR"])
                    );
                case "BOEK": 
                    return new Boek(
                        nummer,
                        bestandnaam,
                        bestandslocatie,
                        grootte,
                        opmerking,
                        uploaddatum,
                        geuploaddoor,
                        mapnummer,
                        Convert.ToInt32(row["AANTAL_PAGINAS"]),
                        row["SCHRIJVER"].ToString(),
                        row["TAAL"].ToString(),
                        row["GENRE"].ToString()
                    );
                case "AFBEELDING": 
                    return new Afbeelding(
                        nummer,
                        bestandnaam,
                        bestandslocatie,
                        grootte,
                        opmerking,
                        uploaddatum,
                        geuploaddoor,
                        mapnummer,
                        row["AFMETING"].ToString()
                    );
                default: 
                    return new Bestand(
                        nummer,
                        bestandnaam,
                        bestandslocatie,
                        grootte,
                        opmerking,
                        uploaddatum,
                        geuploaddoor,
                        mapnummer
                    );
            }
        }
    }
}
