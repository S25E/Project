﻿using System;
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
                        RFIDCheck.Text = persoon.Naam + " is" + (persoon.Aanwezig ? " In" : " Uit") + "gechecked";
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
                        RFIDCheck.Text = persoon.Naam + " is" + (persoon.Aanwezig ? " In" : " Uit") + "gechecked";
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
    }
}