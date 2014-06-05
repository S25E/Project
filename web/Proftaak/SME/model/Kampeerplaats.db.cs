using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SME
{
	public partial class Kampeerplaats
	{
        public static Kampeerplaats GetKampeerplaatsBijNummer(int nummer)
        {
            
            foreach (DataRow row in  Database.GetData("SELECT COORDINAAT_X AS x, COORDINAAT_Y AS y, PRIJS, OPMERKINGEN FROM KAMPEERPLAATS WHERE PLAATSNUMMER = " + nummer).Rows)
            {
                return new Kampeerplaats(nummer, Convert.ToInt32(row["x"]), Convert.ToInt32(row["y"]), Convert.ToInt32(row["PRIJS"]), row["OPMERKINGEN"].ToString());
            }
            return null;
        }

        public static List<Kampeerplaats> GetKampeerplaatsen()
        {
            List<Kampeerplaats> kampeerplaatsen = new List<Kampeerplaats>();
            foreach (DataRow row in Database.GetData("SELECT PLAATSNUMMER, COORDINAAT_X AS x, COORDINAAT_Y AS y, PRIJS, OPMERKINGEN FROM KAMPEERPLAATS").Rows)
            {
                kampeerplaatsen.Add(new Kampeerplaats(Convert.ToInt32(row["PLAATSNUMMER"]), Convert.ToInt32(row["x"]), Convert.ToInt32(row["y"]), Convert.ToInt32(row["PRIJS"]), row["OPMERKINGEN"].ToString()));
            }
            return kampeerplaatsen;
        }

        public static bool IsBeschikbaar(int nummer)
        {
            if(Database.GetData("SELECT RESERVERINGSNUMMER FROM RESERVERING_PLAATS WHERE PLAATSNUMMER =" + nummer).Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Toegevoegd
        public static List<Kampeerplaats> GetVrijeKampeerplaatsen()
        {
            List<Kampeerplaats> Kampeerplaatsen = new List<Kampeerplaats>();
            DataTable dt = Database.GetData("SELECT PLAATSNUMMER, OPMERKINGEN FROM KAMPEERPLAATS WHERE PLAATSNUMMER NOT IN (SELECT PLAATSNUMMER FROM RESERVERING_PLAATS) ORDER BY PLAATSNUMMER");
            foreach(DataRow row in dt.Rows)
            {
                Kampeerplaats kampeerplaats = new Kampeerplaats(Convert.ToInt32(row["PLAATSNUMMER"]));
                Kampeerplaatsen.Add(kampeerplaats);
            }
            return Kampeerplaatsen;
        }
	}
}