using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME.pages
{
    public partial class AddMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Mappicker.Items.Add(new ListItem("/","0"));
                foreach (Map map in BestandenCatalogus.Mappen)
                {
                    this.Mappicker.Items.Add(new ListItem(map.ToString(), map.Nummer.ToString()));
                }
            }
        }

        protected void K_Click(object sender, EventArgs e)
        {
            BestandenCatalogus.AddMap(new Map(this.Naam.Text,Convert.ToInt32(this.Mappicker.SelectedValue)));
            Response.Redirect("/pages/Filesharing.aspx");
        }
    }
}