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
    public partial class nueva_tarea : System.Web.UI.Page
    {
        CTarea ctarea = new CTarea();
        CHistoria chistoria = new CHistoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                historiaDropDown.DataTextField = "descripcion";
                historiaDropDown.DataValueField = "Id";
                historiaDropDown.DataSource = chistoria.historiasPorProyecto(((Proyecto)Session["ProyectoActual"]).Id);
                historiaDropDown.DataBind();
                error.Visible = true;
                error.Text = "el proyecto corriendo es :" + ((Proyecto)Session["ProyectoActual"]).Id.ToString();

            }
            catch (Exception ex) {
                error.Text = "excepcion";
            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try{
                Desarrollador desarrollador = new Desarrollador(5, "", 1, "", "", null);
                Historia historia = chistoria.buscarPorId(Convert.ToInt32(historiaDropDown.SelectedValue));
                ctarea.agregar(txtNom.Text, Convert.ToDecimal(EstimacionTXT.Text),Calendar1.SelectedDate, Calendar2.SelectedDate, historia,txtDesc.Text,desarrollador);
                Estado e1 = new Estado(1, "No iniciada");
                EstadoTarea et = new EstadoTarea(e1, e1, DateTime.Today, "");
                ctarea.agregarEstadoTareaConDesc(et, txtNom.Text);
            }catch (Exception ex){
                
            }
            Response.Redirect("/sprint_actual.aspx");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lbInicio.Text = "Fecha inicio:  " + Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            lbFin.Text = "Fecha fin:  " + Calendar2.SelectedDate.ToShortDateString();
        }
    }
}