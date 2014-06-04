using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SME
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Inloggen_Click(object sender, EventArgs e)
        {
            if (Persoon.Login(TextBoxGebruikersnaam.Text, TextBoxWachtwoord.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(TextBoxGebruikersnaam.Text, true);
            }
            else
            {
                Error.Visible = true;
            }
        }
    }
}