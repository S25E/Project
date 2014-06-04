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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Stap1"] == null)
            {
                Response.Redirect("Stap1.aspx");
            }
        }

        protected void Volgende_Click(object sender, EventArgs e)
        {
            Session["Stap2"] = "Stapke2";

            Response.Redirect("Stap3.aspx");
        }
    }
}