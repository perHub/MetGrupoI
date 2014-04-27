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
        private static List<Historia> lstHistu;

        public static List<Historia> LstHistu
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
            gvHU1.DataSource = null;
            gvHU1.DataSource = lstHistu;
            gvHU1.DataBind();
        }

    }
}