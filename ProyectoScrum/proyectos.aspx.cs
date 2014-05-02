using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoScrum
{
    public partial class proyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ex != null) //Esto sólo lo hago para mostrar las excepciones que vienen de Global.asax, se podrá eliminar en el futuro.
            {
                alert.mostrarExAlert(ex, this);
            }
        }
        static Exception ex;

        public static Exception Ex
        {
            get { return proyectos.ex; }
            set { proyectos.ex = value; }
        }
    }
}