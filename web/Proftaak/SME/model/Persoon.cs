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
        /// De naam van een persoon.
        /// </summary>
        public string Naam
        {
            get;
            private set;
        }

        /// <summary>
        /// Het wachtwoord van een persoon.
        /// </summary>
        private string wachtwoord;

        /// <summary>
        /// Het maken van een persoon waarvan het nummer al bekend is => de persoon staat al in database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Persoon(int nummer, string naam, string wachtwoord)
        {
            this.Nummer = nummer;
            this.Naam = naam;
            this.wachtwoord = wachtwoord;
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
    class Hoofdboeker : Persoon
    {
        /// <summary>
        /// Het aanmaken van een hoofdboeker. 
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Hoofdboeker(int nummer, string naam, string wachtwoord)
            : base(nummer, naam, wachtwoord)
        {

        }
    }
    class Bijboeker : Persoon
    {
        /// <summary>
        /// Het aanmaken van een bijboeker.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Bijboeker(int nummer, string naam, string wachtwoord)
            : base(nummer, naam, wachtwoord)
        {

        }
    }
    class Medewerker : Persoon
    {
        /// <summary>
        /// Het aanmaken van een medewerker.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="wachtwoord"></param>
        public Medewerker(int nummer, string naam, string wachtwoord)
            : base(nummer, naam, wachtwoord)
        {

        }
    }
}
