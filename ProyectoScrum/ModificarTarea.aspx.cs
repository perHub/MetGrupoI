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
        Tarea tarea;
        string nuevoEstado;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            tarea = ctarea.buscarPorID(id);
            txtNom.Text = tarea.Descripcion;
            EstimacionTXT.Text = Convert.ToString(tarea.Estimacion);
            txtDesc.Text = tarea.Descripcion;
            try{
            //DropEstados.SelectedIndex = -1;
            DropEstados.Items.FindByText(tarea.Estado).Selected = true;
            }catch (Exception ex){
            
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

        }
        public DateTime? verificarInicio()
        {
            DateTime? inicio = null;
            if (Calendar1.SelectedDate != Convert.ToDateTime(inicio))
            {
                inicio = Calendar1.SelectedDate;
            }
            return inicio;
        }

        public DateTime? verificarFin()
        {

            DateTime? fin = null;
            if (Calendar2.SelectedDate != fin.GetValueOrDefault())
            {
                fin = Calendar2.SelectedDate;
            }
            return fin;
        }


        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Historia historia = chistoria.buscarPorId(Convert.ToInt32(historiaDropDown.SelectedValue));
                Tarea tarea = new Tarea(txtNom.Text, Convert.ToDecimal(EstimacionTXT.Text), historia, txtDesc.Text, "");//falta levantar el estadoS
                ctarea.modificarConNulls(Convert.ToInt32(Session["idTareaSeleccionada"]), tarea);
                Estado e1 = new Estado(1, "No iniciada.");
                //Estado e2=
                EstadoTarea et = new EstadoTarea(e1, e1, DateTime.Today, "");
                ctarea.agregarEstadoTareaConDesc(et, txtNom.Text);
                ctarea.setEstado(DropEstados.SelectedItem.Text, Convert.ToInt32(Session["idTareaSeleccionada"]));

                if (verificarInicio() != null)
                {
                    ctarea.setFechaInicio(Convert.ToDateTime(verificarInicio()), ctarea.buscarTareaByDescripcion(txtNom.Text));
                }
                if (verificarFin() != null)
                {
                    ctarea.setFechaFin(Convert.ToDateTime(verificarFin()), ctarea.buscarTareaByDescripcion(txtNom.Text));
                }
            }
            catch (Exception ex)
            {
                alert.mostrarExAlert(ex, this);
            }
            Response.Redirect("/sprint_actual.aspx");
            
        }

        protected void DropEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropEstados.Items.FindByText(tarea.Estado).Selected = false;
            nuevoEstado = DropEstados.SelectedValue;
        }


    }
}