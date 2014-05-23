using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public partial class Reservering
    {
        public int Nummer
        {
            get; 
            set;
        }
        public bool Betaald
        {
            get; 
            private set;
        }
        public DateTime Datum
        {
            get; 
            private set;
        }

        public Hoofdboeker Hoofdboeker
        {
            get
            {
                return Persoon.GetHoofdboekerBijReservering(this);
            }
        }
        public List<Bijboeker> Bijboekers
        {
            get
            {
                return Persoon.GetBijboekersBijReservering(this);
            }
        }
        public List<Kampeerplaats> Kampeerplaatsen
        {
            get
            {
                return new List<Kampeerplaats>();
            }
        }
        
        public List<Materiaal> Materialen
        {
            get
            {
                return new List<Materiaal>();
            }
        }

        public Reservering(DateTime datum = default(DateTime), bool betaald = false)
        {
            if(datum.Equals(default(DateTime)))
            {
                datum = DateTime.Now;
            }

            this.Betaald = Betaald;
            this.Datum = datum;   
        }

        public Reservering(int reserveringsnummer, DateTime datum, bool betaald) 
            :this(datum, betaald)
        {
            this.Nummer = reserveringsnummer;
        }
        public void AddBijboeker(Boeker bijboeker)

        {
            bijboeker.ReserveringNummer = this.Nummer;
            Persoon.AddPersoon(bijboeker);
        }
        public void DeleteBijboeker(Boeker bijboeker)
        {
            Persoon.DeletePersoon(bijboeker);
        }

        public void ZetOpBetaald()
        {
            Reservering.ZetOpBetaald(this);
            this.Betaald = true;
        }

        /*public void AddMateriaal(Materiaal materiaal)
        {
            Reservering.AddMateriaal(materiaal);
        }*/

        // NOG TE MAKEN
        public void Delete()
        {
            Reservering.DeleteReservering(this);  
        }
    }
}
