using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SME.pages
{
    public partial class Uploaden : System.Web.UI.Page
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

        protected void Uploaden_Click(object sender, EventArgs e)
        {
            FileInfo fileinfo = new FileInfo(Bladeren.PostedFile.ToString());
            Bestand toUpload = new Bestand(Convert.ToInt32(Categorie.SelectedValue),Naam.Text,Beschrijving.Text,fileinfo.Extension,Bladeren.PostedFile.ContentLength,Convert.ToString(000039),DateTime.Now,0,0,Bladeren.PostedFile.FileName,0);
            toUpload.Uploaden(toUpload.Pad);
        }
    }
}