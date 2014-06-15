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
                            DateTime Inic, DateTime Fin, int num){
           Historia hu = new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin, num);

           dHu.agregar(hu);
   }

       public void agregar(string desc, decimal est, int prio, Proyecto oPro, int Num)
       {
           
             if(desc == null || oPro==null ){
                throw new Exception("no se puede guardar revise campos");
            }
             Historia h = dHu.historiaBYString(desc, oPro.Id);
             if (h != null && oPro.Id == h.oProyecto.Id) {
                 throw new Exception("ya existe historia con esa descripcion");
             }
           Historia hu = new Historia(desc, est, prio, oPro, Num);

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
        public Historia historiaBYDescripcion(String descripcion,int idP) {
            return dHu.historiaBYString(descripcion,idP);
        }

        public Historia buscarPorId(int id)
        {
            return dHu.buscarPorID(id);
        }
        public void asignarSprint(Historia oHu, Sprint oSpr) // oSpr debe ser null para restaurarla a no asignada en caso de ser necesario.
        {
            if (oSpr != null)
            {
                oHu.oSprint = oSpr;
               
            }
            else
            {
                oHu.oSprint = null;
            }

            dHu.modificar(oHu.Id, oHu);
        }

    }
}
