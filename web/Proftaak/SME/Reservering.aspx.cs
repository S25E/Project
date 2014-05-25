using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SME
{
    public partial class Reservering1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            TbNaam.ForeColor = System.Drawing.Color.Green;
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            TbNaam.ForeColor = System.Drawing.Color.Red;
        }
    }
}