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
        /// Database connecties
        /// </summary>
        private PersoonDB persoondb = new PersoonDB();
        private BestandDB bestanddb = new BestandDB();
        private ReactieDB reactiedb = new ReactieDB();
        private MapDB mapdb = new MapDB();

        /// <summary>
        /// Het nummer van het bestand
        /// </summary>
        public int Nummer
        {
            get;
            set;
        }

        /// <summary>
        /// Het nummer van de persoon die het bestand heeft geupload.
        /// </summary>
        private int geuploaddoor;

        /// <summary>
        /// De persoon die het bestand heeft geupload -> wordt opgehaald aan de hand van het nummer van de persoon die het bestand heeft geupload.
        /// </summary>
        public Persoon GeuploadDoor
        {
            get {
                return this.persoondb.GetPersoonBijNummer(this.geuploaddoor);
            }
        }

        /// <summary>
        /// De bestandsnaam van het bestand
        /// </summary>
        public string Bestandsnaam
        {
            get;
            private set;
        }

        /// <summary>
        /// De bestandsnaam die het bestand heeft op de server.
        /// </summary>
        public string Bestandslocatie
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
        /// Een eventuele opmerking die bij het bestand vermeld is.
        /// </summary>
        public string Opmerking
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
                    this.likes = this.persoondb.GetLikes(this);

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
                    this.dislikes = this.persoondb.GetDislikes(this);

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
                    this.reports = this.persoondb.GetReports(this);

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
                    List<Reactie> reacties = this.reactiedb.GetReactiesBijBestand(this);
                    Dictionary<int, Persoon> personen = this.persoondb.GetPersonenBijNummers(reacties.Select(r => r.PersoonNummer).ToList<int>());

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
                    return this.map = this.mapdb.GetMapBijNummer(this.MapNummer);
                return null;
            }
            set
            {
                if (this.MapNummer == value.Nummer)
                    this.map = value;
            }
        }

        /// <summary>
        /// De uploaddatum van het bestand.
        /// </summary>
        public DateTime UploadDatum
        {
            get;
            private set;
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
        public Bestand(string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer)
        {
            this.Bestandsnaam = bestandsnaam;
            this.Bestandslocatie = bestandslocatie;
            this.Grootte = grootte;
            this.Opmerking = opmerking;
            this.UploadDatum = uploaddatum;
            this.geuploaddoor = geuploaddoor;
            this.MapNummer = mapnummer;
            
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
        public Bestand(int nummer, string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer)
            : this(bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Nummer = nummer;
        }

        /// <summary>
        /// Het toevoegen van een Like aan het bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddLike(Persoon persoon)
        {
            this.bestanddb.AddLike(this, persoon);

            if(this.likes != null)
                this.likes.Add(persoon);

            if (this.dislikes != null && this.dislikes.Contains(persoon))
                this.dislikes.Remove(persoon);
        }

        /// <summary>
        /// Het toevoegen van een dislike aan het bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddDislike(Persoon persoon)
        {
            this.bestanddb.AddDislike(this, persoon);

            if (this.dislikes != null)
                this.dislikes.Add(persoon);

            if (this.likes != null && this.likes.Contains(persoon))
                this.likes.Remove(persoon);
        }

        /// <summary>
        /// Het toevoegen van een report aan een bestand.
        /// </summary>
        /// <param name="persoon"></param>
        public void AddReport(Persoon persoon)
        {
            this.bestanddb.AddReport(this, persoon);

            if (this.reports != null)
                this.reports.Add(persoon);
        }

        /// <summary>
        /// Het toevoegen van een reactie aan een bestand.
        /// </summary>
        /// <param name="reactie"></param>
        public void AddReactie(Reactie reactie)
        {
            reactie.Nummer = this.reactiedb.AddReactie(this, reactie);

            this.reacties.Add(reactie);
        }

        /// <summary>
        /// Het uploaden van een bestand.
        /// </summary>
        /// <param name="bestandslocatie"></param>
        /// <returns>Geeft terug of het uploaden wel of niet is gelukt.</returns>
        public bool Uploaden(string bestandslocatie)
        {
            this.Bestandslocatie = this.UploadDatum.ToFileTime() + (new FileInfo(bestandslocatie)).Extension;

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
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.trink.nl/" + this.Bestandslocatie);
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

    class Geluidsfragment : Bestand
    {
        /// <summary>
        /// De artiest die het geluidsfragment heeft gemaakt.
        /// </summary>
        public string Artiest
        {
            get;
            set;
        }

        /// <summary>
        /// De afspeelduur van het geluidsfragment
        /// </summary>
        public int Speelduur
        {
            get;
            set;
        }

        /// <summary>
        /// Een geluidsfragment aanmaken, waarvan het nummer nog niet bekend is => geluidsfragment staat nog niet in database.
        /// </summary>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="artiest"></param>
        /// <param name="speelduur"></param>
        public Geluidsfragment(string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, string artiest, int speelduur)
            : base(bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Artiest = artiest;
            this.Speelduur = speelduur;
        }

        /// <summary>
        /// Het aanmaken van een geluidsfragment waarvan het nummer al bekend is => geluidsfragment staat al in database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="artiest"></param>
        /// <param name="speelduur"></param>
        public Geluidsfragment(int nummer, string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, string artiest, int speelduur)
            : base(nummer, bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Artiest = artiest;
            this.Speelduur = speelduur;
        }
    }
    class Boek : Bestand
    {
        /// <summary>
        /// Het aantal pagina's van een boek.
        /// </summary>
        public int AantalPaginas
        {
            get;
            set;
        }

        /// <summary>
        /// De schrijver van het boek.
        /// </summary>
        public string Schrijver
        {
            get;
            set;
        }

        /// <summary>
        /// De taal waarin het boek is geschreven.
        /// </summary>
        public string Taal
        {
            get;
            set;
        }

        /// <summary>
        /// Het genre waar het boek over gaat.
        /// </summary>
        public string Genre
        {
            get;
            set;
        }

        /// <summary>
        /// Een boek maken, waarvan het nummer nog niet bekend is => het boek staat nog niet in de database.
        /// </summary>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="aantalpaginas"></param>
        /// <param name="schrijver"></param>
        /// <param name="taal"></param>
        /// <param name="genre"></param>
        public Boek(string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, int aantalpaginas, string schrijver, string taal, string genre)
            : base(bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.AantalPaginas = aantalpaginas;
            this.Schrijver = schrijver;
            this.Taal = taal;
            this.Genre = genre;
        }

        /// <summary>
        /// Een boek maken, waarvan het nummer al bekend is => het boek staat al in de database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="aantalpaginas"></param>
        /// <param name="schrijver"></param>
        /// <param name="taal"></param>
        /// <param name="genre"></param>
        public Boek(int nummer, string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, int aantalpaginas, string schrijver, string taal, string genre)
            : base(nummer, bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.AantalPaginas = aantalpaginas;
            this.Schrijver = schrijver;
            this.Taal = taal;
            this.Genre = genre;
        }
    }
    class Afbeelding : Bestand
    {
        /// <summary>
        /// De afmetingen van de afmeelding.
        /// </summary>
        public string Afmeting
        {
            get;
            set;
        }

        /// <summary>
        /// Het aanmaken van een afbeelding waarvan het nummer nog niet bekend is => de afbeelding staat nog niet in de database.
        /// </summary>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="afmeting"></param>
        public Afbeelding(string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, string afmeting)
            : base(bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Afmeting = afmeting;
        }

        /// <summary>
        /// Het aanmaken van een afbeelding waarvan het nummer al bekend is. => de afbeelding staat al in de database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="afmeting"></param>
        public Afbeelding(int nummer, string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, string afmeting)
            : base(nummer, bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Afmeting = afmeting;
        }
    }
    class Film : Bestand
    {
        /// <summary>
        /// De maker van de film.
        /// </summary>
        public string Maker
        {
            get;
            set;
        }

        /// <summary>
        /// De duur van de film
        /// </summary>
        public int Duur
        {
            get;
            set;
        }

        /// <summary>
        /// Een film aanmaken waarvan het nummer nog niet bekend is => de film staat nog niet in de database.
        /// </summary>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="maker"></param>
        /// <param name="duur"></param>
        public Film(string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, string maker, int duur)
            : base(bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Maker = maker;
            this.Duur = duur;
        }

        /// <summary>
        /// Het aanmaken van een film waar het nummer al van beschikbaar is => de film staat al in de database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="bestandsnaam"></param>
        /// <param name="bestandslocatie"></param>
        /// <param name="grootte"></param>
        /// <param name="opmerking"></param>
        /// <param name="uploaddatum"></param>
        /// <param name="geuploaddoor"></param>
        /// <param name="mapnummer"></param>
        /// <param name="maker"></param>
        /// <param name="duur"></param>
        public Film(int nummer, string bestandsnaam, string bestandslocatie, int grootte, string opmerking, DateTime uploaddatum, int geuploaddoor, int mapnummer, string maker, int duur)
            : base(nummer, bestandsnaam, bestandslocatie, grootte, opmerking, uploaddatum, geuploaddoor, mapnummer)
        {
            this.Maker = maker;
            this.Duur = duur;
        }
    }
}
