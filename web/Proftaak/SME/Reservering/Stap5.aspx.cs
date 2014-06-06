using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Stap5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Stap4"] == null)
            {
                Response.Redirect("Stap4.aspx");
            }
            else
            {
                Hoofdboeker Hoofdboeker = (Hoofdboeker)Session["Stap1"];
                LabelNaam.Text = Hoofdboeker.Naam;
                LabelTelefoonnummer.Text = Hoofdboeker.Telefoon;
                LabelPostocde.Text = Hoofdboeker.Postcode;
                LabelWoonplaats.Text = Hoofdboeker.Woonplaats;
                LabelStraat.Text = Hoofdboeker.Straat;
                LabelEmailadres.Text = Hoofdboeker.Email;
                LabelRekeningnummer.Text = Hoofdboeker.Rekeningnummer;
                LabelSofinummer.Text = Hoofdboeker.Sofinummer;

                List<Bijboeker> Bijboekers = (List<Bijboeker>)Session["Stap2"];
                ListboxBijboekers.DataSource = Bijboekers;
                ListboxBijboekers.DataTextField = "Naam";
                ListboxBijboekers.DataBind();

                ListboxKampeerplaats.DataSource = Session["Stap3"];
                ListboxKampeerplaats.DataTextField = "Nummer";
                ListboxKampeerplaats.DataBind();

                List<Materiaal> Barcodes = (List<Materiaal>)Session["Stap4"];
                
                Listboxmaterialen.DataSource = Barcodes;
                Listboxmaterialen.DataTextField = "Naam";
                Listboxmaterialen.DataBind();
            }
        }

        protected void Bevestig_Click(object sender, EventArgs e)
        {
            Hoofdboeker Hoofdboeker = (Hoofdboeker)Session["Stap1"];
            List<Bijboeker> Bijboekers = (List<Bijboeker>)Session["Stap2"];
            List<Kampeerplaats> Kampeerplaatsen = (List<Kampeerplaats>)Session["Stap3"];
            List<Materiaal> Materialen = (List<Materiaal>)Session["Stap4"];

            Reservering reservering = new Reservering();
            ReserveringBeheer.AddReservering(reservering, Hoofdboeker);
            
            foreach(Bijboeker bijboeker in Bijboekers)
            {
                reservering.AddBijboeker(bijboeker);
            }

            foreach(Kampeerplaats kampeerplaats in Kampeerplaatsen)
            {
                Kampeerplaats.AddKampeerplaatsReservering(reservering, kampeerplaats.Nummer);
            }

            
            foreach(Materiaal materiaal in Materialen)
            {
                Materiaal.AddMateriaalReservering(reservering, materiaal.Barcode);
            }

            Session["Stap1"] = null;
            Session["Stap2"] = null;
            Session["Stap3"] = null;
            Session["Stap4"] = null;
            Response.Redirect("Stap1.aspx");
        }
    }
}