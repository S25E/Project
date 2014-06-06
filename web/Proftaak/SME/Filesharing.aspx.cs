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
        protected Persoon persoon = Persoon.GetPersoonBijRFID("000039");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Categorie.Items.Add("");
                foreach (Map map in BestandenCatalogus.Mappen)
                {
                    Categorie.Items.Add(new ListItem(map.ToString() + " (" + map.Bestanden.Count + ")", map.Nummer.ToString()));
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
            if (Bestanden.SelectedValue != "")
            {
                UpdateBestand(Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue)));
            }
            else
            {
                PanelInfo.Visible = false;
            }
        }

        protected void UpdateBestand(Bestand bestand)
        {
            PanelInfo.Visible = true;
            Bestandnaam.InnerText = bestand.Naam;
            Score.Text = bestand.Rating.ToString();
            Naam.Text = bestand.Naam + bestand.Extensie;
            Beschrijving.Text = bestand.Beschrijving;
            int grootte = bestand.Grootte / 1024;
            Grootte.Text = grootte.ToString() + "kb";
            Datum.Text = bestand.Datum.ToString();
            Uploader.Text = bestand.Uploader.Naam;

            if (!bestand.Likes.Contains(this.persoon))
            {
                Like.Attributes.Remove("disabled");
            }
            else
            {
                Like.Attributes.Add("disabled", "disabled");
            }

            if (!bestand.Dislikes.Contains(this.persoon))
            {
                Dislike.Attributes.Remove("disabled");
            }
            else
            {
                Dislike.Attributes.Add("disabled", "disabled");
            }

            if (!bestand.Reports.Contains(this.persoon))
            {
                Report.Attributes.Remove("disabled");
            }
            else
            {
                Report.Attributes.Add("disabled", "disabled");
            }

            if (bestand.Extensie.ToLower() == ".jpg" || bestand.Extensie.ToLower() == ".png")
            {
                DownloadKnop.Text = "<img src=\"" + bestand.Pad + "\" style=\"max-width: 100%\" />";
            }
            else
            {
                DownloadKnop.Text = "Klik hier om het bestand te downloaden!";
            }
        }

        protected void DownloadKnop_Click(object sender, EventArgs e)
        {
            Bestand bestand = Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue));
            Response.Redirect(bestand.Pad);
        }

        protected void Like_Click(object sender, EventArgs e)
        {
            Bestand bestand = Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue));
            bestand.AddLike(this.persoon);
            this.UpdateBestand(bestand);
        }

        protected void Dislike_Click(object sender, EventArgs e)
        {
            Bestand bestand = Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue));
            bestand.AddDislike(this.persoon);
            this.UpdateBestand(bestand);
        }

        protected void Report_Click(object sender, EventArgs e)
        {
            Bestand bestand = Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue));
            bestand.AddReport(this.persoon);
            this.UpdateBestand(bestand);
        }
    }
}