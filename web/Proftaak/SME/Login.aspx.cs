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
                Persoon persoon = Persoon.GetPersoonBijRFID(TextBoxGebruikersnaam.Text);

                //FormsAuthentication.RedirectFromLoginPage(TextBoxGebruikersnaam.Text, true);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    TextBoxGebruikersnaam.Text, 
                    DateTime.Now,
                    DateTime.Now.AddMinutes(100),
                    false,
                    (persoon is Medewerker ? "Medewerker" : "Gebruiker"),
                    FormsAuthentication.FormsCookiePath
                );

                string hashCookies = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); 

                Response.Cookies.Add(cookie);

                string returnUrl = Request.QueryString["ReturnUrl"];

                if (returnUrl == null) returnUrl = "~/Default.aspx";

                Response.Redirect(returnUrl); 
            }
            else
            {
                Error.Visible = true;
            }
        }
    }
}