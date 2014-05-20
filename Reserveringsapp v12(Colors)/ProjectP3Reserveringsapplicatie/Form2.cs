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
    public partial class Form2 : Form
    {
        DB db = new DB();
        ReserveringBeheer ReserveringBeheer = new ReserveringBeheer();
        
        int Reserveringsnummer;
        string HfdNaam;
        int HfdPsn;
        int nummer;

        string Betaald;
        public Form2()
        {
            InitializeComponent();
            this.Text = "Overzicht van de reserveringen";
            Start();

        }

        /// <summary>
        /// Het form om de reservering te wijzigen wordt geopend
        /// ook wordt dit form daarna gesloten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWijzig_Click(object sender, EventArgs e)
        {
            if (nummer != 0)
            {
                Form3 wijzig = new Form3(nummer);
                wijzig.Show();
                wijzig.FormClosed += new FormClosedEventHandler(wijzig_FormClosed);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een reservering in de lijst om aan te passen.");
            }
        }

        /// <summary>
        /// Het form om een reservering toe te voegen wordt geopend
        /// Ook wordt dit form daarna gesloten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlaats_Click(object sender, EventArgs e)
        {
            //ga naar Reservering toevoegen
            Form1 plaats = new Form1();
            plaats.Show();
            plaats.FormClosed += new FormClosedEventHandler(plaats_FormClosed);
            this.Hide();
        }

        /// <summary>
        /// Als er een andere reservering wordt geslecteerd dan worden alle gegevens opnieuw uit de database gehaald en in de textboxes/dropdownboxes gezet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxOverzicht_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxHBNaam.Text = "";
            textBoxHBEmail.Text = "";
            textBoxHBAdres.Text = "";
            textBoxHBPostcode.Text = "";
            textBoxHBWoonplaats.Text = "";
            textBoxHBTel.Text = "";
            textBoxHBReserveringsnummer.Text = "";
            textBoxBBTel.Text = "";
            cbBBNaam.Items.Clear();
            
            //het reserveringsnummer wordt uit de listboxgehaald met substring
            if (listBoxOverzicht.SelectedIndex >= 0)
            {
                string heleString = listBoxOverzicht.SelectedItem.ToString();
                int eind = heleString.IndexOf(",");
                string substring = heleString.Substring(20, eind - 20);
                nummer = Convert.ToInt32(substring);



                //De persoonsgegevens van de hoofdboeker worden uit de database gehaald en toegevoegd aan het form
                DataTable dt = db.getData("SELECT R.RESERVERING_NUMMER as reservering_nummer, PER.NAAM AS naam, HFD.EMAIL as email, HFD.ADRES as adres, PER.TELEFOONNUMMER as telefoonnummer, HFD.POSTCODE as postcode, HFD.WOONPLAATS as woonplaats FROM RESERVERING R, PERSOON PER, HOOFDBOEKER HFD WHERE PER.PERSOON_NUMMER = HFD.PERSOON_NUMMER AND R.RESERVERING_NUMMER = HFD.RESERVERING_NUMMER AND R.RESERVERING_NUMMER = '" + nummer + "'");

                DataRow rdr = dt.Rows[0];
                int Reserveringsnummer = nummer;
                string HfdNaam = rdr["naam"].ToString();
                string Email = rdr["email"].ToString();
                string Adres = rdr["adres"].ToString();
                string Telefoonnummer = rdr["telefoonnummer"].ToString();
                string Postcode = rdr["postcode"].ToString();
                string Woonplaats = rdr["woonplaats"].ToString();

                textBoxHBNaam.Text = HfdNaam.ToString();
                textBoxHBEmail.Text = Email;
                textBoxHBAdres.Text = Adres;
                textBoxHBTel.Text = Telefoonnummer;
                textBoxHBReserveringsnummer.Text = Reserveringsnummer.ToString();
                textBoxHBPostcode.Text = Postcode;
                textBoxHBWoonplaats.Text = Woonplaats;

                //de naam de bijboekers wordt uit de database gehaald en toegevoegd aan het form.
                DataTable dt2 = db.getData("SELECT W.NAAM as naam FROM PERSOON W, BIJBOEKER B WHERE W.PERSOON_NUMMER = B.PERSOON_NUMMER AND B.RESERVERING_NUMMER ='" + nummer + "'");
                foreach (DataRow rdr2 in dt2.Rows)
                {
                    string BBnaam = rdr2["naam"].ToString();
                    cbBBNaam.Items.Add(BBnaam);
                }
                if (cbBBNaam.Items.Count > 0)
                {
                    cbBBNaam.SelectedIndex = 0;
                }
            }
            
        }

        /// <summary>
        /// Het telefoonnummer van de geselecteerde persoon in de dropdown box wordt toegevoegd aan de textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBBNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //het telefoonnummer wordt uit de database gehaald van de bijbehorende bijboeker (naam in de combobox)
            string naam = cbBBNaam.Text;
            int telefoonnummer = Convert.ToInt32(db.SelectData("SELECT telefoonnummer FROM PERSOON WHERE NAAM = '" + naam + "'"));
            textBoxBBTel.Text = telefoonnummer.ToString();
        }

        /// <summary>
        /// Er wordt gekeken of er een reservering is geselecteerd, zo ja dan wordt deze verwijderd (met bijbehorende personen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVerwijder_Click(object sender, EventArgs e)
        {
            if (nummer != 0)
            {
                ReserveringBeheer.DeleteReservering(nummer);
                MessageBox.Show("Reservering Verwijderd!");
                listBoxOverzicht.SelectedIndex = -1;
                Start();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een reservering in de lijst om aan te verwijderen.");
            }
        }

        /// <summary>
        /// Het form wordt afgesloten als er op reservering plaatsen wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void plaats_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Het form wordt afgesloten als er op reservering aanpassen wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wijzig_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Deze methode haalt alle 
        /// </summary>
        private void Start()
        {
            listBoxOverzicht.Items.Clear();
            textBoxHBNaam.Text = "Geen Reservering geslecteerd";
            textBoxHBEmail.Text = "Geen Reservering geslecteerd";
            textBoxHBAdres.Text = "Geen Reservering geslecteerd";
            textBoxHBPostcode.Text = "Geen Reservering geslecteerd";
            textBoxHBWoonplaats.Text = "Geen Reservering geslecteerd";
            textBoxHBTel.Text = "Geen Reservering geslecteerd";
            textBoxHBReserveringsnummer.Text = "Geen Reservering geslecteerd";
            cbBBNaam.SelectedIndex = -1;
            textBoxBBTel.Text = "Geen Reservering geslecteerd";

            //alle benodigde informatie wordt opgehaald uit de database en wordt in de listbox neergezet voor het overzicht van de reserveringen
            DataTable dt = db.getData("SELECT R.RESERVERING_NUMMER as reservering_nummer, PER.NAAM AS naam, PER.PERSOON_NUMMER as persoon_nummer, R.BETAALD as betaald FROM RESERVERING R, PERSOON PER, HOOFDBOEKER HFD WHERE PER.PERSOON_NUMMER = HFD.PERSOON_NUMMER AND R.RESERVERING_NUMMER = HFD.RESERVERING_NUMMER ORDER BY reservering_nummer");

            foreach (DataRow rdr in dt.Rows)
            {
                Reserveringsnummer = Convert.ToInt32(rdr["reservering_nummer"]);
                HfdNaam = rdr["naam"].ToString();
                HfdPsn = Convert.ToInt32(rdr["persoon_nummer"]);
                Betaald = rdr["betaald"].ToString();
                listBoxOverzicht.Items.Add("Reserveringsnummer: " + Reserveringsnummer + ", Hoofdboeker: " + HfdNaam + ", Persoonlijk nummer: " + HfdPsn + ", Betaald: " + Betaald);
            }
        }
            
        }
    }
