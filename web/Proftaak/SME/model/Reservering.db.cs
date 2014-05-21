using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SME
{
    public partial class Reservering
    {
        public static List<Reservering> GetReserveringen(){

            List<Reservering> lijst = new List<Reservering>();

            return lijst;

        }

        public static int AddReservering(Reservering reservering)
        {
            int insertedId =  Database.GetSequence("RESERVERING");
            Database.Execute("INSERT INTO RESERVERING (RESERVERINGSNUMMER, DATUM) VALUES (@nummer, TO_DATE(@datum, 'SYYYY-MM-DD HH24:MI:SS'))", new Dictionary<string, object>()
            {
                {"@nummer", insertedId},
                {"@datum",  reservering.Datum.ToString("yyyy-MM-dd HH:mm:ss")}
            });
            return insertedId;
        }

        // NOG TE MAKEN
        public static void ZetOpBetaald(Reservering reservering)
        {
            
        }

        // NOG TE MAKEN
        public static void DeleteReservering(Reservering reservering)
        {
            // HIER RESERVERING VERWIJDEREN IN DATABASE
            Persoon.DeletePersoon(reservering.Hoofdboeker);
            foreach (Bijboeker bijboeker in reservering.Bijboekers)
            {
                Persoon.DeletePersoon(bijboeker);
            }
        }
    }
}