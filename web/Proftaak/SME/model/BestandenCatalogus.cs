﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME
{
    public class BestandenCatalogus
    {
        /// <summary>
        /// Het ophalen van alle mappen. In deze methode wordt op een slimme manier alle mappen en bestanden opgehaald en vervolgens gekoppeld.
        /// </summary>
        public static List<Map> Mappen
        {
            get
            {
                // Eerst mappen en ALLE bestanden ophalen. Dan bestanden koppelen met map.
                Dictionary<int, Map> mappen = Map.GetMappen();
                Dictionary<int, List<Bestand>> bestanden = Bestand.GetBestandenBijMap();

                foreach (KeyValuePair<int, Map> row in mappen)
                {
                    if (bestanden.ContainsKey(row.Value.Nummer))
                        row.Value.Bestanden = bestanden[row.Value.Nummer];
                    else
                        row.Value.Bestanden = new List<Bestand>();

                    if(row.Value.ParentMapNummer != 0 && mappen.ContainsKey(row.Value.ParentMapNummer))
                        row.Value.ParentMap = mappen[row.Value.ParentMapNummer];
                }

                return mappen.Values.ToList();
            }
        }

        /// <summary>
        /// Het toevoegen van een map.
        /// </summary>
        /// <param name="map"></param>
        public static void AddMap(Map map)
        {
            map.Nummer = Map.AddMap(map);
        }
    }
}
