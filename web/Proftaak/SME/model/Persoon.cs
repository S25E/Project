using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public abstract partial class Persoon : IEquatable<Persoon>
    {
        /// <summary>
        /// Het nummer van de persoon.
        /// </summary>
        public int Nummer
        {
            get;
            private set;
        }

        /// <summary>
        /// Het wachtwoord van een persoon.
        /// </summary>
        private string wachtwoord;

        public bool Aanwezig
        {
            get;
            set;
        }

        public string Naam
        {
            get;
            set;
        }

        /// <summary>
        /// Het maken van een persoon waarvan het nummer al bekend is => de persoon staat al in database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Persoon(int nummer, string wachtwoord, bool aanwezig, string naam)
        {
            this.Nummer = nummer;
            this.wachtwoord = wachtwoord;
            this.Aanwezig = aanwezig;
            this.Naam = naam;
        }

        public Persoon(string wachtwoord, bool aanwezig, string naam)
        {
            this.wachtwoord = wachtwoord;
            this.Aanwezig = aanwezig;
            this.Naam = naam;
        }

        /// <summary>
        /// Het checken van het wachtwoord.
        /// </summary>
        /// <param name="wachtwoord"></param>
        /// <returns>Een bool of het wachtwoord wel of niet klopt</returns>
        public bool ControleerWachtwoord(string wachtwoord)
        {
            return this.wachtwoord == wachtwoord;
        }

        /// <summary>
        /// Om personen te vergelijken moet er aangegeven worden naar welk veld gekeken moet worden.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Persoon other)
        {
            return this.Nummer.Equals(other.Nummer);
        }
    }

    class Boeker : Persoon
    {
        public int ReserveringNummer
        {
            get;
            set;
        }

        public Reservering Reservering
        {
            get
            {
                // Lazy loading maken.
                return null;
            }
        }

        public Boeker(int nummer, string wachtwoord, bool aanwezig, string naam, int reserveringsnummer)
            : base(nummer, wachtwoord, aanwezig, naam)
        {

        }

        public Boeker(string wachtwoord, bool aanwezig, string naam, int reserveringsnummer)
            : base(wachtwoord, aanwezig, naam)
        {

        }
    }

    class Hoofdboeker : Boeker
    {
        public string Straat
        {
            get;
            set;
        }

        public string Postcode
        {
            get;
            set;
        }

        public string Woonplaats
        {
            get;
            set;
        }

        public string Telefoon
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Rekeningnummer
        {
            get;
            set;
        }

        public string Sofinummer
        {
            get;
            set;
        }

        /// <summary>
        /// Het aanmaken van een hoofdboeker. 
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Hoofdboeker(int nummer, string wachtwoord, bool aanwezig, string naam, int reserveringsnummer, string straat, string postcode, string woonplaats, string telefoon, string email, string rekeningnummer, string sofinummer)
            : base(nummer, wachtwoord, aanwezig, naam, reserveringsnummer)
        {
            this.Naam = naam;
            this.Straat = straat;
            this.Postcode = postcode;
            this.Woonplaats = woonplaats;
            this.Telefoon = telefoon;
            this.Email = email;
            this.Rekeningnummer = rekeningnummer;
            this.Sofinummer = sofinummer;
        }

        public Hoofdboeker(string wachtwoord, bool aanwezig, string naam, int reserveringsnummer, string straat, string postcode, string woonplaats, string telefoon, string email, string rekeningnummer, string sofinummer)
            : base(wachtwoord, aanwezig, naam, reserveringsnummer)
        {
            this.Naam = naam;
            this.Straat = straat;
            this.Postcode = postcode;
            this.Woonplaats = woonplaats;
            this.Telefoon = telefoon;
            this.Email = email;
            this.Rekeningnummer = rekeningnummer;
            this.Sofinummer = sofinummer;
        }
    }

    class Bijboeker : Boeker
    {
        /// <summary>
        /// Het aanmaken van een bijboeker.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Bijboeker(int nummer, string wachtwoord, bool aanwezig, string naam, int reserveringsnummer)
            : base(nummer, wachtwoord, aanwezig, naam, reserveringsnummer)
        {

        }

        public Bijboeker(string wachtwoord, bool aanwezig, string naam, int reserveringsnummer)
            : base(wachtwoord, aanwezig, naam, reserveringsnummer)
        {

        }
    }
    class Medewerker : Persoon
    {
        public string Functie
        {
            get;
            set;
        }

        public string Rekeningnummer
        {
            get;
            set;
        }

        /// <summary>
        /// Het aanmaken van een medewerker.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Medewerker(int nummer, string wachtwoord, bool aanwezig, string naam, string functie, string rekeningnummer)
            : base(nummer, wachtwoord, aanwezig, naam)
        {
            this.Functie = functie;
            this.Rekeningnummer = rekeningnummer;
        }

        public Medewerker(string wachtwoord, bool aanwezig, string naam, string functie, string rekeningnummer)
            : base(wachtwoord, aanwezig, naam)
        {
            this.Functie = functie;
            this.Rekeningnummer = rekeningnummer;
        }
    }
}
