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

            // METHODE 1
            /*DropDownList1.DataSource = MateriaalCategorie.GetMateriaalCategorieen();
            DropDownList1.DataTextField = "Naam";
            DropDownList1.DataValueField = "Naam";
            DropDownList1.DataBind();*/

            // METHODE 2
            foreach (MateriaalCategorie materiaalcategorie in MateriaalCategorie.GetMateriaalCategorieen())
            {
                DropDownList1.Items.Add(materiaalcategorie.Naam);
            }

            // KIEST U ZELF MAR WAT U HET FIJNST VINDT.
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void rechts_Click(object sender, EventArgs e)
        {

        }
    }
}