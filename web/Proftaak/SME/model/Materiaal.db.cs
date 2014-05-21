using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class Materiaal
    {
        public static void AddMateriaal(Materiaal materiaal)
        {
            Database.Execute("INSERT INTO Materiaal (barcode, naam, aantal, verhuurprijs, omschrijving, categorie) VALUES (@barcode, @naam, @aantal, @verhuurprijs, @omschrijving, @categorie)", new Dictionary<string, object>()
            {
                {"@barcode", materiaal.Barcode},
                {"@naam", materiaal.Naam},
                {"@aantal", materiaal.Aantal},
                {"@verhuurprijs", materiaal.Verhuurprijs},
                {"@omschrijving", materiaal.Omschrijving},
                {"@categorie", materiaal.Categorie}
            });
        }

        public static void UpdateAantal(Materiaal materiaal)
        {
            Database.Execute("UPDATE MATERIAAL SET AANTAL = " + materiaal.aantal + " WHERE  BARCODE = @BARCODE", new Dictionary<string, object>(){
                {"@barcode", materiaal.Barcode}
            });
        }
        public static void DeleteMateriaal(Materiaal materiaal)
        {

            Database.Execute("DELETE FROM Materiaal ");
        }
    }
}