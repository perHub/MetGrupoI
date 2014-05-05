using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Entidades;

namespace Controladora
{
    public class CEstados
    {
        DAOestados daoEstados = DAOestados.Instance();
        public List<Estado> todosLosEstados() {
            return daoEstados.traerTodos();
        }
    }
}
