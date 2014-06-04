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

        protected void Volgende_Click(object sender, EventArgs e)
        {
            Session["Stap1"] = "Stapke1";

            Response.Redirect("Stap2.aspx");
        }
    }
}