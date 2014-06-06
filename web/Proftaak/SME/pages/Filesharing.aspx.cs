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
                this.setMap(0);
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
            if (LabelMap.Text != "Selecteer map:")
            {
                this.setMap(Convert.ToInt32(Categorie.SelectedValue));
            }
        }

        protected void setMap(int map_id)
        {
            Categorie.Items.Clear();
            Categorie.Items.Add("");
            foreach (Map map in BestandenCatalogus.Mappen)
            {
                Categorie.Items.Add(new ListItem(map.ToString() + " (" + map.Bestanden.Count + ")", map.Nummer.ToString()));
            }
            if (map_id != 0)
            {
                Categorie.SelectedValue = map_id.ToString();
            }
            LabelMap.Text = "Selecteer map:";
        }

        protected void setBestanden(int map_id)
        {
            Bestanden.Items.Clear();
            Bestanden.Items.Add("");
            foreach (Bestand bestand in Map.GetMapBijNummer(map_id).Bestanden)
            {
                Bestanden.Items.Add(new ListItem(bestand.Naam, bestand.Nummer.ToString()));
            }
            LabelBestand.Text = "Selecteer bestand:";
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
            if (LabelMap.Text != "Selecteer bestand:" && Bestanden.SelectedValue.ToString() != "")
            {
                int bestand_id = Convert.ToInt32(Bestanden.SelectedValue);
                int map_id = Bestand.GetBestand(bestand_id).MapNummer;
                this.setMap(map_id);
                this.setBestanden(map_id);
                Bestanden.SelectedValue = bestand_id.ToString();
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
            Downloads.Text = bestand.Gedownload.ToString();

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

            Reacties.DataSource = bestand.Reacties;
            Reacties.DataBind();
        }

        protected void DownloadKnop_Click(object sender, EventArgs e)
        {
            Bestand bestand = Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue));
            bestand.Download();
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

            if (bestand.Reports.Count > 3)
            {
                Response.Redirect("Filesharing.aspx");
            }
            else
            {
                this.UpdateBestand(bestand);
            }
        }

        protected void PlaatsReactie_Click(object sender, EventArgs e)
        {
            if (Reactie.Text != "")
            {
                Bestand bestand = Bestand.GetBestand(Convert.ToInt32(Bestanden.SelectedValue));
                bestand.AddReactie(new Reactie(this.persoon.Nummer, DateTime.Now, Reactie.Text));
                this.UpdateBestand(bestand);
                Reactie.Text = "";
            }
        }

        protected void ZoekKnop_Click(object sender, EventArgs e)
        {
            string zoekterm = Zoekterm.Text.ToLower();

            Categorie.Items.Clear();
            Categorie.Items.Add("");
            foreach (Map map in BestandenCatalogus.Mappen)
            {
                if (map.Naam.ToLower().IndexOf(zoekterm) != -1)
                {
                    Categorie.Items.Add(new ListItem(map.ToString() + " (" + map.Bestanden.Count + ")", map.Nummer.ToString()));
                }
            }

            Bestanden.Items.Clear();
            Bestanden.Items.Add("");
            foreach (Bestand bestand in Bestand.GetBestanden())
            {
                if (bestand.Naam.ToLower().IndexOf(zoekterm) != -1)
                {
                    Bestanden.Items.Add(new ListItem(bestand.Naam, bestand.Nummer.ToString()));
                }
            }

            LabelBestand.Text = "Gevonden bestanden:";
            LabelMap.Text = "Gevonden mappen:";
            PanelBestand.Visible = true;
        }

        protected void KnopNieuweMap_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMap.aspx");
        }

        protected void KnopNieuwBestand_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uploaden.aspx");
        }
    }
}