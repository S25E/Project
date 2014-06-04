using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Toelating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = Site1.UpdateTitle("Toelating");
            AanwezigenList.DataSource = Persoon.GetAanwezigePersonen();
            AanwezigenList.DataBind();
        }

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Persoon persoon = Persoon.GetPersoonBijRFID(RFIDCheck.Text);
                if (persoon is Boeker)
                {
                    if ((persoon as Boeker).Reservering.Betaald)
                    {
                        persoon.Aanwezig = !persoon.Aanwezig;
                        RFIDCheck.ForeColor = System.Drawing.Color.Black;
                        InfoLabel.ForeColor = System.Drawing.Color.Green;
                        InfoLabel.Text = "";
                        RFIDCheck.Text = persoon.Naam + " is" + (persoon.Aanwezig ? " In" : " Uit") + "gecheckt";
                    }
                    else
                    {
                        InfoLabel.ForeColor = System.Drawing.Color.Red;
                        RFIDCheck.ForeColor = System.Drawing.Color.Red;
                        InfoLabel.Text = "U heeft nog niet betaald!";
                    }
                }
                else 
                { 
                    if(persoon is Medewerker)
                    {
                        persoon.Aanwezig = !persoon.Aanwezig;
                        RFIDCheck.ForeColor = System.Drawing.Color.Black;
                        InfoLabel.ForeColor = System.Drawing.Color.Green;
                        InfoLabel.Text = "";
                        RFIDCheck.Text = persoon.Naam + " is" + (persoon.Aanwezig ? " In" : " Uit") + "gecheckt";
                    }
                    else
                    {
                        RFIDCheck.ForeColor = System.Drawing.Color.Red;
                        InfoLabel.ForeColor = System.Drawing.Color.Red;
                        InfoLabel.Text = "U bent niet bekend in ons systeem";
                    }
                }
            }
            catch 
            {
                RFIDCheck.ForeColor = System.Drawing.Color.Red;
                InfoLabel.ForeColor = System.Drawing.Color.Red;
                InfoLabel.Text = "U bent niet bekend in ons systeem";
            }

            RFIDCheck.Focus();
        }

        public string Persoonstring(string rfid)
        {
            Persoon current = Persoon.GetPersoonBijRFID(rfid);
            if (current is Hoofdboeker)
            {
                return "RFID: " + current.Nummer + "<br />" + "Naam: " + current.Naam + "<br />" + "Email: " + (current as Hoofdboeker).Email + "<br />" + "Rekeningnr: " + (current as Hoofdboeker).Rekeningnummer + "<br />" + "Resnr: " + (current as Hoofdboeker).ReserveringNummer + "<br />" + "Telnr: " + (current as Hoofdboeker).Telefoon;
            }
            else
            {
                if(current is Bijboeker)
                {
                    return "RFID: " + current.Nummer + "<br />" + "Naam: " + current.Naam + "<br />" + "Resnr: " + (current as Bijboeker).ReserveringNummer;
                }
                else
                {
                    if(current is Medewerker)
                    {
                        return "RFID: " + current.Nummer + "<br />" + "Naam: " + current.Naam + "<br />" + "Functie: " + (current as Medewerker).Functie + "<br />" + "Rekeningnr: " + (current as Medewerker).Rekeningnummer;
                    }
                    else
                    {
                        return rfid + " niet Bekend";
                    }
                }
            }
            
        }
    }
}