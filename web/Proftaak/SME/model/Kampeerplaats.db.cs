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
            if(Database.GetData("SELECT RESERVERING_NUMMER FROM RESERVERING_PLAATS WHERE PLAATS_NUMMER =" + nummer).Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}