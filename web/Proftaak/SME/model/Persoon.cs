using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace SME
{
    public abstract partial class Persoon : IEquatable<Persoon>
    {
        /// <summary>
        /// Het nummer van de persoon.
        /// </summary>
        public string Nummer
        {
            get;
            private set;
        }

        /// <summary>
        /// Het wachtwoord van een persoon.
        /// </summary>
        private string wachtwoord;

        private bool aanwezig;
        public bool Aanwezig
        {
            get{
                return aanwezig;
            }
            set{
                aanwezig = value;
                UpdateAanwezigheid(this);
            }
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
        public Persoon(string nummer, string naam, string wachtwoord, bool aanwezig)
        {
            this.Nummer = nummer;
            this.Naam = naam;
            this.wachtwoord = wachtwoord;
            this.Aanwezig = aanwezig;
            
        }

        public Persoon(string naam, string wachtwoord = null, bool aanwezig = false)
        {
            if (wachtwoord == null)
            {
                wachtwoord = Path.GetRandomFileName().Replace(".", "");
            }
            this.Naam = naam;
            this.wachtwoord = wachtwoord;
            this.Aanwezig = aanwezig;
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

        public void Delete()
        {
            Persoon.DeletePersoon(this);
        }

        // Nog te maken
        public static bool Login(string rfid, string wachtwoord)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "sme.marijnverwegen.nl"))
            {
                bool isValid = pc.ValidateCredentials(rfid, wachtwoord);
                if (isValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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

    public class Boeker : Persoon
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

        public Boeker(string nummer, string naam, string wachtwoord, bool aanwezig, int reserveringsnummer)
            : base(nummer, naam, wachtwoord, aanwezig)
        {

        }

        public Boeker(string naam, string wachtwoord = null, bool aanwezig = false, int reserveringsnummer = default(int))
            : base(naam, wachtwoord, aanwezig)
        {
            this.ReserveringNummer = reserveringsnummer;
        }
    }

    public class Hoofdboeker : Boeker
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
        public Hoofdboeker(string nummer, string naam, string wachtwoord, bool aanwezig, int reserveringsnummer, string straat, string postcode, string woonplaats, string telefoon, string email, string rekeningnummer, string sofinummer)
            : base(nummer, naam, wachtwoord, aanwezig, reserveringsnummer)
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

        public Hoofdboeker(string naam, string straat, string postcode, string woonplaats, string telefoon, string email, string rekeningnummer, string sofinummer, string wachtwoord = null, bool aanwezig = false)
            : base(naam, wachtwoord, aanwezig)
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

    public class Bijboeker : Boeker
    {
        /// <summary>
        /// Het aanmaken van een bijboeker.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Bijboeker(string nummer, string naam, string wachtwoord, bool aanwezig, int reserveringsnummer)
            : base(nummer, naam, wachtwoord, aanwezig, reserveringsnummer)
        {

        }

        public Bijboeker(string naam, string wachtwoord, bool aanwezig, int reserveringsnummer = default(int))
            : base(naam, wachtwoord, aanwezig, reserveringsnummer)
        {

        }
    }
    public class Medewerker : Persoon
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
        public Medewerker(string nummer, string naam, string wachtwoord, bool aanwezig, string functie, string rekeningnummer)
            : base(nummer, naam, wachtwoord, aanwezig)
        {
            this.Functie = functie;
            this.Rekeningnummer = rekeningnummer;
        }

        public Medewerker(string naam, string wachtwoord, bool aanwezig, string functie, string rekeningnummer)
            : base(naam, wachtwoord, aanwezig)
        {
            this.Functie = functie;
            this.Rekeningnummer = rekeningnummer;
        }
    }
}
