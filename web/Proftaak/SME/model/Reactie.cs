﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public partial class Reactie
    {
        /// <summary>
        /// Het nummer van de reactie.
        /// </summary>
        public int Nummer
        {
            get;
            set;
        }

        /// <summary>
        /// Het nummer van de persoon die de reactie heeft geplaatst.
        /// </summary>
        public string PersoonNummer
        {
            get;
            private set;
        }

        /// <summary>
        /// De persoon die de reactie heeft geplaatst.
        /// </summary>
        private Persoon persoon;
        public Persoon Persoon
        {
            get {
                if (this.persoon == null)
                    this.persoon = Persoon.GetPersoonBijRFID(this.PersoonNummer);

                return this.persoon;
            }
            set {
                this.persoon = value;
            }
        }

        /// <summary>
        /// De tijd waarop de reactie is geplaatst.
        /// </summary>
        public DateTime Datum
        {
            get;
            private set;
        }

        /// <summary>
        /// De opmerking die een persoon als reactie heeft geplaatst.
        /// </summary>
        public string Opmerking
        {
            get;
            set;
        }

        /// <summary>
        /// Het aanmaken van een reactie waarvan het nummer bekend is => de reactie staat al in de database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="persoonnummer"></param>
        /// <param name="opmerking"></param>
        /// <param name="datumtijd"></param>
        public Reactie(int nummer, string persoonnummer, DateTime datum, string opmerking)
            : this(persoonnummer, datum, opmerking)
        {
            this.Nummer = nummer;
        }

        /// <summary>
        /// Het aaanmaken van een reactie waarvan het nummer nog niet bekend is => de reactie staat nog niet in de datatabase.
        /// </summary>
        /// <param name="persoonnummer"></param>
        /// <param name="opmerking"></param>
        /// <param name="datumtijd"></param>
        public Reactie(string persoonnummer, DateTime datum, string opmerking)
        {
            this.PersoonNummer = persoonnummer;
            this.Opmerking = opmerking;
            this.Datum = datum;
        }

        /// <summary>
        /// Het toevoegen van een report aan een reactie.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddReport(Persoon persoon)
        {
            Reactie.AddReport(this, persoon);
        }

        /// <summary>
        /// Het converteren van een reactie naar het juiste formaat.
        /// </summary>
        /// <returns>Reactie als string.</returns>
        public override string ToString()
        {
            return this.Persoon.Naam + " zei: " + this.Opmerking;
        }
    }
}
