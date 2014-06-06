using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Uitleen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (MateriaalCategorie a in MateriaalCategorie.GetMateriaalCategorieen())
                {
                    //   if (CategorieList.Items.Contains( a.Naam))
                    // METHODE 1
                    CategorieList.Items.Add(a.Naam);
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void rechts_Click(object sender, EventArgs e)
        {

        }


        protected void Bevestigknop_Click(object sender, EventArgs e)
        {

            MateriaalBeheer.LeenUit(ArtiekelList.SelectedItem.ToString(), Convert.ToInt32(TbRFID.Text), Convert.ToInt32(TbAantal.Text));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MateriaalCategorie materiaalcategorie = new MateriaalCategorie(CategorieList.SelectedValue);
            ArtiekelList.Items.Clear();
            foreach(Materiaal materiaal in Materiaal.GetMaterialenBijCategorie(materiaalcategorie))
            {
                string totaal = (materiaal.Barcode.ToString() + ": " + materiaal.Naam.ToString() + ", aantal: " + materiaal.Aantal.ToString());
                ArtiekelList.Items.Add(totaal);
               // ArtiekelList.Items.Add(new ListItem(materiaal.Naam, materiaal.Barcode));
            }
            CategorieList.SelectedValue = materiaalcategorie.Naam;
            //CategorieList
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Reservering r = Reservering.GetReserveringBijNummer(Convert.ToInt32(ReserveringNRinleverBox.Text));
            List<Materiaal> materialen = new List<Materiaal>();
            foreach (Materiaal a in materialen)
            {
                if (a.Barcode == ArtiekelList.SelectedValue.Substring(0, ArtiekelList.SelectedValue.IndexOf(",")))
                {
                    MateriaalBeheer.Brengterug(a, r, Convert.ToInt32(AantalInleverBox.Text));
                }
            }
        }

        protected void RFIDinleverBox_TextChanged(object sender, EventArgs e)
        {
            UitgeleendMateriaal.GetUitgeleendMateriaalBijReservering(ReserveringNRinleverBox.Text);
        }
    }
}