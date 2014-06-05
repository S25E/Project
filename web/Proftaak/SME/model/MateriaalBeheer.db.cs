using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SME
{
    public partial class MateriaalBeheer
    {

        public static void Leenuit(string Barcode, int rfid, int aantal)
        {
            string First = Barcode.Substring(0, Barcode.IndexOf(","));
            Database.Execute("INSERT INTO UITLENING (RESERVERINGNUMMER, BARCODE, DATUM_UITGELEEND, DATUM_INGELEVERD, AANTAL) VALUES (@reserveringnummer, @barcode, @datum_uitgeleend, @datum_ingeleverd, @aantal)", new Dictionary<string, object>()
        {
            {"@reserveringnummer", rfid},
            {"@barcode", First},
            {"@datum_uitgeleend", DateTime.Today},
            {"@datum_ingeleverd", null},
            {"@aantal", aantal}
        });
        }
        //test
        public static void BrengTerug(Materiaal materiaal, Persoon persoon, int aantal)
        {
            int nummer = Convert.ToInt32(Database.GetData("SELECT AANTAL FROM UITLENING WHERE BARCODE = @BARCODE AND RESERVERINGNUMMER = @RESERVERINGNUMMER)", new Dictionary<string, object>()
              {
                {"@barcode", materiaal.Barcode},
                {"@reserveringnummer", persoon.Nummer}
              }).Rows[0]["AANTAL"]);
            
            if ( (nummer - aantal) >= 1 )
            {
                Database.Execute("UPDATE UITLENING SET aantal = aantal - " + aantal); 
            }
            else
            {
            Database.Execute("UPDATE UITLENING SET DATUM_INGELEVERD = @DATUM)", new Dictionary<string, object>()
            {
                {"@DATUM", DateTime.Today}
            });
            }
        }
    }
}
