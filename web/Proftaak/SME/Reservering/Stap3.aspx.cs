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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Stap2"] == null)
            {
                Response.Redirect("Stap2.aspx");
            }
        }

        protected void Volgende_Click(object sender, EventArgs e)
        {
            Session["Stap3"] = "Stapke3";

            Response.Redirect("Stap4.aspx");
        }
    }
}