using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAO;

namespace Controladora
{
   public class CHistoria
    {
        DAOHistoria dHu = DAOHistoria.Instance();

       public void agregar(int id, string desc,decimal est, int prio,Proyecto oPro, Sprint oSpr,
                            DateTime Inic, DateTime Fin){
           Historia hu = new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin);

           dHu.agregar(hu);
   }

        public List<Historia> historiasPorProyecto(int idproyecto)
        {
            return dHu.historiasPorProyecto(idproyecto);
        }

        public List<Historia> historiaPorSrpint(int idspr)
        {
            return dHu.historiasPorSrpint(idspr);
        }

    }
}
