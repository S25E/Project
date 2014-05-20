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


namespace ProjectP3Reserveringsapplicatie
{
    public partial class Form3 : Form
    {
        Form2 overzicht;
        ReserveringBeheer ReserveringBeheer = new ReserveringBeheer();
        Hoofdboeker hb;
        DB db = new DB();
        int Reserveringsnummer;
        Reservering r;
        string betaald;
        string persoonnummer;
        public Form3(int nummer)
        {
            InitializeComponent();
            Reserveringsnummer = nummer;

            r = new Reservering(nummer); //nieuw
            
            HaalBijboekersOp();
            HaalHoofdboekerOp();
            GetCategorie();
            
        }

        /// <summary>
        /// Het form met het overzicht van de reserveringen wordt geopend, en dit form gesloten 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOverzicht_Click(object sender, EventArgs e)
        {
            overzicht = new Form2();
            overzicht.Show();
            overzicht.FormClosed += new FormClosedEventHandler(overzicht_FormClosed);
            this.Hide();
        }

        /// <summary>
        /// Als de naam van de bijboeker in de dropdownbox wordt veranderd, dan worden de gegevens over deze persoon geupdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBBNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Bijboeker b in r.Bijboekers)
            {
                if (cbBBNaam.Text == b.Naam)
                {
                    textBoxBBNaam.Text = b.Naam;
                    textBoxBBTelefoonnummer.Text = b.Telefoonnummer;
                    textBoxBBWachtwoord.Text = b.Wachtwoord;
                }
            }
        }

        /// <summary>
        /// De gegevens over de bijboeker worden geupdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBBWijzig_Click(object sender, EventArgs e)
        {
            foreach (Bijboeker b in r.Bijboekers)
            {
                if (cbBBNaam.Text == b.Naam)
                {
                    b.Telefoonnummer = textBoxBBTelefoonnummer.Text;
                    b.Wachtwoord = textBoxBBWachtwoord.Text;
                    b.Naam = textBoxBBNaam.Text;
                    db.InsertData("UPDATE PERSOON SET wachtwoord = '" + b.Wachtwoord + "', telefoonnummer = '" + b.Telefoonnummer + "', naam = '" + b.Naam + "' WHERE PERSOON_NUMMER ='" + b.Nummer.ToString() + "'");
                }
            }
            MessageBox.Show("Wijziging voltooid");
            HaalBijboekersOp();
            
        }

        /// <summary>
        /// Haal alle namen op van de bijboekers en zet deze in de comobox
        /// </summary>
        private void HaalBijboekersOp()
        {
            cbBBNaam.Items.Clear();
            cbMatNaam.Items.Clear();
            DataTable dt = db.getData("SELECT PE.PERSOON_NUMMER as nummer, PE.NAAM as naam, PE.WACHTWOORD as wachtwoord, PE.TELEFOONNUMMER as telefoonnummer FROM BIJBOEKER BB, PERSOON PE WHERE BB.PERSOON_NUMMER = PE.PERSOON_NUMMER AND BB.RESERVERING_NUMMER  = '" + Reserveringsnummer + "' ORDER BY NAAM");
            int nummer;
            string naam;
            string wachtwoord;
            int telefoonnummer;
            foreach (DataRow rdr in dt.Rows)
            {
                nummer = Convert.ToInt32(rdr["nummer"]);
                naam = rdr["naam"].ToString();
                wachtwoord = rdr["wachtwoord"].ToString();
                telefoonnummer = Convert.ToInt32(rdr["telefoonnummer"]);
                Bijboeker b = new Bijboeker(nummer, naam, telefoonnummer.ToString(), wachtwoord);
                r.Bijboekers.Add(b);
                r.AddPersoon(b, false);
                cbMatNaam.Items.Add(naam);
                cbBBNaam.Items.Add(naam);
            }
            cbBBNaam.SelectedIndex = 0;
        }

