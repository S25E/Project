using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public partial class Materiaal
    {
        public string Soort { get; set; }
        public int Aantal { get; set; }
        public int Verhuurprijs { get; set; }
        public string Barcode { get; set; }
        public string Omschrijving { get; set; }
        public string Categorie { get; set; }

        /// <summary>
        /// Constructor, deze wordt gebruik bij het aanmaken van een reservering
        /// </summary>
        /// <param name="Persoonsnaam"></param>
        /// <param name="Persoonnummer"></param>
        /// <param name="Productnaam"></param>
        /// <param name="Barcode"></param>
        public Materiaal(string soort, int aantal, int verhuurprijs, string barcode, string naam, string omschrijving, string categorie)
        {
            this.Soort = soort;
            this.Aantal = aantal;
            this.Verhuurprijs = verhuurprijs;
            this.Barcode = barcode;
            this.Omschrijving = omschrijving;
            this.Categorie = categorie;
        }
    }
}
