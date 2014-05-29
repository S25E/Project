using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private static string title = "SME -";
 
        public static string UpdateTitle(string toBeAddedTitle)
        {
            return title + " " + toBeAddedTitle;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}