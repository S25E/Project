﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME.model
{
    public class MateriaalBeheer
    {
        public static void AddMateriaal(Materiaal materiaal)
        {
            Materiaal.AddMateriaal(materiaal);
        }
    }
}