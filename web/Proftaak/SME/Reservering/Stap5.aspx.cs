using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

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

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("s25sme@gmail.com", "proft@@k");
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Uw registratie bij SME";
            mail.IsBodyHtml = true;
            string bodyHeader = "<h3>Bedankt voor het plaatsen van een reservering bij SME.</h3><br /><p>Uw gegevens:</p><p><ul>";
            string body = "<li>Naam: " + Hoofdboeker.Naam + "</li><li>Telefoonnummer: " + Hoofdboeker.Telefoon + "</li><li>Woonplaats: " + Hoofdboeker.Woonplaats + "</li><li>Straat: " + Hoofdboeker.Woonplaats + "</li><li>Emailadres: " + Hoofdboeker.Email + "</li><li>Rekeningnummer: " + Hoofdboeker.Rekeningnummer + "</li><li>Sofinummer: " + Hoofdboeker.Sofinummer + "</li><li>Persoonlijk nummer: " + Hoofdboeker.Nummer + "</li><li>Uw reserveringsnummer: " + Hoofdboeker.ReserveringNummer + "</li><li>Wachtwoord: "+  +"</li>";
            string bodyFooter = "</ul>";
            
            string bericht = bodyHeader + body + bodyFooter;
            mail.Body = bericht;

            //Setting From , To and CC
            mail.From = new MailAddress("s25sme@gmail.com", "SME");
            mail.To.Add(new MailAddress(bestelling.Winkelwagen.Account.Gebruikersnaam));

            SmtpServer.Send(mail);

            Session["Stap1"] = null;
            Session["Stap2"] = null;
            Session["Stap3"] = null;
            Session["Stap4"] = null;
            Response.Redirect("Stap1.aspx");
        }
    }
}