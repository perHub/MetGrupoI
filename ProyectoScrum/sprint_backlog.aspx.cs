﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace ProyectoScrum
{
    public partial class sprint_backlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Historias> lstHU = (List<Historias>)Session["sprintBacklog"];
            lstHU.Clear();

            for (int i = 0; i < 5; i++)
            {
                Historias HU = new Historias(i, null, "Historia " + i, i * 5, 20 - i, 0, 0);
                lstHU.Add(HU);
            }
            gvHU.LstHistu = lstHU;
        }
    }
}