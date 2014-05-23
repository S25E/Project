﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class MateriaalBeheer
    {
        public static void AddMateriaal(Materiaal materiaal)
        {
            Materiaal.AddMateriaal(materiaal);
        }
        public static void LeenUit(Materiaal materiaal, Persoon persoon)
        {
            MateriaalBeheer.Leenuit(materiaal, persoon);
        }
        public static void Brengterug(Materiaal materiaal, Persoon persoon, int aantal)
        {
            MateriaalBeheer.BrengTerug(materiaal, persoon, aantal);
        }
    }
}