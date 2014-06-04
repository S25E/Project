using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Stap4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Stap3"] == null)
            {
                Response.Redirect("Stap3.aspx");
            }
        }
        protected void Volgende_Click(object sender, EventArgs e)
        {
            Response.Write(Session["Stap1"]);
            Response.Write(Session["Stap2"]);
            Response.Write(Session["Stap3"]);
            Response.Write(Session["Stap4"]);
            Session["Stap1"] = null;
            Session["Stap2"] = null;
            Session["Stap3"] = null;
            Session["Stap4"] = null;
        }
    }
}