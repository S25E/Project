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

            foreach (DataRow row in Database.GetData("SELECT * FROM REACTIE WHERE (SELECT COUNT(1) FROM REACTIEREPORT WHERE REACTIEREPORT.REACTIE_NUMMER = REACTIE.REACTIE_NUMMER) <= 3 AND BESTAND_NUMMER = " + bestand.Nummer + " ORDER by REACTIE_NUMMER").Rows)
                reacties.Add(
                    new Reactie(
                        Convert.ToInt32(row["REACTIE_NUMMER"]),
                        Convert.ToInt32(row["PERSOON_NUMMER"]),
                        row["OPMERKING"].ToString(),
                        Convert.ToDateTime(row["DATUMTIJD"])
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
            if(Database.GetData("SELECT * FROM REACTIEREPORT WHERE REACTIE_NUMMER = " + reactie.Nummer + " AND PERSOON_NUMMER = " + persoon.Nummer).Rows.Count == 0)
                Database.Execute("INSERT INTO REACTIEREPORT (REACTIE_NUMMER, PERSOON_NUMMER) VALUES (" + reactie.Nummer + ", " + persoon.Nummer + ")");
        }

        /// <summary>
        /// Het toevoegen van een reactie.
        /// </summary>
        /// <param name="bestand"></param>
        /// <param name="reactie"></param>
        public static int AddReactie(Bestand bestand, Reactie reactie)
        {
            int insertedId = Convert.ToInt32(Database.GetData("SELECT reactie1.nextval FROM dual").Rows[0]["NEXTVAL"]);
            Database.Execute("INSERT INTO REACTIE (REACTIE_NUMMER, PERSOON_NUMMER, BESTAND_NUMMER, DATUMTIJD, OPMERKING) VALUES (" + insertedId + ", " + reactie.PersoonNummer + ", " + bestand.Nummer + ", TO_DATE('" + reactie.DatumTijd.ToString("yyyy-MM-dd HH:mm:ss") + "', 'SYYYY-MM-DD HH24:MI:SS'), '" + this.Escape(reactie.Opmerking) + "')");
            return insertedId;
        }
    }
}
