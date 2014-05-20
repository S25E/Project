using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectP3Reserveringsapplicatie
{
    class Persoon
    {
        public int Nummer;
        public string Naam;
        public string Telefoonnummer;
        public string Wachtwoord; //public gemaakt anders niet in te voeren in db

        public Persoon(int Nummer, string Naam, string Telefoonnummer, string Wachtwoord)
        {
            this.Nummer = Nummer;
            this.Naam = Naam;
            this.Telefoonnummer = Telefoonnummer;
            this.Wachtwoord = Wachtwoord;
            Naam = "";
        }
    }
}
