using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Types;

namespace SME
{
    public partial class Reactie
    {
        /// <summary>
        /// Het ophalen van de reacties die bij een bepaald bestand horen
        /// </summary>
        /// <param name="bestand"></param>
        /// <returns>Een lijst met reacties</returns>
        public static List<Reactie> GetReactiesBijBestand(Bestand bestand)
        {
            List<Reactie> reacties = new List<Reactie>();

            foreach (DataRow row in Database.GetData("SELECT * FROM OPMERKING WHERE (SELECT COUNT(1) FROM OPMERKINGREPORT WHERE OPMERKINGREPORT.OPMERKING_ID = REACTIE.OPMERKING_ID) <= 3 AND BESTAND_ID = " + bestand.Nummer + " ORDER by OPMERKING_ID").Rows)
                reacties.Add(
                    new Reactie(
                        Convert.ToInt32(row["OPMERKING_ID"]),
                        Convert.ToInt32(row["RFID"]),
                        Convert.ToDateTime(row["DATUM"]),
                        row["OPMERKING_TEXT"].ToString()
                    )
                );

            return reacties;
        }

        /// <summary>
        /// Een report toevoegen aan een reactie.
        /// </summary>
        /// <param name="reactie"></param>
        /// <param name="persoon"></param>
        public static void AddReport(Reactie reactie, Persoon persoon)
        {
            if (Database.GetData("SELECT * FROM OPMERKINGREPORT WHERE OPMERKING_ID = " + reactie.Nummer + " AND RFID = " + persoon.Nummer).Rows.Count == 0)
                Database.Execute("INSERT INTO OPMERKINGREPORT (OPMERKING_ID, RFID) VALUES (" + reactie.Nummer + ", " + persoon.Nummer + ")");
        }

        /// <summary>
        /// Het toevoegen van een reactie.
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="reactie"></param>
        public static int AddReactie(Bestand bestand, Reactie reactie)
        {
            int insertedId = Convert.ToInt32(Database.GetData("SELECT SEQ_OPMERKINGREPORT.nextval FROM dual").Rows[0]["NEXTVAL"]);
            Database.Execute("INSERT INTO OPMERKING (OPMERKING_ID, RFID, BESTAND_ID, DATUM, OPMERKING_TEXT) VALUES (@nummer, @rfid, @bestand_nummer, TO_DATE(@datum, 'SYYYY-MM-DD HH24:MI:SS'), @opmerking)", new Dictionary<string, object>
            {
                {"@nummer", insertedId},
                {"@rfid", reactie.PersoonNummer},
                {"@bestand_nummer", bestand.Nummer},
                {"@datum", reactie.Datum.ToString("yyyy-MM-dd HH:mm:ss")},
                {"@opmerking", reactie.Opmerking},
            });
            return insertedId;
        }
    }
}
