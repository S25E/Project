using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectP3Reserveringsapplicatie
{
    class Reservering
    {
        public Hoofdboeker Hoofdboeker;
        public List<Bijboeker> Bijboekers = new List<Bijboeker>();
        public List<Kampeerplaats> Kampeerplaatsen = new List<Kampeerplaats>();
        public int Reserveringsnummer;
        public bool Betaald;
        public int AantalPersonen;
        public List<Materiaal> Materialen = new List<Materiaal>();

        public Reservering(Hoofdboeker Hoofdboeker, List<Bijboeker> Bijboekers, List<Kampeerplaats> Kampeerplaatsen, int Reserveringsnummer, bool Betaald, int AantalPersonen, List<Materiaal> Materialen)
        {
            this.Hoofdboeker = Hoofdboeker;
            this.Bijboekers = Bijboekers;
            this.Kampeerplaatsen = Kampeerplaatsen;
            this.Reserveringsnummer = Reserveringsnummer;
            this.Betaald = Betaald;
            this.AantalPersonen = AantalPersonen;
            this.Materialen = Materialen;
        }

        public Reservering(Hoofdboeker Hoofdboeker, List<Bijboeker> Bijboekers, List<Kampeerplaats> Kampeerplaatsen, int Reserveringsnummer, bool Betaald, int AantalPersonen)
        {
            this.Hoofdboeker = Hoofdboeker;
            this.Bijboekers = Bijboekers;
            this.Kampeerplaatsen = Kampeerplaatsen;
            this.Reserveringsnummer = Reserveringsnummer;
            this.Betaald = Betaald;
            this.AantalPersonen = AantalPersonen;
        }

        public Reservering(int Reserveringsnummer) //nieuw
        {
            this.Reserveringsnummer = Reserveringsnummer;
        }

        public void AddPersoon(Persoon persoon, bool hb)
        {
            if (hb == false)
            {
                Bijboeker b = persoon as Bijboeker;

                if (b != null)
                {
                    Bijboekers.Add(b);
                }
            }
            else
            {
                Hoofdboeker h = persoon as Hoofdboeker;
                if (h != null)
                {
                    Hoofdboeker = h;
                }
            }
        }

        //public void DeletePersoon(Persoon persoon)
        //{

        //}

        //public void ZetOpBetaald() in form3
        //{

        //}

        public void AddMateriaal(Materiaal materiaal)
        {
            Materialen.Add(materiaal);
        }
    }
}
