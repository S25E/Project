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
    public partial class Form1 : Form
    {
        List<Label> labels;
        DB db2 = new DB();
        Form2 overzicht;
        List<Kampeerplaats> Kampeerplaatsen = new List<Kampeerplaats>();
        int nummer = 0;                                                              //wordt gebruikt voor unieke persoonsnummers te creeren.
        double aantalPlaatsen;             
        ReserveringBeheer ReserveringBeheer = new ReserveringBeheer();
        Reservering r;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Reserveringstoepassing";                                    //in de foreach loop worden de labels op de plattegrond geplaatst d.m.v. de x en y coordinaten
            int reserveringsnummer = ReserveringBeheer.GetVrijReserveringsnummer();
            r = new Reservering(reserveringsnummer);
            ReserveringBeheer.GetKampeerplaatsen();
            labels = new List<Label>();
            foreach (Kampeerplaats k in ReserveringBeheer.Kampeerplaatsen)
            {
                Label label = new Label();
                label.Left = k.X;
                label.Top = k.Y;
                label.Text = k.Nummer.ToString();
                label.Name = "lb"+ label.Text;

                label.AutoSize = true;
                label.Parent = pbPlattegrond;
                if (k.Reserveringsnummer != 0)                                        //als een kampeerplaats niet vrij is dan wordt de achtergrondkleur van het label rood.
                {                                                                     //een kampeerplaats is vrij als er geen reserveringsnummer is, dus 0 (default waarde is 0)
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.BackColor = Color.Transparent;
                    cbOpmerking.Items.Add(k.Nummer.ToString());
                    labels.Add(label);
                }
                
                pbPlattegrond.Controls.Add(label);
            }
            cbOpmerking.SelectedIndex = 0;
            cbMatCategorie.Items.Clear();
            GetCategorie();
            buttonBevestig.Enabled = false;
            buttonPlaatsToevoegen.Enabled = false;
            buttonMatToevoegen.Enabled = false;
        }

        /// <summary>
        /// Als de waarde in de combobox met vrije kampeerplaatsen wordt veranderd, dan wordt de opmerking uit de database gehaald (als die er is)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbOpmerking_SelectedValueChanged(object sender, EventArgs e)
        {
            string uitkomst = db2.SelectData("SELECT OPMERKING FROM CAMPINGPLAATS WHERE PLAATS_NUMMER = '" + cbOpmerking.Text + "'").ToString();
           
            if (DBNull.Value.Equals(uitkomst)) //de opmerking over de kampeerplaats wordt in de textbox gezet als het resultaat van de select query niet null is
            {
                textBoxOpmerking.Text = "";
            }
            else
            {
                textBoxOpmerking.Text = uitkomst;
                foreach (Label label in labels)
                {
                    if (label.Name == "lb" + cbOpmerking.Text)
                    {
                        label.BackColor = Color.Yellow;
                    }
                    else
                    {
                        label.BackColor = Color.Transparent;
                        foreach (int i in listBoxPlaatsen.Items)
                        {
                            if ("lb" + i == label.Name)
                            {
                                label.BackColor = Color.Blue;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// De hoofdboeker wordt toegevoegd aan de reservering, als deze aan alle eisen voldoet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHBToevoegen_Click(object sender, EventArgs e)
        {
            bool goed = false;
            try                                                                          //er wordt gekeken of alle informatie van het juiste type is bijv. telefoonnummer moet een int zijn
            {
                int HBTelefoonnummer = Convert.ToInt32(textBoxHBTelefoonnummer.Text);
                if (textBoxHBNaam.Text == "" || textBoxHBAdres.Text == "" || textBoxHBPostcode.Text == "" || textBoxHBWoonplaats.Text == "" || textBoxHBEmail.Text == "" || textBoxHBWachtwoord.Text == "" || textBoxHBRekeningnummer.Text == "" || textBoxHBTelefoonnummer.Text == "")
                {
                    goed = false;
                    MessageBox.Show("Voer alle velden in");
                }
                else
                {
                    goed = true;                                                        //goed is true als alle informatie van het juiste type is.
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Voer alleen getallen in het vak: Telefoonnummer van de hoofd");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Voer maximaal 10 getallen in als telefoonnummer, zonder '-' of '+' ");
            }

            //Er wordt pas een instantie van hoofdboeker aangemaakt als alle velden goed zijn ingevuld
            if (goed)
            {
                buttonHBToevoegen.Enabled = false;                                       //er kan maar 1 hoofdboeker zijn, dus wordt de button gedisabled
                
                
                                
                int psn = ReserveringBeheer.GetVrijPersoonsnummer() + nummer;           //het hoogste persoonsnummer wordt uit de database gehaald + 1 met eventueel de waarde van "nummer" erbij zodat het een uniek getal is
                nummer++;
                Hoofdboeker Hoofdboeker = new Hoofdboeker(psn, textBoxHBNaam.Text, textBoxHBTelefoonnummer.Text, textBoxHBWachtwoord.Text, textBoxHBAdres.Text, textBoxHBPostcode.Text, textBoxHBWoonplaats.Text, textBoxHBEmail.Text, textBoxHBRekeningnummer.Text);
                r.AddPersoon(Hoofdboeker, true);

                string hoofdboekerstring = Hoofdboeker.Naam + ", " + Hoofdboeker.Adres + ", " + Hoofdboeker.Postcode + ", Hoofdboeker";
                listBoxPersonen.Items.Insert(0, hoofdboekerstring);    
                
                string hoofdboekerComboBox = Hoofdboeker.Naam + "(Hoofdboeker)";        //de hoofdboeker wordt bovenin de listbox geplaatst voor een beter overzicht
                cbNaam.Items.Insert(0, hoofdboekerComboBox);                            //de hoofdboeker wordt boven in de combobox geplaatst voor een beter overzicht
                
                buttonPlaatsToevoegen.Enabled = true;                                    
                cbNaam.SelectedIndex = 0;                                               //de combobox laat meteen de eerste waarde zien (op index 0)
                buttonMatToevoegen.Enabled = true;
            }
            
        }

        /// <summary>
        /// Een bijboeker wordt toegevoegd aan de reservering, als deze aan alle eisen voldoet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBBToevoegen_Click(object sender, EventArgs e)
        {
            bool nieuw = true;
            bool goed = false;
            try
            {
                int telefoonnummer = Convert.ToInt32(textBoxBBTel.Text);
                if (textBoxBBNaam.Text == "" || textBoxBBTel.Text == "" || textBoxBBWachtwoord.Text == "")
                {
                    goed = false;
                    MessageBox.Show("Voer alle velden in");
                }
                else
                {
                    goed = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Voer alleen getallen in het vak: Telefoonnummer van de bijboeker");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Voer maximaal 10 getallen in als telefoonnummer, zonder '-' of '+' ");
            }

            foreach (Bijboeker b in r.Bijboekers)
            {
                if (b.Naam == textBoxBBNaam.Text)
                {
                    nieuw = false;
                }
            }

            if (nieuw && goed)                                                          //er wordt een bijboeker toegevoegd als hij nog niet bestaat en alle gegevens zijn van het goede type
            {
                int psn = ReserveringBeheer.GetVrijPersoonsnummer() + nummer;
                nummer++;
                Bijboeker Bijboeker = new Bijboeker(psn, textBoxBBNaam.Text, textBoxBBTel.Text, textBoxBBWachtwoord.Text);
                listBoxPersonen.Items.Add(Bijboeker.Naam + ", " + Bijboeker.Telefoonnummer);
                r.AddPersoon(Bijboeker, false);
                cbNaam.Items.Add(Bijboeker.Naam);
                cbNaam.SelectedIndex = 0;
                buttonMatToevoegen.Enabled = true;
            }
            else if(!nieuw)
            {
                MessageBox.Show("Persoon staat al in de Reservering");
            }
            aantalPlaatsen = Math.Ceiling(Convert.ToDouble(r.Bijboekers.Count + 1) / 5); //er wordt gekeken hoeveel plaatsen er nodig zijn. 5 personen per plaats. math.ceiling rond naar boven af
        }

        /// <summary>
        /// Er wordt een plaats toegevoegd aan de reservering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlaatsToevoegen_Click(object sender, EventArgs e)
        {
            //check of de plaats al toegevoegd is aan de huidige reservering
            if (listBoxPlaatsen.Items.Count != 0)
            {
                bool nieuw = false;
                foreach (var listboxItem in listBoxPlaatsen.Items)
                {
                    int bezet = Convert.ToInt32(cbOpmerking.Text);
                    if (!bezet.Equals(listboxItem))
                    {
                        nieuw = true;
                    }
                    else
                    {
                        MessageBox.Show("U heeft deze plaats al toegevoegd");
                    }
                }
                if (nieuw)
                {
                    listBoxPlaatsen.Items.Add(Convert.ToInt32(cbOpmerking.Text));
                    int plaatsnummer = Convert.ToInt32(cbOpmerking.Text);
                    Kampeerplaats k = new Kampeerplaats(plaatsnummer);
                    Kampeerplaatsen.Add(k);

                }
            }
            else
            {
                listBoxPlaatsen.Items.Add(Convert.ToInt32(cbOpmerking.Text));
                int plaatsnummer = Convert.ToInt32(cbOpmerking.Text);
                Kampeerplaats k = new Kampeerplaats(plaatsnummer);
                Kampeerplaatsen.Add(k);

            }
            if (listBoxPlaatsen.Items.Count >= aantalPlaatsen)
            {
                buttonPlaatsToevoegen.Enabled = false;
                buttonBBToevoegen.Enabled = false;
                buttonBevestig.Enabled = true;                                          //er kan alleen maar een reservering gemaakt worden als er tenminste een hoofdpersoon is en er zijn kampeerplaatsen toegevoegd
            }
        }


        /// <summary>
        /// Als de waarde van de dropdownbox "Categorie" wordt gewijzigd dan worden de producten binnen die categorie opnieuw uit de database gehaald.
        /// Deze worden dan ook weer toegevoegd aan de dropdownlist "Producten"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMatCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMatProduct.Items.Clear();
            string categorienaam = cbMatCategorie.Text;
            string query = "SELECT DISTINCT NAAM FROM ARTIKEL WHERE CATEGORIE = '" + categorienaam + "' AND BARCODE NOT IN  (SELECT BARCODE FROM LENING)";
            foreach (string s in ReserveringBeheer.GetProducten(query, "naam"))
            {
                this.cbMatProduct.Items.Add(s);
            }
            this.cbMatProduct.SelectedIndex = 0;
        }

        /// <summary>
        /// Haalt alle categorieen op uit de database via de datbase class
        /// </summary>
        public void GetCategorie()
        {
            cbMatCategorie.Items.Clear();
            foreach (string s in ReserveringBeheer.GetProductCategorie())
            {
                cbMatCategorie.Items.Add(s);
            }
            cbMatCategorie.SelectedIndex = 0;
        }

        /// <summary>
        /// Er wordt gekeken of het geselecteerde materiaal wordt geleend door de gebruiker(in de listbox), als het niet het geval is dan wordt het toegevoegd aan de listbox
        /// En later aan de reservering + database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMatToevoegen_Click(object sender, EventArgs e)
        {
            bool goed = true;
            for (int i = 0; i < listBoxMateriaal.Items.Count; i++)
            {
                if (listBoxMateriaal.Items[i].Equals(cbNaam.Text + ", " + cbMatProduct.Text + ", " + cbMatCategorie.Text))
                {
                    goed = false;
                }
            }

            if (goed)
            {
                listBoxMateriaal.Items.Add(cbNaam.Text + ", " + cbMatProduct.Text + ", " + cbMatCategorie.Text);
                int bijboekernummer;
                Materiaal m;
                int barcode = Convert.ToInt32(db2.SelectData("SELECT BARCODE FROM ARTIKEL WHERE NAAM = '" + cbMatProduct.Text + "'"));
                if (cbNaam.Text.EndsWith("(Hoofdboeker)"))
                {
                    m = new Materiaal(cbNaam.Text, r.Hoofdboeker.Nummer, cbMatProduct.Text, barcode);
                    //Materialen.Add(m);
                    r.AddMateriaal(m);

                }
                else
                {
                    foreach (Bijboeker b in r.Bijboekers)
                    {
                        if (cbNaam.Text == b.Naam)
                        {
                            bijboekernummer = b.Nummer;
                            m = new Materiaal(cbNaam.Text, bijboekernummer, cbMatProduct.Text, barcode);
                            //Materialen.Add(m);
                            r.AddMateriaal(m);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Deze persoon heeft dit item al gereserveerd");
            }
            
        }


        /// <summary>
        /// De reservering wordt pas gemaakt en toegevoegd in de database als alles klopt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBevestig_Click(object sender, EventArgs e)
        {
            //ReserveringBeheer.AddReservering(Hoofdboeker, bijboekers, Kampeerplaatsen, ReserveringBeheer.GetVrijReserveringsnummer(), Materialen); //er wordt een reservering aangemaakt en alles wordt opgeslagen in de database. Zie class ReserveringBeheer voor details.
            ReserveringBeheer.AddReservering(r);
            db2.Close();
            overzicht = new Form2();
            overzicht.Show();
            overzicht.FormClosed += new FormClosedEventHandler(overzicht_FormClosed);
            this.Hide();
        }

        /// <summary>
        /// Als er op annuleer wordt geklikt dan wordt het overzicht van de reserveringen weer weergegeven. Er wordt dan niet opgeslagen in de database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnnuleer_Click_1(object sender, EventArgs e)
        {
            db2.Close();
            overzicht = new Form2();
            overzicht.Show();
            overzicht.FormClosed += new FormClosedEventHandler(overzicht_FormClosed);
            this.Hide();
        }

        /// <summary>
        /// Het form wordt gesloten in plaats van te hiden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void overzicht_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }            
    }
}