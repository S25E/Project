using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Toelating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Persoon persoon = Persoon.GetPersoonBijRFID(3234);
            //persoon.Aanwezig = !persoon.Aanwezig;
            this.Title = Site1.UpdateTitle("Toelating");
        }
    }
}