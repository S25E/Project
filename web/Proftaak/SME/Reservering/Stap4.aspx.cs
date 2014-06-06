using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Stap4 : System.Web.UI.Page
    {
        List<Materiaal> Barcodes;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["Stap3"] == null)
                {
                    Response.Redirect("Stap3.aspx");
                }
                else
                {
                    List<MateriaalCategorie> Categorieen = MateriaalCategorie.GetMateriaalCategorieen();
                    DropdownCategorieen.DataSource = Categorieen;
                    DropdownCategorieen.DataTextField = "Naam";
                    DropdownCategorieen.DataBind();

                    MateriaalCategorie categorie = new MateriaalCategorie(DropdownCategorieen.Text);
                    List<Materiaal> Materialen = Materiaal.GetMaterialenBijCategorie(categorie);
                    ListBoxMaterialen.DataSource = Materialen;
                    ListBoxMaterialen.DataValueField = "Barcode";
                    ListBoxMaterialen.DataTextField = "Naam";
                    ListBoxMaterialen.DataBind();

                    if(Session["Stap4"] != null)
                    {
                        ListboxGeselecteerd.DataSource = Session["Stap4"];
                        ListboxGeselecteerd.DataTextField = "Naam";
                        ListboxGeselecteerd.DataBind();
                    }
                }
            }
        }
        protected void Volgende_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stap5.aspx");
        }

        protected void LaadMaterialen(object sender, EventArgs e)
        {
            MateriaalCategorie categorie = new MateriaalCategorie(DropdownCategorieen.Text);
            List<Materiaal> Materialen = Materiaal.GetMaterialenBijCategorie(categorie);
            ListBoxMaterialen.DataSource = Materialen;
            ListBoxMaterialen.DataValueField = "Barcode";
            ListBoxMaterialen.DataTextField = "Naam";
            ListBoxMaterialen.DataBind();
        }

        protected void SelecteerMateriaal(object sender, EventArgs e)
        {
            Barcodes = (List<Materiaal>)Session["Stap4"];

            if(Barcodes  == null)
            {
                Barcodes = new List<Materiaal>();
            }

            Materiaal materiaal = Materiaal.GetMateriaalBijBarcode(ListBoxMaterialen.SelectedValue);
            Barcodes.Add(materiaal);
            Session["Stap4"] = Barcodes;
            Response.Redirect("Stap4.aspx");
        }
    }
}