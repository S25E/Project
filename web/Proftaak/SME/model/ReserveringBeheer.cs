using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SME
{
    /// <summary>
    /// Beheert de reserveringen zoals toevoegen, verwijderen etc.
    /// </summary>
    /// <returns></returns>
    public partial class ReserveringBeheer
    {
        public static List<Reservering> Reserveringen
        {
            get
            {
                return Reservering.GetReserveringen();
            }
        }
        public static List<Kampeerplaats> Kampeerplaatsen
        {
            get {
                return Kampeerplaats.GetKampeerplaatsen();   
            }
        }


        /// <summary>
        /// Voegt een reservering toe
        /// </summary>
        /// <param name="reservering">De reservering zelf</param>
        /// <param name="hoofdboeker">De hoofdboeker</param>
        /// <returns></returns>
        public static Reservering AddReservering(Reservering reservering, Hoofdboeker hoofdboeker)
        {
            Reservering.AddReservering(reservering);
            hoofdboeker.ReserveringNummer = reservering.Nummer;
            Persoon.AddPersoon(hoofdboeker);
            
            return reservering;
        }

        /// <summary>
        /// Zoekt in de database voor een kampeerplaats
        /// </summary>
        /// <param name="nummer">Het nummer van de kampeerplaats</param>
        /// <returns>Geeft een kampeerplaats terug met het plaatsnummer dat ingevoerd is</returns>
        public static Kampeerplaats GetKampeerplaats(int nummer)
        {
            return Kampeerplaats.GetKampeerplaatsBijNummer(nummer);
        }

    }
}
