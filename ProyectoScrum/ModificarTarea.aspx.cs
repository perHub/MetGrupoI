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
    public partial class ModificarTarea : System.Web.UI.Page
    {
        CHistoria chistoria = new CHistoria();
        CEstados cestados = new CEstados();
        CTarea ctarea = new CTarea();
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Text = Convert.ToString(Session["idTareaSeleccionada"]);
            historiaDropDown.DataTextField = "descripcion";
            historiaDropDown.DataValueField = "Id";
            historiaDropDown.DataSource = chistoria.historiasPorProyecto(((Proyecto)Session["ProyectoActual"]).Id);
            historiaDropDown.DataBind();

            DropEstados.DataTextField = "nombre";
            DropEstados.DataValueField = "id";
            DropEstados.DataSource = cestados.todosLosEstados();
            DropEstados.DataBind();

            mostrarDatos(Convert.ToInt32(Session["idTareaSeleccionada"]));
        }
        public void mostrarDatos(int id) {
            Tarea tarea = ctarea.buscarPorID(id);
            txtNom.Text = tarea.Descripcion;
            EstimacionTXT.Text = Convert.ToString(tarea.Estimacion);
            txtDesc.Text = tarea.Descripcion;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {

        }
    }
}