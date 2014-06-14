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
    public partial class nueva_historia : System.Web.UI.Page
    {
        CHistoria historia = new CHistoria();
        CProyecto listProy = new CProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Proyecto oPro = new Proyecto();
            int nId = ((Proyecto)Session["ProyectoActual"]).Id;
            oPro = listProy.buscarPorId(nId);
            try
            {
                historia.agregar(txtDescripcion.Text, Convert.ToDecimal(txtEstimacion.Text), Convert.ToInt32(txtPrioridad.Text), oPro, Convert.ToInt32(txtNumero.Text));
                Response.Redirect("/product_backlog.aspx");
            }
            catch (Exception ex) { 
            
            }
        }
    }
}