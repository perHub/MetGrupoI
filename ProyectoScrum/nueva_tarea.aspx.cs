using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace ProyectoScrum
{
    public partial class nueva_tarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CTarea ctarea;
            historiaDropDown.DataSource = null;
            //historiaDropDown.DataSource = ctarea.lista
            historiaDropDown.DataBind();

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            //Creación del objeto.

            Response.Redirect("/sprint_actual.aspx");
        }

    }
}