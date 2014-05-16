using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    class Materiaal
    {
        public string Persoonsnaam;
        public int Persoonnummer;
        public string Productnaam;
        public int Barcode;

        /// <summary>
        /// Constructor, deze wordt gebruik bij het aanmaken van een reservering
        /// </summary>
        /// <param name="Persoonsnaam"></param>
        /// <param name="Persoonnummer"></param>
        /// <param name="Productnaam"></param>
        /// <param name="Barcode"></param>
        public Materiaal(string Persoonsnaam, int Persoonnummer, string Productnaam, int Barcode)
        {
            this.Persoonsnaam = Persoonsnaam;
            this.Persoonnummer = Persoonnummer;
            this.Productnaam = Productnaam;
            this.Barcode = Barcode;
        }
    }
}
