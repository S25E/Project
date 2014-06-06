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

        protected void UploadKnop_Click(object sender, EventArgs e)
        {
            FileInfo fileinfo = new FileInfo(FileUpload.PostedFile.FileName);
            string filelocatie = "/Files/" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "-" + fileinfo.Name;
            FileUpload.PostedFile.SaveAs(Server.MapPath(filelocatie));
            Bestand toUpload = new Bestand(Convert.ToInt32(Categorie.SelectedValue), BestandNaam.Text, Beschrijving.Text, fileinfo.Extension, FileUpload.PostedFile.ContentLength, "000039", DateTime.Now, 00, 0, filelocatie, 0);
            Map.GetMapBijNummer(Convert.ToInt32(Categorie.SelectedValue)).AddBestand(toUpload);
            Response.Redirect("/pages/Filesharing.aspx");
        }
    }
}