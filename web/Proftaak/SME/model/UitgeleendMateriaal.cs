using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class UitgeleendMateriaal : Materiaal
    {
        public new int Aantal
        {
            get;
            set;
        }

        public UitgeleendMateriaal(string barcode, string naam, int aantal, int verhuurprijs, string omschrijving, string categorie)
            : base(barcode, naam, aantal, verhuurprijs, omschrijving, categorie)
        {
            this.Barcode = barcode;
            this.Naam = naam;
            this.Aantal = aantal;
            this.Verhuurprijs = verhuurprijs;
            this.Omschrijving = omschrijving;
            this.Categorie = categorie;
        }
    }
}