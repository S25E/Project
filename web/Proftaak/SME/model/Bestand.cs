﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace SME
{
    public partial class Bestand
    {
        /// <summary>
        /// Het nummer van het bestand
        /// </summary>
        public int Nummer
        {
            get;
            set;
        }

        /// <summary>
        /// Het nummer van de map waar het bestand onderdeel van is.
        /// </summary>
        public int MapNummer
        {
            get;
            private set;
        }

        /// <summary>
        /// De map waar het bestand onderdeel van is.
        /// </summary>
        private Map map = null;
        public Map Map
        {
            get
            {
                if (map != null)
                    return this.map;
                else if (this.MapNummer != 0)
                    return this.map = Map.GetMapBijNummer(this.MapNummer);
                return null;
            }
            set
            {
                if (this.MapNummer == value.Nummer)
                    this.map = value;
            }
        }

        /// <summary>
        /// De bestandsnaam van het bestand
        /// </summary>
        public string Naam
        {
            get;
            private set;
        }

        /// <summary>
        /// Een eventuele opmerking die bij het bestand vermeld is.
        /// </summary>
        public string Beschrijving
        {
            get;
            private set;
        }

        public string Extensie
        {
            get;
            private set;
        }


        /// <summary>
        /// De grootte van het bestand.
        /// </summary>
        public int Grootte
        {
            get;
            private set;
        }

        /// <summary>
        /// Het nummer van de persoon die het bestand heeft geupload.
        /// </summary>
        private string uploader;

        /// <summary>
        /// De persoon die het bestand heeft geupload -> wordt opgehaald aan de hand van het nummer van de persoon die het bestand heeft geupload.
        /// </summary>
        public Persoon Uploader
        {
            get {
                return Persoon.GetPersoonBijRFID(this.uploader);
            }
        }

        /// <summary>
        /// De uploaddatum van het bestand.
        /// </summary>
        public DateTime Datum
        {
            get;
            private set;
        }

        public int Gedownload
        {
            get;
            private set;
        }

        public int Rating
        {
            get;
            set;
        }

        /// <summary>
        /// De bestandsnaam die het bestand heeft op de server.
        /// </summary>
        public string Pad
        {
            get;
            private set;
        }

        public int Image
        {
            get;
            private set;
        }

        /// <summary>
        /// Een lijst met personen die het bestand geliked hebben.
        /// </summary>
        private List<Persoon> likes;
        public List<Persoon> Likes
        {
            get
            {
                if (this.likes == null)
                    this.likes = Persoon.GetLikes(this);

                return this.likes;
            }
            set
            {
                this.likes = null;
            }
        }

        /// <summary>
        /// Een lijst met personen die het bestand gedisliked hebben.
        /// </summary>
        private List<Persoon> dislikes;
        public List<Persoon> Dislikes
        {
            get
            {
                if (this.dislikes == null)
                    this.dislikes = Persoon.GetDislikes(this);

                return this.dislikes;
            }
            set
            {
                this.dislikes = value;
            }
        }

        /// <summary>
        /// Een lijst met personen die het bestand gereported hebben.
        /// </summary>
        private List<Persoon> reports;
        public List<Persoon> Reports
        {
            get
            {
                if (this.reports == null)
                    this.reports = Persoon.GetReports(this);

                return this.reports;
            }
            set
            {
                this.reports = null;
            }
        }

        /// <summary>
        /// Een lijst met reacties die geplaatst zijn bij het bestand.
        /// </summary>
        private List<Reactie> reacties;
        public List<Reactie> Reacties
        {
            get
            {
                if (this.reacties == null)
                {
                    List<Reactie> reacties = Reactie.GetReactiesBijBestand(this);
                    Dictionary<string, Persoon> personen = Persoon.GetPersonenBijRFIDs(reacties.Select(r => r.PersoonNummer).ToList<string>());

                    foreach (Reactie reactie in reacties)
                        reactie.Persoon = personen[reactie.PersoonNummer];

                    this.reacties = reacties;
                }

                return this.reacties;
            }
            set
            {
                this.reacties = value;
            }
        }

        /// <summary>
        /// Een bestand aanmaken, waarvan het bestandsnummer nog niet bekend is. => moet nog worden toegevoegd aan database.
        /// </summary>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        public Bestand(int mapnummer, string naam, string beschrijving, string extensie, int grootte, string rfid, DateTime datum, int gedownload, int rating, string pad, int imgindex)
        {
            this.MapNummer = mapnummer;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Extensie = extensie;
            this.Grootte = grootte;
            this.uploader = rfid;
            this.Datum = datum;
            this.Gedownload = gedownload;
            this.Rating = rating;
            this.Pad = pad;
            this.Image = Image;
        }

        /// <summary>
        /// Een bestand maken, waarvan het bestandsnummer al bekend van is.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        public Bestand(int nummer, int mapnummer, string naam, string beschrijving, string extensie, int grootte, string rfid, DateTime datum, int gedownload, int rating, string pad, int imgindex)
            : this(mapnummer, naam, beschrijving, extensie, grootte, rfid, datum, gedownload, rating, pad, imgindex)
        {
            this.Nummer = nummer;
        }

        /// <summary>
        /// Het toevoegen van een Like aan het bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddLike(Persoon persoon)
        {
            Bestand.AddLike(this, persoon);

            if (this.likes != null)
            {
                this.likes.Add(persoon);
            }
        }

        /// <summary>
        /// Het toevoegen van een dislike aan het bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddDislike(Persoon persoon)
        {
            Bestand.AddDislike(this, persoon);

            if (this.dislikes != null)
            {
                this.dislikes.Add(persoon);
            }
        }

        /// <summary>
        /// Het toevoegen van een report aan een bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddReport(Persoon persoon)
        {
            Bestand.AddReport(this, persoon);

            if (this.reports != null)
            {
                this.reports.Add(persoon);
            }
        }

        /// <summary>
        /// Het toevoegen van een reactie aan een bestand.
        /// </summary>
        /// <param name="reactie"></param>
        public void AddReactie(Reactie reactie)
        {
            Reactie.AddReactie(this, reactie);

            if (this.reacties != null)
            {
                this.reacties.Add(reactie);
            }
        }

        public void Download()
        {
            Bestand.Download(this);
        }
    }
}
