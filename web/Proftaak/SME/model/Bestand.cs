using System;
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
        private int uploader;

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
                    Dictionary<int, Persoon> personen = Persoon.GetPersonenBijRFIDs(reacties.Select(r => r.PersoonNummer).ToList<int>());

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
        public Bestand(int mapnummer, string naam, string beschrijving, string extensie, int grootte, int rfid, DateTime datum, int gedownload, int rating, string pad, int imgindex)
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
        public Bestand(int nummer, int mapnummer, string naam, string beschrijving, string extensie, int grootte, int rfid, DateTime datum, int gedownload, int rating, string pad, int imgindex)
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
            this.Rating += 1;

            if (this.likes != null)
            {
                this.likes.Add(persoon);
            }

            if (this.dislikes != null && this.dislikes.Contains(persoon))
            {
                this.dislikes.Remove(persoon);
                this.Rating += 1;
            }
        }

        /// <summary>
        /// Het toevoegen van een dislike aan het bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddDislike(Persoon persoon)
        {
            Bestand.AddDislike(this, persoon);
            this.Rating -= 1;

            if (this.dislikes != null)
            {
                this.dislikes.Add(persoon);
            }

            if (this.likes != null && this.likes.Contains(persoon)) 
            { 
                this.likes.Remove(persoon);
                this.Rating -= 1;
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
            reactie.Nummer = Reactie.AddReactie(this, reactie);

            this.reacties.Add(reactie);
        }

        /// <summary>
        /// Het uploaden van een bestand.
        /// </summary>
        /// <param name="bestandslocatie"></param>
        /// <returns>Geeft terug of het uploaden wel of niet is gelukt.</returns>
        public bool Uploaden(string bestandslocatie)
        {
            this.Pad = this.Datum.ToFileTime() + (new FileInfo(bestandslocatie)).Extension;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.trink.nl/" + this.Bestandslocatie);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("sme@trink.nl", "sme");

            byte[] file = File.ReadAllBytes(bestandslocatie);

            request.ContentLength = file.Length;

            using (Stream rs = request.GetRequestStream())
            {
                rs.Write(file, 0, file.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == FtpStatusCode.ClosingData)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Het downloaden van een bestand naar een bestandslocatie.
        /// </summary>
        /// <param name="naarlocatie"></param>
        public void Downloaden(string naarlocatie)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.trink.nl/" + this.Pad);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("sme@trink.nl", "sme");

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream rs = response.GetResponseStream())
                {
                    byte[] buffer = new byte[2048];

                    int ReadCount = rs.Read(buffer, 0, buffer.Length);

                    using(FileStream fs = new FileStream(naarlocatie, FileMode.Create, FileAccess.Write))
                    {
                        while (ReadCount > 0)
                        {
                            fs.Write(buffer, 0, ReadCount);
                            ReadCount = rs.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
