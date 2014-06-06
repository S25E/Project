using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME.admin
{
    public partial class AanwezigePersonen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonenView.DataSource = Persoon.GetAanwezigePersonenTout();
            PersonenView.DataBind();
        }
    }
}