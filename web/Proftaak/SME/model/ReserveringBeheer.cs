using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace SME
{
    /// <summary>
    /// Beheert de reserveringen zoals toevoegen, verwijderen etc.
    /// </summary>
    /// <returns></returns>
    class ReserveringBeheer
    {
        public List<Reservering> Reserveringen;
        public List<Kampeerplaats> Kampeerplaatsen;
        private DB db = new DB();

        public ReserveringBeheer()
        {
            Kampeerplaatsen = new List<Kampeerplaats>();
            Reserveringen = new List<Reservering>();
        }

        /// <summary>
        /// Voegt een reservering toe aan de database
        /// </summary>
        /// <param name="Hoofdboeker">De hoofdboeker</param>
        /// <param name="Bijboekers">De lijst met bijboekers</param>
        /// <param name="kampeerplaatsen">De lijst met kampeerplaatsen</param>
        /// <param name="nummer">Het reserveringsnummer</param>
        /// <param name="HoofdboekerPersoon"></param>
        /// <param name="Materialen"></param>
        public void AddReservering(Hoofdboeker Hoofdboeker, List<Bijboeker> Bijboekers, List<Kampeerplaats> kampeerplaatsen, int nummer, List<Materiaal> Materialen)
        {
            Reservering Reservering = new Reservering(Hoofdboeker, Bijboekers, kampeerplaatsen, nummer, false, (Bijboekers.Count + 1), Materialen);
            Reserveringen.Add(Reservering);

            //Reservering toevoegen, altijd 1 reservering!
            db.InsertData("INSERT INTO RESERVERING VALUES ('" + nummer + "', '" + "N')");

            //Persoon(hoofdboeker) toevoegen, altijd 1 hoofdboeker!
            db.InsertData("INSERT INTO PERSOON VALUES('" + Hoofdboeker.Nummer + "', '" + Hoofdboeker.Naam + "', 'hoofdboeker', '" + Hoofdboeker.Telefoonnummer + "', '" + Hoofdboeker.Wachtwoord + "', 'N')");

            //Personen(bijboeker) toevoegen, kunnen meerdere zijn!
            foreach (Persoon p in Bijboekers)
            {
                db.InsertData("INSERT INTO PERSOON VALUES('" + p.Nummer + "', '" + p.Naam + "', 'bijboeker', '" + p.Telefoonnummer + "', '" + p.Wachtwoord + "', 'N')");
            }

            //Hoofdboeker van de reservering toevoegen, altijd 1!
            db.InsertData("INSERT INTO HOOFDBOEKER VALUES ('" + Reservering.Hoofdboeker.Nummer + "', '" + Reservering.Reserveringsnummer + "', '" + Reservering.Hoofdboeker.Email + "', '" + Reservering.Hoofdboeker.Rekeningnummer + "', '" + Reservering.Hoofdboeker.Adres + "', '" + Reservering.Hoofdboeker.Woonplaats + "', '" + Reservering.Hoofdboeker.Postcode +"')");

            //Bijboekers toevoegen kunnen meerdere zijn!
            foreach (Bijboeker b in Reservering.Bijboekers)
            {
                db.InsertData("INSERT INTO BIJBOEKER VALUES ('" + b.Nummer + "', '" + Reservering.Reserveringsnummer + "')");
            }

            //kamping plaats update ipv insert. reserveringnummer staat default op 0
            foreach(Kampeerplaats k in Reservering.Kampeerplaatsen)
            {
                db.InsertData("UPDATE CAMPINGPLAATS SET RESERVERING_NUMMER = '" + nummer + "' WHERE PLAATS_NUMMER = '" + k.Nummer + "'");
            }

            //materialen worden toegevoegd op basis van het persoonnummer (voor hoofdboeker & bijboeker) en barcode
            if (Materialen.Count > 0)
            {
                foreach (Materiaal m in Materialen)
                {
                    db.InsertData(" INSERT INTO LENING(PERSOON_NUMMER, BARCODE) VALUES('" + m.Persoonnummer.ToString() + "', '" + m.Barcode + "')");
                }
            }
        }


        /// <summary>
        /// Zoekt in de database voor het eerst volgend vrije reserveringsnummer
        /// </summary>
        /// <returns>geeft het eerst volgend vrije reserveringsnummer terug van het type INT</returns>
        public int GetVrijReserveringsnummer()
        {
            int nummer = Convert.ToInt32(db.SelectData("SELECT MAX(RESERVERING_NUMMER) FROM RESERVERING"));
            if (DBNull.Value.Equals(nummer))
            {
                nummer = 1;
            }
            else
            {
                nummer += 1;
            }
            return nummer;

        }

        
        /// <summary>
        /// geeft het eerst volgend vrije persoonsnummer terug van het type INT
        /// </summary>
        /// <returns>geeft het eerst volgend vrije persoonsnummer terug van het type INT</returns>
        public int GetVrijPersoonsnummer()
        {
            int maxnummer = Convert.ToInt32(db.SelectData("SELECT MAX(persoon_nummer) FROM PERSOON"));
            if (DBNull.Value.Equals(maxnummer))
            {
                maxnummer = 1;
            }
            else
            {
                maxnummer += 1;
            }
            return maxnummer;
        }

        /// <summary>
        /// Zoekt in de database voor een kampeerplaats
        /// </summary>
        /// <param name="nummer">Het nummer van de kampeerplaats</param>
        /// <returns>Geeft een kampeerplaats terug met het plaatsnummer dat ingevoerd is</returns>
        public Kampeerplaats FindPlaats(int nummer)
        {
            foreach(Kampeerplaats k in Kampeerplaatsen)
            {
                if(k.Nummer == nummer)
                {
                    return k;
                }
            }
            return null;
        }
        /// <summary>
        /// Verwijdert een reservering
        /// </summary>
        /// <param name="Reserveringsnummer">Het reserveringsnummer van de reservering die verwijderd wordt</param>
        public void DeleteReservering(int Reserveringsnummer)
        {
            int HBpersoonnummer = Convert.ToInt32(db.SelectData("SELECT HB.PERSOON_NUMMER FROM HOOFDBOEKER HB, PERSOON PE WHERE HB.PERSOON_NUMMER = PE.PERSOON_NUMMER AND HB.RESERVERING_NUMMER ='" + Reserveringsnummer + "'"));
            DataTable dt = db.getData("SELECT BB.PERSOON_NUMMER as persoon_nummer FROM BIJBOEKER BB, PERSOON PE WHERE BB.PERSOON_NUMMER = PE.PERSOON_NUMMER AND BB.RESERVERING_NUMMER ='" + Reserveringsnummer + "'");
            List<int> psns = new List<int>();
            foreach (DataRow rdr in dt.Rows)
            {
                psns.Add(Convert.ToInt32(rdr["persoon_nummer"]));
            }

            //Verwijdert records uit de volgende tabelen
            db.SelectData("DELETE FROM REACTIEREPORT WHERE PERSOON_NUMMER = '" + HBpersoonnummer + "'");
            db.SelectData("DELETE FROM BIJBOEKER WHERE RESERVERING_NUMMER = '" + Reserveringsnummer + "'");
            db.SelectData("DELETE FROM HOOFDBOEKER WHERE RESERVERING_NUMMER = '" + Reserveringsnummer + "'");
            db.SelectData("DELETE FROM RESERVERING WHERE RESERVERING_NUMMER = '" + Reserveringsnummer + "'");
            db.SelectData("DELETE FROM LENING WHERE PERSOON_NUMMER = '" + HBpersoonnummer + "'");
            db.SelectData("DELETE FROM PERSOON WHERE PERSOON_NUMMER = '" + HBpersoonnummer + "'");

            foreach (int psn in psns)
            {
                db.SelectData("DELETE FROM REACTIEREPORT WHERE PERSOON_NUMMER = '" + psn + "'");
                db.SelectData("DELETE FROM LENING WHERE PERSOON_NUMMER ='" + psn + "'");
                db.SelectData("DELETE FROM PERSOON WHERE PERSOON_NUMMER = '" + psn + "'");
            }

            db.SelectData("UPDATE CAMPINGPLAATS SET RESERVERING_NUMMER = 0 WHERE RESERVERING_NUMMER ='" + Reserveringsnummer + "'");
        }


        /// <summary>
        /// haalt alle informatie over de kampeerplaatsen op, maakt een instantie aan van kampeerplaats en slaat deze op in de lijst.
        /// </summary>
        /// <returns>de lijst met kampeerplaatsen wordt gereturnd.</returns>
        public List<Kampeerplaats> GetKampeerplaatsen()
        {
            DataTable dt = db.getData("SELECT * FROM CAMPINGPLAATS");
            int Plaatsnummer;
            int Reserveringsnummer;
            string Opmerking;
            int Oppervlakte;
            int x;
            int y;
            foreach (DataRow rdr in dt.Rows)
            {
                Plaatsnummer = Convert.ToInt32(rdr["plaats_nummer"]);
                Reserveringsnummer = Convert.ToInt32(rdr["reservering_nummer"]);
                Opmerking = rdr["opmerking"].ToString();
                Oppervlakte = Convert.ToInt32(rdr["oppervlakte"]);
                x =  Convert.ToInt32(rdr["x"]);
                y =  Convert.ToInt32(rdr["y"]);
                Kampeerplaats k = new Kampeerplaats(Reserveringsnummer, Plaatsnummer, Opmerking, Oppervlakte, x, y);
                Kampeerplaatsen.Add(k);
            }

            return Kampeerplaatsen;
        }

        //public void GetReserveringen(int nummer)
        //{
        //}

        /// <summary>
        /// Haalt alle verschillende categorieen op uit de database
        /// </summary>
        /// <returns>Een lijst met categorienamen</returns>
        public List<string> GetProductCategorie()
        {
            string Categorienaam;
            List<string> Categorienamen = new List<string>();
            DataTable dt = db.getData("SELECT DISTINCT CATEGORIE FROM ARTIKEL ORDER BY CATEGORIE");
            foreach (DataRow rdr in dt.Rows)
            {
                Categorienaam = rdr["categorie"].ToString();
                Categorienamen.Add(Categorienaam);
            }
            return Categorienamen;
        }

        /// <summary>
        /// Haalt de producten op naar aanleiding van de query
        /// </summary>
        /// <param name="query">De query die uitgevoerd moet worden om het gewenste resultaat te krijgen</param>
        /// <param name="kolomnaam">Uit welke kolom moet het resultaat gehaald worden</param>
        /// <returns>Een lijst met productnamen</returns>
        public List<string> GetProducten( string query, string kolomnaam)
        {
            string productnaam;
            List<string> Producten = new List<string>();
            DataTable dt = db.getData(query);
            foreach (DataRow rdr in dt.Rows)
            {
                productnaam = rdr[kolomnaam].ToString();
                Producten.Add(productnaam);
            }
            return Producten;
        }
    }
}
