using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectP3Reserveringsapplicatie
{
    class Hoofdboeker : Persoon
    {
        public string Adres;
        public string Postcode;
        public string Woonplaats;
        public string Email;
        public string Rekeningnummer;

        public Hoofdboeker(int Nummer, string Naam, string Telefoonnummer, string Wachtwoord, string Adres, string Postcode, string Woonplaats, string Email, string Rekeningnummer)
            : base(Nummer, Naam, Telefoonnummer, Wachtwoord)
        {
            this.Adres = Adres;
            this.Postcode = Postcode;
            this.Woonplaats = Woonplaats;
            this.Email = Email;
            this.Rekeningnummer = Rekeningnummer;
        }

    }
}