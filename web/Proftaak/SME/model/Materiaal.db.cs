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
            Database.Execute("INSERT INTO Materiaal (soort, aantal, verhuurprijs, barcode, omschrijving, categorie) VALUES (@soort, @aantal, @verhuurprijs, @barcode, @omschrijving, @categorie)", new Dictionary<string, object>()
            {
                {"@soort", materiaal.Soort},
                {"@aantal", materiaal.Aantal},
                {"@verhuurprijs", materiaal.Verhuurprijs},
                {"@barcode", materiaal.Barcode},
                {"@omschrijving", materiaal.Omschrijving},
                {"@categorie", materiaal.Categorie}
            });
        }
    }
}