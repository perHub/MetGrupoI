using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using NHibernate;
using NHibernate.Cfg;

namespace DAO
{
    class DAOHistoriaNH:IDAO<Historia>
    {
       

        public void agregar(Historia data)
        {
           /* Configuration cfg = new Configuration().Configure();
            cfg.AddAssembly("Sprint");
            ISession sesion;
            ISessionFactory fab_sesion;*/
        }

        public void eliminar(Historia data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, Historia data)
        {
            throw new NotImplementedException();
        }

        public Historia buscarPorID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Historia> traerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
