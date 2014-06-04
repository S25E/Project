using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SME
{
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page is Stap1)
            {
                step1.Attributes.Add("class", "active");
            }
            else if (this.Page is Stap2)
            {
                step2.Attributes.Add("class", "active");
            }
            else if (this.Page is Stap3)
            {
                step3.Attributes.Add("class", "active");
            }
            else if (this.Page is Stap4)
            {
                step4.Attributes.Add("class", "active");
            }

            if (Session["Stap1"] != null)
            {
                step1.Attributes.Add("class", "complete");
            }
            if (Session["Stap2"] != null)
            {
                step2.Attributes.Add("class", "complete");
            }
            if (Session["Stap3"] != null)
            {
                step3.Attributes.Add("class", "complete");
            }
            if (Session["Stap4"] != null)
            {
                step4.Attributes.Add("class", "complete");
            }
        }
    }
}