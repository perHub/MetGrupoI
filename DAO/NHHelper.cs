using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace DAO
{
    public class NHHelper
    {
        public static ISession openSession(System.Type tipoDeClase)
        {
            try
            {
                Configuration cfg = new Configuration().Configure();
                cfg.AddAssembly(tipoDeClase.Assembly);
                ISessionFactory fab_sesion = cfg.BuildSessionFactory();
                return fab_sesion.OpenSession();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
