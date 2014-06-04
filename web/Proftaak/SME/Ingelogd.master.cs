using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SME
{
    public partial class Ingelogd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.isIngelogd()){
                Server.Transfer("Login.aspx");
            }
        }

        private bool isIngelogd(){
            if(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Persoon persoon = Persoon.GetPersoonBijRFID(Context.User.Identity.Name);
                if(persoon == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}