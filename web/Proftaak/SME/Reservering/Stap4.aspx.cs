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
        List<Int32> Barcodes;
        List<string> Producten;
        
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
                        ListboxGeselecteerd.DataSource = Session["Producten"];
                        ListboxGeselecteerd.DataBind();
                    }
                }
            }
        }
        protected void Volgende_Click(object sender, EventArgs e)
        {
            //nog af maken, stored procedures aanroepen, of naar het overzicht gaan.

            Response.Write(Session["Stap1"]);
            Response.Write(Session["Stap2"]);
            Response.Write(Session["Stap3"]);
            Response.Write(Session["Stap4"]);
            Session["Stap1"] = null;
            Session["Stap2"] = null;
            Session["Stap3"] = null;
            Session["Stap4"] = null;
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
            Barcodes = (List<Int32>)Session["Stap4"];
            Producten = (List<string>)Session["producten"];

            if(Barcodes  == null)
            {
                Barcodes = new List<int>();
            }

            if(Producten == null)
            {
                Producten = new List<string>();
            }

            int barcode = Convert.ToInt32(ListBoxMaterialen.SelectedValue);
            Barcodes.Add(barcode);
            Session["Stap4"] = Barcodes;

            string productnaam = ListBoxMaterialen.SelectedItem.Text;
            Producten.Add(productnaam);
            Session["producten"] = Producten;
            Response.Redirect("Stap4.aspx");
        }
    }
}