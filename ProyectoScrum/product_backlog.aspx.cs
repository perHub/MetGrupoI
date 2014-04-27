using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace ProyectoScrum
{
    public partial class product_backlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Historia> lstHU = (List<Historia>)Session["prodBacklog"];

            lstHU.Clear();

            for (int i = 0; i < 10; i++)
            {
                Historia HU = new Historia(i, null, "Historia " + i, i * 5, 20 - i, 0, 0);
                lstHU.Add(HU);
            }
            gvHU.LstHistu = lstHU;
        }
    }
}