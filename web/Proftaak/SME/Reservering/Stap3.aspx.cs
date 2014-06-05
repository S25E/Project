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
                dropdown.DataSource = Kampeerplaatsen;
                dropdown.DataTextField = "Nummer";
                dropdown.DataBind();

                Kampeerplaats kampeerplaats = Kampeerplaats.GetKampeerplaatsBijNummer(Convert.ToInt32(dropdown.Text));
                TbOpmerking.Text = kampeerplaats.Opmerking;

                if (Session["Stap2"] == null)
                {
                    //Response.Redirect("Stap2.aspx");
                }
            }

            repeaterPlaatsen.DataSource = Session["Stap3"];
            repeaterPlaatsen.DataBind();

            KampeerplaatsenLijst.DataSource = Kampeerplaats.GetKampeerplaatsen();
            KampeerplaatsenLijst.DataBind();
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {

            Response.Redirect("Stap4.aspx");
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
            int kampeerplaats = Convert.ToInt32(dropdown.Text);
            Kampeerplaatsen.Add(kampeerplaats);
            Session["Stap3"] = Kampeerplaatsen;
            Response.Redirect("Stap3.aspx");
        }
    }
}