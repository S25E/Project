using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Stap3 : System.Web.UI.Page
    {
        List<Int32> Kampeerplaatsen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Kampeerplaats> Kampeerplaatsen = Kampeerplaats.GetVrijeKampeerplaatsen();
                var sortedlist = Kampeerplaatsen.OrderBy(i => i.Nummer);
                dropdown.DataSource = Kampeerplaatsen;
                dropdown.DataTextField = "Nummer";
                dropdown.DataBind();

                Kampeerplaats kampeerplaats = Kampeerplaats.GetKampeerplaatsBijNummer(Convert.ToInt32(dropdown.Text));
                TbOpmerking.Text = kampeerplaats.Opmerking;

                if (Session["Stap2"] == null)
                {
                    Response.Redirect("Stap2.aspx");
                }
            }

            if (Session["Stap3"] != null)
            {
                List<Bijboeker> Bijboekers = (List<Bijboeker>)Session["Stap2"];
                double aantalPlaatsen = Math.Ceiling(Convert.ToDouble(Bijboekers.Count + 1) / 5);
                List<Int32> plaatsen = (List<Int32>)Session["Stap3"];
                if (aantalPlaatsen <= plaatsen.Count)
                {
                    ButtonSelecteer.Visible = false;
                }
                else
                {
                    ButtonSelecteer.Visible = true;
                }
                repeaterPlaatsen.DataSource = Session["Stap3"];
                repeaterPlaatsen.DataBind();
            }
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            if (Session["Stap3"] != null)
            {
                List<Bijboeker> Bijboekers = (List<Bijboeker>)Session["Stap2"];
                double aantalPlaatsen = Math.Ceiling(Convert.ToDouble(Bijboekers.Count + 1) / 5);
                List<Int32> plaatsen = (List<Int32>)Session["Stap3"];
                if (aantalPlaatsen <= plaatsen.Count)
                {
                    Response.Redirect("Stap4.aspx");
                }
                else
                {
                    Labelfoutmelding.Text = "Voeg nog een kampeerplaats toe.";
                }
            }
            
        }

        protected void LaadOpmerking(object sender, EventArgs e)
        {
           Kampeerplaats kampeerplaats = Kampeerplaats.GetKampeerplaatsBijNummer(Convert.ToInt32(dropdown.Text));
           TbOpmerking.Text = kampeerplaats.Opmerking;
        }

        protected void ButtonSelecteer_Click(object sender, EventArgs e)
        {
            Kampeerplaatsen = (List<Int32>)Session["Stap3"];
            if(Kampeerplaatsen == null)
            {
                Kampeerplaatsen = new List<int>();
            }

            if (!Kampeerplaatsen.Contains(Convert.ToInt32(dropdown.Text)))
            {
                int kampeerplaats = Convert.ToInt32(dropdown.Text);
                Kampeerplaatsen.Add(kampeerplaats);
                Session["Stap3"] = Kampeerplaatsen;
                Response.Redirect("Stap3.aspx");
            }
            else
            {
                Labelfoutmelding.Text = "U heeft deze plaats al geselecteerd, selecteer een andere plaats.";
            }
        }
    }
}