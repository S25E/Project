using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    class Reservering
    {
        public Hoofdboeker Hoofdboeker;
        public List<Bijboeker> Bijboekers;
        public List<Kampeerplaats> Kampeerplaatsen;
        public int Reserveringsnummer;
        public bool Betaald;
        public int AantalPersonen;
        public List<Materiaal> Materialen;

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

        //public void AddPersoon(Persoon persoon)
        //{

        //}

        //public void DeletePersoon(Persoon persoon)
        //{

        //}

        //public void ZetOpBetaald()
        //{

        //}

        //public decimal BerekenPrijs()
        //{
        //    
        //}
    }
}
