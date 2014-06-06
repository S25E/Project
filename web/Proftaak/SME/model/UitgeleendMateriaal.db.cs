using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class UitgeleendMateriaal
    {
        private static DataTable getMaterialenByWhere(string where, Dictionary<string, object> parameters = default(Dictionary<string, object>))
        {

            return Database.GetData("SELECT * FROM Uitlening" + (where != "" ? " WHERE " + where : ""), parameters);

        }
        public static UitgeleendMateriaal rowToUitgeleendMateriaal(DataRow row)
        {
            return new UitgeleendMateriaal(row["BARCODE"].ToString(), row["NAAM"].ToString(), Convert.ToInt32(row["AANTAL"]), Convert.ToInt32(row["VERHUURPRIJS"]), row["OMSCHRIJVING"].ToString(), row["CATEGORIE"].ToString());
        }

        public static string GetUitgeleendMateriaalBijReservering(string reserveringnummer)
        {
            foreach (DataRow row in Database.GetData("SELECT * FROM UITLENING WHERE RESERVERINGSNUMMER = '" + reserveringnummer + "'").Rows)
            {
               Materiaal materiaal = Materiaal.GetMateriaalBijBarcode((row["BARCODE"]).ToString());
                if ((row["datum_uitgeleend"]) == DBNull.Value)
                {
                    return (materiaal.Barcode +", " + materiaal.Naam + ", aantal:" + row["aantal"] + ", status: gereserveerd");
                }
                else
                {
                    return (materiaal.Barcode +", " + materiaal.Naam + ", aantal:" + row["aantal"] + ", status: uitgeleend");
                }

            }

            return null;
        }

        // return (string)null;
    }
}
