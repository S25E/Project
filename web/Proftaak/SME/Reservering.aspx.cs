using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Reservering1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = Site1.UpdateTitle("Reservering");
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            Hoofdboeker hoofdboeker = new Hoofdboeker(TbNaam.Text, TbStraat.Text, TbPostcode.Text, TbWoonplaats.Text, TbTelefoonnummer.Text, TbEmail.Text, TbRekeningnummer.Text, TbSofinummer.Text);
            Persoon.AddPersoon(hoofdboeker);
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            TbNaam.ForeColor = System.Drawing.Color.Red;
        }
    }
}