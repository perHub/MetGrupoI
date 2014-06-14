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
            try
            {
                CHistoria CHU = new CHistoria();

                List<Historia> lstHU = (List<Historia>)Session["prodBacklog"];

                gvHU.LstHistu = CHU.historiasPorProyecto(((Proyecto)Session["ProyectoActual"]).Id);

                linkDropDown();
            }
            catch (Exception ex)
            {
                alert.mostrarExAlert(ex, this);
            }

        }

        private void linkDropDown()
        {
            if (!Page.IsPostBack)
            {
                CSprint cSpr = new CSprint();
                DDSprs.DataSource = null;
                DDSprs.DataSource = cSpr.sprintsPorProyecto((Proyecto)Session["ProyectoActual"]);
                DDSprs.DataBind();
            }

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
                try
                {
                    CHistoria cHu = new CHistoria();
                    CSprint cSpr = new CSprint();

                    Sprint oSpr = cSpr.buscarPorId(Convert.ToInt32(DDSprs.SelectedValue));

                    GridView gvAct = gvHU.gridActual;
                    List<Historia> lstHu = new List<Historia>();

                    foreach (GridViewRow item in gvAct.Rows)        //Obtengo HUs seleccionadas.
                    {
                        CheckBox Sel = (CheckBox)item.FindControl("chkSel");

                        if (Sel.Checked)
                        {
                            Label lblid = (Label)item.FindControl("lblId");
                            lstHu.Add(cHu.buscarPorId(Convert.ToInt32(lblid.Text)));
                        }
                    }

                    if (lstHu.Count > 0)
                    {
                        foreach (Historia oHu in lstHu) // Las asigno al sprint.
                        {
                            cHu.asignarSprint(oHu, oSpr);
                        }
                        alert.mostrarStringAlert("Historia asignada correctamente.", this);
                    }
                    else
                        alert.mostrarStringAlert("Por favor seleccione una historia.", this);

                }

                catch (Exception ex)
                {
                    alert.mostrarExAlert(ex, this);
                }
        }
    }
}