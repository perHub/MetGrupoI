using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace ProyectoScrum
{
    public partial class gvHU : System.Web.UI.MasterPage
    {
        private static List<Historias> lstHistu;

        public static List<Historias> LstHistu
        {
            get { return lstHistu; }
            set { lstHistu = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            linkGrid();
        }

        public void linkGrid()
        {
            gvHU1.DataSource = lstHistu;
            gvHU1.DataBind();
        }

    }
}