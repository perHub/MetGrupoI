using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAO;

namespace Controladora
{
    public class CSprint
    {
       // DAOSprint DSpr = DAOSprint.Instance();
        DAOSprintNHibernate DSpr = DAOSprintNHibernate.Instance(); //DAO con NHibernate

        public Sprint buscarPorId(int id)
        {
            return DSpr.buscarPorID(id);
        }

        public void agregarHistorias(List<int> lstIds)
        {

        }

        public void agregarHistoria(Sprint oSpr, Historia oHist)//Terminar
        {
            oSpr.Historias.Add(oHist);
        }

        public List<Sprint> sprintsPorProyecto(Proyecto oPro)
        {
            return DSpr.sprintsPorProyecto(oPro);
        }
    }
}
