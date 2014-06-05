using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Stap1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Hoofdboeker hoofdboeker = new Hoofdboeker(TbNaam.Text, TbStraat.Text, TbPostcode.Text, TbWoonplaats.Text, TbTelefoonnummer.Text, TbEmail.Text, TbRekeningnummer.Text, TbSofinummer.Text);
                Session["Stap1"] = hoofdboeker;
                Response.Redirect("Stap2.aspx");
            }
        }
    }
}