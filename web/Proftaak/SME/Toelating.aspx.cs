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
            this.Title = Site1.UpdateTitle("Toelating");
        }

        protected void ButtonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Persoon persoon = Persoon.GetPersoonBijRFID(RFIDCheck.Text);
                persoon.Aanwezig = !persoon.Aanwezig;
                RFIDCheck.ForeColor = System.Drawing.Color.Black;
            }
            catch 
            {
                RFIDCheck.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}