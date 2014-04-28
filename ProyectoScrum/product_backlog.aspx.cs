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
            DateTime test = new DateTime();

            for (int i = 0; i < 10; i++)
            {
                Historia HU = new Historia(i, "Historia " + i, i * 5, 20 - i, null,null, test,test);
                lstHU.Add(HU);
            }
            gvHU.LstHistu = lstHU;
        }
    }
}