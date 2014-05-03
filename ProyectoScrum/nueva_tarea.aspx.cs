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
                historiaDropDown.DataSource = null;
                historiaDropDown.DataSource = chistoria.historiasPorProyecto(((Proyecto)Session["ProyectoActual"]).Id);
                historiaDropDown.DataBind();

            }
            catch (Exception ex) { 
            
            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try{
                Historia historia = chistoria.historiaBYDescripcion(historiaDropDown.SelectedValue);
                ctarea.agregar(txtDesc.Text, Convert.ToDecimal(EstimacionTXT.Text),Calendar1.SelectedDate, Calendar2.SelectedDate, historia, "",(((UsuarioSistema)Session["UsuarioSistema"])));
            }catch (Exception ex){
                
            }
            //Response.Redirect("/sprint_actual.aspx");
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