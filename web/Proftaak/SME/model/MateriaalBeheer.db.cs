using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SME
{
    public partial class MateriaalBeheer
    {

        public static void Leenuit(Materiaal materiaal, Persoon persoon, int aantal)
        {
            Database.Execute("INSERT INTO UITLENING (RESERVERINGNUMMER, BARCODE, DATUM_UITGELEEND, DATUM_INGELEVERD, AANTAL) VALUES (@reserveringnummer, @barcode, @datum_uitgeleend, @datum_ingeleverd, @aantal)", new Dictionary<string, object>()
        {
            {"@reserveringnummer", persoon.Nummer},
            {"@barcode", materiaal.Barcode},
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
                Database.Execute("UPDATTE UITLENING SET aantal = aantal - " + aantal); 
            }
            else
            {
            Database.Execute("DELETE FROM UITLENING WHERE BARCODE = @BARCODE AND RESERVERINGNUMMER = @RESERVERINGNUMMER)", new Dictionary<string, object>()
            {
                {"@barcode", materiaal.Barcode},
                {"@reserveringnummer", persoon.Nummer}
            });
            }
        }
    }
}
