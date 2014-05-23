using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class MateriaalBeheer
    {
        public static void Leenuit(Materiaal materiaal, Persoon persoon)
        {
            Database.Execute("INSERT INTO UITLENING (RESERVERINGNUMMER, BARCODE, DATUM_UITGELEEND, DATUM_INGELEVERD, AANTAL) VALUES (@reserveringnummer, @barcode, @datum_uitgeleend, @datum_ingeleverd, @aantal)", new Dictionary<string, object>()
        {
            {"@reserveringnummer", 1},
            {"@barcode", materiaal.Barcode},
            {"@datum_uitgeleend", DateTime.Today},
            {"@datum_ingeleverd", null},
            {"@datum_ingeleverd", 1}
        });
        }
        //test
        public static void BrengTerug(Materiaal materiaal, Persoon persoon, int aantal)
        {
            if (Convert.ToInt32(Database.GetData("SELECT AANTAL FROM UITLENING WHERE BARCODE = @BARCODE" )) >0 )
            { }

            Database.Execute("DELETE FROM UITLENING WHERE BARCODE = @BARCODE AND RESERVERINGNUMMER = @RESERVERINGNUMMER)", new Dictionary<string, object>()
            {
                {"@barcode", materiaal.Barcode},
                {"@reserveringnummer", persoon.Nummer}
            });
        }
    }
}
