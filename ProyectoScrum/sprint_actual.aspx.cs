using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoScrum
{
    public partial class sprint_actual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] a = new int[10];  //Códgigo de prueba para llenar la grilla.
            Random r = new Random();

            for (int i = 0; i < 9; i++)
            {
                a[i] = i * r.Next();
            }

            gvTareas.DataSource = null;
            gvTareas.DataSource = a;
            gvTareas.DataBind();
        }
    }
}