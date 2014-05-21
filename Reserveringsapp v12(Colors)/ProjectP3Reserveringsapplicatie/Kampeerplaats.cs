using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectP3Reserveringsapplicatie
{
    class Kampeerplaats
    {
        public int Reserveringsnummer;
        public int Nummer;
        public string Opmerking;
        public int Oppervlakte;
        public int X;
        public int Y;
        
        /// <summary>
        /// Constructor, deze wordt gebruikt voor het ophalen van de kampeerplaatsen
        /// </summary>
        /// <param name="Reserveringsnummer">Het Reserveringsnummer</param>
        /// <param name="Nummer">Het Plaatsnummer</param>
        /// <param name="Opmerking">Opmerking van de kampeerplaats</param>
        /// <param name="Oppervlakte">Oppervlakte van de kampeerplaats</param>
        /// <param name="X">X coordinaat van de kamperplaats</param>
        /// <param name="Y">T coordinaat van de kamperplaats</param>
        public Kampeerplaats(int Reserveringsnummer, int Nummer, string Opmerking, int Oppervlakte, int X, int Y)
        {
            this.Reserveringsnummer = Reserveringsnummer;
            this.Nummer = Nummer;
            this.Opmerking = Opmerking;
            this.Oppervlakte = Oppervlakte;
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Constructor, deze wordt gebruikt voor het aanmaken van een reservering
        /// </summary>
        /// <param name="Nummer">Kampeerplaatsnummer</param>
        //public Kampeerplaats(int Nummer)
        //{
        //    this.Nummer = Nummer;
        //}

        //public bool IsBeschikbaar()
        //{
            
        //}
    }
}
