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
            TbNaam.ForeColor = System.Drawing.Color.Green;
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            TbNaam.ForeColor = System.Drawing.Color.Red;
        }

        protected void DropDownHoofdboeker_Click(object sender, EventArgs e)
        {
            //text combobox aanpassen
            combobox.Text = "Hoofdboeker  ▼";

            //labels terug zetten
            LabelStraat.Visible = true;
            LabelPostcode.Visible = true;
            LabelWoonplaats.Visible = true;
            LabelEmail.Visible = true;
            LabelRekeningnummer.Visible = true;
            LabelSofinummer.Visible = true;

            //tb terugzetten
            TbStraat.Visible = true;
            TbPostcode.Visible = true;
            TbWoonplaats.Visible = true;
            TbEmail.Visible = true;
            TbRekeningnummer.Visible = true;
            TbSofinummer.Visible = true;
        }

        protected void DropDownBijboeker_Click(object sender, EventArgs e)
        {
            //text combobox aanpassen
            combobox.Text = "Bijboeker  ▼";

            //labels verwijderen
            LabelStraat.Visible = false;
            LabelPostcode.Visible = false;
            LabelWoonplaats.Visible = false;
            LabelEmail.Visible = false;
            LabelRekeningnummer.Visible = false;
            LabelSofinummer.Visible = false;

            //tb verwijderen
            TbStraat.Visible = false;
            TbPostcode.Visible = false;
            TbWoonplaats.Visible = false;
            TbEmail.Visible = false;
            TbRekeningnummer.Visible = false;
            TbSofinummer.Visible = false;
        }
    }
}