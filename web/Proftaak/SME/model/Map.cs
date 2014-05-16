using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public partial class Map
    {
        /// <summary>
        /// De connecties met de database.
        /// </summary>
        private MapDB mapdb = new MapDB();
        private BestandDB bestanddb = new BestandDB();

        /// <summary>
        /// Het nummer van de map.
        /// </summary>
        public int Nummer
        {
            get;
            set;
        }

        /// <summary>
        /// De naam van de map.
        /// </summary>
        public string Naam
        {
            get;
            private set;
        }

        /// <summary>
        /// Het nummer van de map waar de map onderdeel van is. 0 indien de map zich op het hoogste niveau bevindt.
        /// </summary>
        public int ParentMapNummer
        {
            get;
            private set;
        }

        /// <summary>
        /// De map waar de map onderdeel van is. Geef null terug indien de map zich op het hoogste niveau bevindt.
        /// </summary>
        private Map parentMap;
        public Map ParentMap
        {
            get {
                if(parentMap != null)
                    return this.parentMap;
                else if(this.ParentMapNummer != 0)
                    this.parentMap = this.mapdb.GetMapBijNummer(this.ParentMapNummer);
                return null;
            }
            set {
                if (this.ParentMapNummer == value.Nummer)
                    this.parentMap = value;
            }
        }

        /// <summary>
        /// De bestanden die zich in de map bevinden.
        /// </summary>
        private List<Bestand> bestanden;
        public List<Bestand> Bestanden
        {
            get {
                if(this.bestanden != null)
                    return this.bestanden;

                return this.bestanddb.GetBestandenBijMap(this);
            }
            set {
                this.bestanden = value;   
            }
        }

        /// <summary>
        /// Het aanmaken van een map waarvan het nummer nog niet bekend is => de map staat nog niet in de database.
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="parentmapnummer"></param>
        public Map(string naam, int parentmapnummer)
        {
            this.Naam = naam;
            this.ParentMapNummer = parentmapnummer;
        }

        /// <summary>
        /// Het aanmaken van een map waarvan het nummer al bekend is => de map staat al in de database.
        /// </summary>
        /// <param name="nummer"></param>
        /// <param name="naam"></param>
        /// <param name="parentmapnummer"></param>
        public Map(int nummer, string naam, int parentmapnummer)
            : this(naam, parentmapnummer)
        {
            this.Nummer = nummer;
        }

        /// <summary>
        /// Het toevoegen van een bestand.
        /// </summary>
        /// <param name="bestand"></param>
        public void AddBestand(Bestand bestand)
        {
            bestand.Nummer = this.bestanddb.AddBestand(bestand);
            this.bestanden = null;
        }

        /// <summary>
        /// Het verwijderen van een bestand.
        /// </summary>
        /// <param name="bestand"></param>
        public void DeleteBestand(Bestand bestand)
        {
            this.bestanddb.DeleteBestand(bestand);
        }

        /// <summary>
        /// Het weergeven van een map als string.
        /// </summary>
        /// <returns>De map als string.</returns>
        public override string ToString()
        {
            List<string> mapnamen = new List<string>();
            mapnamen.Add(this.Naam);

            Map currentMap = this;
            while (currentMap.ParentMapNummer != 0)
            {
                currentMap = currentMap.ParentMap;
                mapnamen.Add(currentMap.Naam);
            }

            return "/" + string.Join("/", mapnamen.Reverse<string>());
        }
    }
}
