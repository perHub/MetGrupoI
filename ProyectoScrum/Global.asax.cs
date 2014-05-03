using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Entidades;
using Controladora;

namespace ProyectoScrum
{
    public class Global : System.Web.HttpApplication
    {
        CProyecto conPro = new CProyecto();
        CSprint conSpr = new CSprint();
        CUsuario_sistema conUsuSis = new CUsuario_sistema();
        

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Declaro las variables de sesión acá para listar las que vamos a utilizar.
            try
            {
                Session["ProyectoActual"] = conPro.buscarPorId(1); //Hardcodeado.
                Session["SprintActual"] = conSpr.buscarPorId(1); //Hardcodeado.
                Session["UsuarioSistema"] = conUsuSis.buscarByID(5);
            }
            catch (Exception ex)
            {
                proyectos.Ex = ex;
                Response.Redirect("/proyectos.aspx");
            }
            Session["prodBacklog"] = new List<Historia>();
            Session["sprintBacklog"] = new List<Historia>();

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
