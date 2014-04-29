using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAO;

namespace Controladora
{
    class gestionHistorias
    {
        DAOHistoria dHu = DAOHistoria.Instance();

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
