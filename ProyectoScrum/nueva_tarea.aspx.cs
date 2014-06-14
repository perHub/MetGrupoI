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
                  }
            catch (Exception ex) {
                throw ex;
            }

        }
        public DateTime? verificarInicio() {
            DateTime? inicio = null;
            if (Calendar1.SelectedDate != Convert.ToDateTime(inicio))
            {
                inicio = Calendar1.SelectedDate;
            }
            return inicio;
        }

        public DateTime? verificarFin(){

            DateTime? fin = null;
            if (Calendar2.SelectedDate != fin.GetValueOrDefault())
            {
                fin = Calendar2.SelectedDate;
            }
            return fin;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try{
                Historia historia = chistoria.buscarPorId(Convert.ToInt32(historiaDropDown.SelectedValue));
                ctarea.agregar(txtNom.Text, Convert.ToDecimal(EstimacionTXT.Text), historia, txtDesc.Text);
                Estado e1 = new Estado(1, "No iniciada");
                EstadoTarea et = new EstadoTarea(e1, e1, DateTime.Today, "");
                ctarea.agregarEstadoTareaConDesc(et, txtNom.Text);
                if (verificarInicio() != null) { 
                    ctarea.setFechaInicio(Convert.ToDateTime(verificarInicio()),ctarea.buscarTareaByDescripcion(txtNom.Text));
                }
                if (verificarFin() != null) { 
                    ctarea.setFechaFin(Convert.ToDateTime(verificarFin()),ctarea.buscarTareaByDescripcion(txtNom.Text));
                }
            }catch (Exception ex){
                alert.mostrarExAlert(ex, this);
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