using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Stap2 : System.Web.UI.Page
    {
        List<Bijboeker> Bijboekers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Stap1"] == null)
            {
                Response.Redirect("Stap1.aspx");
            }
            else
            {
                if (Session["Stap2"] != null)
                {
                    repeaterBijboekersNaam.DataSource = Session["Stap2"];
                    repeaterBijboekersNaam.DataBind();
                }
            }

        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Response.Redirect("Stap3.aspx");
            }
        }

        protected void ButtonVoegToe_Click(object sender, EventArgs e)
        {
            Bijboekers = (List<Bijboeker>)Session["Stap2"];
            if (Bijboekers == null)
            {
                Bijboekers = new List<Bijboeker>();
            }
            Bijboeker bijboeker = new Bijboeker(TbBijboekersNaam.Text);
            Bijboekers.Add(bijboeker);
            Session["Stap2"] = Bijboekers;
            Response.Redirect("Stap2.aspx");
        }
    }
}