        /// <summary>
        /// Haalt alle gegevens over de hoofdboeker op en zet deze op het form
        /// </summary>
        private void HaalHoofdboekerOp()
        {
            DataTable dt = db.getData("SELECT HB.PERSOON_NUMMER as persoonnummer, PE.NAAM as naam, HB.ADRES as adres, HB.POSTCODE as postcode, HB.WOONPLAATS as woonplaats, HB.EMAIL as email, PE.WACHTWOORD as wachtwoord, HB.REKENINGNUMMER as rekeningnummer, PE.TELEFOONNUMMER as telefoonnummer, R.BETAALD as betaald FROM PERSOON PE, HOOFDBOEKER HB, RESERVERING R WHERE PE.PERSOON_NUMMER = HB.PERSOON_NUMMER AND HB.RESERVERING_NUMMER = R.RESERVERING_NUMMER AND R.RESERVERING_NUMMER ='" + Reserveringsnummer.ToString() + "'");
            DataRow rdr = dt.Rows[0];
            int HBPersoonnummer = Convert.ToInt32(rdr["persoonnummer"]);
            string naam = rdr["naam"].ToString();
            string adres = rdr["adres"].ToString();
            string postcode = rdr["postcode"].ToString();
            string woonplaats = rdr["woonplaats"].ToString();
            string email = rdr["email"].ToString();
            string wachtwoord = rdr["wachtwoord"].ToString();
            string rekeningnummer = rdr["rekeningnummer"].ToString();
            int telefoonnummer = Convert.ToInt32(rdr["telefoonnummer"]);
            betaald = rdr["betaald"].ToString();

            hb = new Hoofdboeker(HBPersoonnummer, naam, telefoonnummer.ToString(), wachtwoord, adres, postcode, woonplaats, email, rekeningnummer);
            if (betaald == "Y")
            {
                cbBetaald.Text = "Ja";
            }
            else
            {
                cbBetaald.Text = "Nee";
            }

            textBoxHBNaam.Text = hb.Naam;
            textBoxHBAdres.Text = hb.Adres;
            textBoxHBPostcode.Text = hb.Postcode;
            textBoxHBWoonplaats.Text = hb.Woonplaats;
            textBoxHBEmail.Text = hb.Email;
            textBoxHBWachtwoord.Text = hb.Wachtwoord;
            textBoxHBRekeningsnummer.Text = hb.Rekeningnummer;
            textBoxHBTelefoonnummer.Text = hb.Telefoonnummer;
            cbMatNaam.Items.Insert(0, hb.Naam);
            cbMatNaam.SelectedIndex = 0;
        }

        /// <summary>
        /// Update de gegevens van de hoofdboeker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHBWijzig_Click(object sender, EventArgs e)
        {
            try
            {
                hb.Naam = textBoxHBNaam.Text;
                hb.Adres = textBoxHBAdres.Text;
                hb.Postcode = textBoxHBPostcode.Text;
                hb.Woonplaats = textBoxHBWoonplaats.Text;
                hb.Email = textBoxHBEmail.Text;
                hb.Wachtwoord = textBoxHBWachtwoord.Text;
                hb.Rekeningnummer = textBoxHBRekeningsnummer.Text;
                hb.Telefoonnummer = textBoxHBTelefoonnummer.Text;

                string betaald;
                if (cbBetaald.Text == "JA")
                {
                    betaald = "Y";
                }
                else
                {
                    betaald = "N";
                }
                db.InsertData("UPDATE PERSOON SET naam = '" + hb.Naam + "', telefoonnummer ='" + Convert.ToInt32(hb.Telefoonnummer) + "', wachtwoord = '" + hb.Wachtwoord + "' WHERE PERSOON_NUMMER ='" + hb.Nummer.ToString() + "'");
                db.InsertData("UPDATE RESERVERING SET BETAALD ='" + betaald + "' WHERE RESERVERING_NUMMER ='" + Reserveringsnummer + "'");
                HaalHoofdboekerOp();
                MessageBox.Show("Wijziging voltooid");

                
            }
            catch (FormatException)
            {
                MessageBox.Show("Niet geupdate, voer alleen getallen in voor het telefoonnummer");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Voer een telefoonnummer in, tot max 10 getallen");
            }
        }

        /// <summary>
        /// Er wordt een bijboeker verwijdert, en de campingplaats wordt weer vrijgegevens als het nodig is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBBVerwijder_Click(object sender, EventArgs e)
        {
            string persoonnummer = VindPersoonnummer(cbBBNaam.Text);
            string reserveringnummer = db.SelectData("SELECT RESERVERING_NUMMER FROM BIJBOEKER WHERE PERSOON_NUMMER = '" + persoonnummer + "'").ToString();
            db.SelectData("DELETE FROM REACTIEREPORT WHERE PERSOON_NUMMER = '" + persoonnummer + "'");
            db.SelectData("DELETE FROM LENING WHERE PERSOON_NUMMER = '" + persoonnummer + "'");
            db.SelectData("DELETE FROM BIJBOEKER WHERE PERSOON_NUMMER ='" + persoonnummer + "'");
            db.SelectData("DELETE FROM PERSOON WHERE PERSOON_NUMMER = '" + persoonnummer + "'");

           double aantalPersonen = Convert.ToDouble(db.SelectData("SELECT COUNT(PERSOON_NUMMER) AS AANTAL FROM BIJBOEKER WHERE RESERVERING_NUMMER ='" + reserveringnummer + "'")) + 1;
            int aantalPlaatsen = Convert.ToInt32(db.SelectData("SELECT COUNT(PLAATS_NUMMER) AS AANTAL FROM CAMPINGPLAATS WHERE RESERVERING_NUMMER ='" + reserveringnummer + "'"));
            if (Math.Ceiling(aantalPersonen / 5) < aantalPlaatsen)
            {
                int maxNummer = Convert.ToInt32(db.SelectData("SELECT MAX(PLAATS_NUMMER) AS NUMMER FROM CAMPINGPLAATS WHERE RESERVERING_NUMMER ='" + reserveringnummer + "'"));
                db.SelectData("UPDATE CAMPINGPLAATS SET RESERVERING_NUMMER = 0 WHERE PLAATS_NUMMER = '" + maxNummer + "'");
            }
           HaalBijboekersOp();
        }

