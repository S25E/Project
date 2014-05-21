using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public partial class Kampeerplaats
    {
        public int Nummer {get; private set;}
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Prijs { get; private set; }
        public string Opmerking { get; private set; }
        
        
        /// <summary>
        /// Constructor, deze wordt gebruikt voor het ophalen van de kampeerplaatsen
        /// </summary>
        /// <param name="Reserveringsnummer">Het Reserveringsnummer</param>
        /// <param name="Nummer">Het Plaatsnummer</param>
        /// <param name="Opmerking">Opmerking van de kampeerplaats</param>
        /// <param name="Oppervlakte">Oppervlakte van de kampeerplaats</param>
        /// <param name="X">X coordinaat van de kamperplaats</param>
        /// <param name="Y">T coordinaat van de kamperplaats</param>
        public Kampeerplaats(int Nummer, string Opmerking, int Prijs, int X, int Y)
        {
            this.Nummer = Nummer;
            this.X = X;
            this.Y = Y;
            this.Prijs = Prijs;
            this.Opmerking = Opmerking;
            
        }

        /// <summary>
        /// Constructor, deze wordt gebruikt voor het aanmaken van een reservering
        /// </summary>
        /// <param name="Nummer">Kampeerplaatsnummer</param>
        public Kampeerplaats(int Nummer)
        {
            this.Nummer = Nummer;
        }

        //public bool IsBeschikbaar()
        //{
            
        //}
    }
}
