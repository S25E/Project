using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bevestigknop_Click(object sender, EventArgs e)
        {
            Materiaal materiaal = new Materiaal(tbBarcode.Text, TbNaam.Text, Convert.ToInt32(tbAantal.Text), Convert.ToInt32(tbVerhuurprijs.Text), tbOmschrijving.Text, tbCategorie.Text);

            Materiaal.AddMateriaal(materiaal);
        }
    }
}