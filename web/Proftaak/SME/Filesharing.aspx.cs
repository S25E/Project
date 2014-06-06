using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME.pages
{
    public partial class Filesharing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Categorie.Items.Add("");
                foreach (Map map in BestandenCatalogus.Mappen)
                {
                    Categorie.Items.Add(new ListItem(map.ToString(), map.Nummer.ToString()));
                }
                PanelBestand.Visible = false;
            }
        }

        protected void Categorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Categorie.SelectedValue != "")
            {
                PanelBestand.Visible = true;
                setBestanden(Convert.ToInt32(Categorie.SelectedValue));
            }
            else
            {
                PanelBestand.Visible = false;
            }
        }

        protected void setBestanden(int map_id)
        {
            Bestanden.Items.Clear();
            Bestanden.Items.Add("");
            foreach (Bestand bestand in Map.GetMapBijNummer(map_id).Bestanden)
            {
                Bestanden.Items.Add(new ListItem(bestand.Naam, bestand.Nummer.ToString()));
            }
        }

        protected void Bestanden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}