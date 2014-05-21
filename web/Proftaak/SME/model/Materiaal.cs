using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public partial class Materiaal
    {
        public string Barcode { get; set; }
        public string Naam { get; set; }

        private int aantal;
        public int Aantal {
            get
            {
                return aantal;
            }
            set {
                this.aantal = value;
                Materiaal.UpdateAantal(this);
            } 
        }
        public int Verhuurprijs { get; set; }
        public string Omschrijving { get; set; }
        public string Categorie { get; set; }

        /// <summary>
        /// Constructor, deze wordt gebruik bij het aanmaken van een reservering
        /// </summary>
        /// <param name="Persoonsnaam"></param>
        /// <param name="Persoonnummer"></param>
        /// <param name="Productnaam"></param>
        /// <param name="Barcode"></param>
        public Materiaal(string barcode, string naam, int aantal, int verhuurprijs, string omschrijving, string categorie)
        {
            this.Barcode = barcode;
            this.Naam = naam;
            this.aantal = aantal;
            this.Verhuurprijs = verhuurprijs;
            this.Omschrijving = omschrijving;
            this.Categorie = categorie;
        }
    }
}
