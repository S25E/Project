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

        // MOET PERSOON GEEN RESERVERING ZIJN...
        public static void LeenUit(string Barcode, int reserveringnummer, int aantal)
        {
            MateriaalBeheer.Leenuit(Barcode, reserveringnummer, aantal);
        }
        public static void Brengterug(Materiaal materiaal, Reservering reservering, int aantal)
        {
            MateriaalBeheer.BrengTerug(materiaal, reservering, aantal);
        }
    }
}