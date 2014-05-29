using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class MateriaalCategorie
    {
        public string Naam
        {
            get;
            private set;
        }

        public List<Materiaal> Materialen
        {
            get
            {
                return Materiaal.GetMaterialenBijCategorie(this);
            }
        }

        public MateriaalCategorie(string naam)
        {
            this.Naam = naam;
        }


    }
}