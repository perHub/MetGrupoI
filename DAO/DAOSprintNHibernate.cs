using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using NHibernate;
using NHibernate.Criterion;

namespace DAO
{
    public class DAOSprintNHibernate: IDAO<Sprint>
    {
        private static DAOSprintNHibernate _instance;
        private DAOSprintNHibernate() { }

        public static DAOSprintNHibernate Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOSprintNHibernate();
            }
            return _instance;
        }

        public void agregar(Sprint data)
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));
            try
            {
                sesion.Save(data);
                sesion.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }
        }

        public void eliminar(Sprint data)
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));
            try
            {
                sesion.Delete(data);
                sesion.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }
        }

        public void modificar(int ID, Sprint data)
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));
            try
            {
                sesion.Update(data);
                sesion.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }
        }

        public Sprint buscarPorID(int ID)
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));
            Sprint oSpr;

            try
            {
                oSpr = sesion.Get<Sprint>(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }
            return oSpr;
        }

        public List<Sprint> traerTodos()
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));

            try
            {
               var sprints = sesion.CreateQuery("from Sprint").List<Sprint>();
               List<Sprint> lstSprint = (List<Sprint>)sprints;

               return lstSprint;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }

        }

        public List<Historia> SprintBackLog(Sprint miSprint)
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));
            try
            {
                var rtr = sesion.CreateCriteria(typeof(Historia))
                           .Add(Restrictions.Eq("oSprint.Id",miSprint.Id))
                           .List<Historia>();

                return (List <Historia>) rtr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }
        }

        public List<Sprint> sprintsPorProyecto(Proyecto oPro)
        {
            ISession sesion = NHHelper.openSession(typeof(Sprint));
            try
            {
                var rtr = sesion.CreateCriteria(typeof(Sprint))
                           .Add(Restrictions.Eq("Proyecto.Id",oPro.Id))
                           .List<Sprint>();

                return (List <Sprint>) rtr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sesion.Close();
            }
        }
    }


}
