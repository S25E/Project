﻿using System;
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
                foreach (Map map in BestandenCatalogus.Mappen)
                {
                    Categorie.Items.Add(new ListItem(map.ToString(), map.Nummer.ToString()));
                }
            }
        }

        protected void Categorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Bestand bestand in Map.GetMapBijNummer(Convert.ToInt32(Categorie.SelectedValue)).Bestanden)
            {
                Bestanden.Items.Add(new ListItem(bestand.Naam, bestand.Nummer.ToString()));
            }
            //Bestanden.DataSource = Map.GetMapBijNummer(Convert.ToInt32(Categorie.SelectedValue)).Bestanden;
        }

        protected void Bestanden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}