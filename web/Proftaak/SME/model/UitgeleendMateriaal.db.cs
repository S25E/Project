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
        public static UitgeleendMateriaal rowToMateriaal(DataRow row)
        {
            return new UitgeleendMateriaal(row["BARCODE"].ToString(), row["NAAM"].ToString(), Convert.ToInt32(row["AANTAL"]), Convert.ToInt32(row["VERHUURPRIJS"]), row["OMSCHRIJVING"].ToString(), row["CATEGORIE"].ToString());
        }

        public static UitgeleendMateriaal GetUitgeleendMateriaalBijReservering(string reserveringnummer)
        {
            foreach (DataRow row in getMaterialenByWhere("reserveringsnummer = " + reserveringnummer).Rows)
            {
                return rowToMateriaal(row);
            }

            return (UitgeleendMateriaal)null;
        }
    }
}