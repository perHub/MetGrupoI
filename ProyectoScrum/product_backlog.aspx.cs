using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Controladora;

namespace ProyectoScrum
{
    public partial class product_backlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CHistoria CHU = new CHistoria();

            List<Historia> lstHU = (List<Historia>)Session["prodBacklog"];

            /*lstHU.Clear();
            
            DateTime test = new DateTime();

            for (int i = 0; i < 10; i++)
            {
                Historia HU = new Historia(i, "Historia " + i, i * 5, 20 - i, null,null, test,test);
                lstHU.Add(HU);
            }*/

            gvHU.LstHistu = CHU.historiasPorProyecto(((Proyecto)Session["ProyectoActual"]).Id);

            linkDropDown();

        }

        private void linkDropDown()
        {
            CSprint cSpr = new CSprint();
            DDSprs.DataSource = null;
            DDSprs.DataSource = cSpr.sprintsPorProyecto((Proyecto)Session["ProyectoActual"]);
            DDSprs.DataBind();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            GridView gvAct = gvHU.gridActual;
            List<int> lstids = new List<int>();

            foreach (GridViewRow item in gvAct.Rows)
            {
                CheckBox Sel = (CheckBox) item.FindControl("chkSel");

                if (Sel.Checked)
                {
                    Label lblid = (Label)item.FindControl("lblId");
                    lstids.Add(Convert.ToInt32(lblid.Text));
                }
            }

            //Llamar metodo controladora
        }
    }
}