using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSharing
{
    class PersoonBeheer
    {
        /// <summary>
        /// De database connectie.
        /// </summary>
        private PersoonDB persoondb = new PersoonDB();

        /// <summary>
        /// Het ophalen van een persoon aan de hand van het nummer van de persoon. 
        /// </summary>
        /// <param name="nummer"></param>
        /// <returns>De persoon</returns>
        public Persoon GetPersoonBijNummer(int nummer)
        {
            return this.persoondb.GetPersoonBijNummer(nummer);
        }
    }
}
