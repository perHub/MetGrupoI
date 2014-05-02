using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace ProyectoScrum
{
    public static class alert
    {
        public static void mostrarExAlert(Exception ex, Page page)
        {
            var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
            var script = string.Format("alert({0});", message);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "", script, true);
        }

        public static void mostrarStringAlert(String mensaje, Page page)
        {
            var message = new JavaScriptSerializer().Serialize(mensaje);
            var script = string.Format("alert({0});", message);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "", script, true);
        }
    }
}