        /// <summary>
        /// Zoekt het persoonnummer in de database op basis van het persoonnummer
        /// </summary>
        /// <param name="naam">De naam van de persoon waarvan het nummer wordt teruggegeven</param>
        /// <returns>Het persoonnummer</returns>
        private string VindPersoonnummer(string naam)
        {
            string persoonnummer = db.SelectData("SELECT PERSOON_NUMMER FROM PERSOON WHERE NAAM = '" + naam + "'").ToString();
            return persoonnummer;
        }

        /// <summary>
        /// Als de waarde (naam van een persoon) van de dropdown list wordt veranderd dan worden de bijbehorende gereserveerde producten uit de database opgehaald
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMatNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxMat.Items.Clear();
            persoonnummer = VindPersoonnummer(cbMatNaam.Text);
            string listboxProduct;

            string barcode;
            string categorie;
            string naam;
            DataTable dt = db.getData(("SELECT L.BARCODE, NAAM, CATEGORIE FROM LENING L, ARTIKEL A WHERE L.BARCODE = A.BARCODE AND PERSOON_NUMMER = '" + persoonnummer + "'"));
            foreach (DataRow rdr in dt.Rows)
            {
                barcode = rdr["barcode"].ToString();
                categorie = rdr["categorie"].ToString();
                naam = rdr["naam"].ToString();
                listboxProduct = barcode + ", " + categorie + ", " + naam;
                listBoxMat.Items.Add(listboxProduct);
            }
        }


        /// <summary>
        /// Als de categorie wordt veranderd, dan wordt de lijst met producten van de categorie opgehaald uit de database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMatCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMatProduct.Items.Clear();
            string query = "SELECT NAAM FROM ARTIKEL WHERE CATEGORIE ='" + cbMatCategorie.Text + "'";
            foreach (string s in ReserveringBeheer.GetProducten(query, "naam"))
            {
                cbMatProduct.Items.Add(s);
            }
            cbMatProduct.SelectedIndex = 0;
        }

        /// <summary>
        /// Alle categorien die uit de database worden gehaald(via reserveringbeheer GetProductCategorie), worden toegevoegd aan de dropdown list
        /// </summary>
        private void GetCategorie()
        {
            cbMatCategorie.Items.Clear();
            foreach (string s in ReserveringBeheer.GetProductCategorie())
            {
                cbMatCategorie.Items.Add(s);
            }
            cbMatCategorie.SelectedIndex = 0;
        }

        /// <summary>
        /// Als de opgegeven persoon het product nog niet heeft gereserveerd dan wordt het product gereserveerd door de persoon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMatVoegToe_Click_1(object sender, EventArgs e)
        {
            string persoonnummer = db.SelectData("SELECT PERSOON_NUMMER FROM PERSOON WHERE NAAM ='" + cbMatNaam.Text + "'").ToString();
            string barcode = db.SelectData("SELECT BARCODE FROM ARTIKEL WHERE NAAM = '" + cbMatProduct.Text + "'").ToString();
            string lbMateriaalText = barcode + ", " + cbMatProduct.Text;
            bool goed = false; ;
            if (listBoxMat.Items.Count > 0)
            {
                for (int i = 0; i < listBoxMat.Items.Count; i++)
                {
                    if (listBoxMat.Items[i].Equals(lbMateriaalText))
                    {
                        MessageBox.Show("Deze persoon heeft dit product al gereserveerd");
                    }
                    else
                    {
                        goed = true;
                    }
                }
            }
            else
            {
                goed = true;
            }
            if (goed)
            {
                db.InsertData("INSERT INTO LENING(PERSOON_NUMMER, BARCODE) VALUES('" + persoonnummer + "', '" + barcode + "')");
                listBoxMat.Items.Add(lbMateriaalText);
            }
        }

        /// <summary>
        /// Het door de persoon gereserveerde product wordt verwijdert van de lening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMatVerwijder_Click(object sender, EventArgs e)
        {
            string artikelnaam = cbMatProduct.Text;
            if (listBoxMat.SelectedIndex != -1)
            {
                string regel = listBoxMat.SelectedItem.ToString();

                int eind = Convert.ToInt32(regel.IndexOf(","));
                string barcode = regel.Substring(0, eind);
                string persoonnummer = db.SelectData("SELECT PERSOON_NUMMER FROM PERSOON WHERE NAAM ='" + cbMatNaam.Text + "'").ToString();
                string barcode2 = db.SelectData("SELECT L.BARCODE FROM ARTIKEL A, LENING L WHERE A.BARCODE = L.BARCODE AND L.PERSOON_NUMMER = '" + persoonnummer + "'").ToString();
                if (barcode == barcode2)
                {
                    db.SelectData("DELETE FROM LENING WHERE BARCODE = '" + barcode + "' AND PERSOON_NUMMER ='" + persoonnummer + "'");
                    listBoxMat.Items.Remove(regel);
                    listBoxMat.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show(cbMatNaam.Text + " heeft geen product gereserveerd met de naam: " + artikelnaam);
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een product uit de lijst om te verwijderen");
            }
        }

        /// <summary>
        /// Het form wordt gelsoten i.p.v. gehide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void overzicht_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
