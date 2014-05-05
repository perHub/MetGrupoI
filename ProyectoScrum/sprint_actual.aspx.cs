using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Entidades;

namespace ProyectoScrum
{
    public partial class sprint_actual : System.Web.UI.Page
    {
        CTarea ctarea = new CTarea();
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] a = new int[10];  //Códgigo de prueba para llenar la grilla.
            Random r = new Random();

            for (int i = 0; i < 9; i++)
            {
                a[i] = i * r.Next();
            }

            /*gvTareas.DataSource = null;
            gvTareas.DataSource = a;
            gvTareas.DataBind();*/

            gvTareas.DataSource = ctarea.buscarPorSprint(((Sprint)Session["SprintActual"]).Id);
            gvTareas.DataBind();
        }

        protected void gvTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row= gvTareas.SelectedRow;
            Session["idTareaSeleccionada"] = Convert.ToInt32(row.Cells[1]);
            Response.Redirect("/ModificarTarea.aspx");
        }

    }
}