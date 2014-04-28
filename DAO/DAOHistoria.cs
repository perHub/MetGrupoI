using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    class DAOHistoria:IDAO<Historia>
    {
        private static DAOHistoria _instance;

        private DAOHistoria()
        {
        }
        public static DAOHistoria Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOHistoria();
            }
            return _instance;
        }

        public void agregar(Historia data)
        {
            try
            {
                Conexion.open();

                string cmdtext = "insert into Historias(Descripcion, Estimacion, Prioridad, IdProyecto, IdSprint, Inicio, Fin) values (@desc, @est, @pri, @idpro, @idspr, @inicio, @fin)";

                SqlCommand query = new SqlCommand(cmdtext, Conexion.cn);


                query.Parameters.Add(new SqlParameter("@Desc", data.Descripcion));
                query.Parameters.Add(new SqlParameter("@est", data.Estimacion));
                query.Parameters.Add(new SqlParameter("@pri", data.Prioridad));
                query.Parameters.Add(new SqlParameter("@idpro", data.oProyecto.Id));
                query.Parameters.Add(new SqlParameter("@idspr", data.oSprint.Id));
                query.Parameters.Add(new SqlParameter("@inicio", data.Inicio.ToString()));
                query.Parameters.Add(new SqlParameter("@fin", data.Fin.ToString()));

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally{
                Conexion.close();
            }
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
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Historias where id=@ID");
                query.Parameters.Add(new SqlParameter("@ID",System.Data.SqlDbType.Int));
                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = new DAOSprint();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    String desc = reader.GetString(1);
                    decimal est = reader.GetDecimal(2);
                    int prio = reader.GetInt32(3);
                    Proyecto oPro = DAOPro.buscarPorID(reader.GetInt32(4));
                    Sprint oSpr = DAOSpr.buscarPorID(reader.GetInt32(5));
                    DateTime Inic = reader.GetDateTime(6);
                    DateTime Fin = reader.GetDateTime(7);

                    return new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin);
                }
                else throw new Exception("Esa historia no existe.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally{
                Conexion.close();
            }
        }

        public List<Historia> traerTodos()
        {
            throw new NotImplementedException();
        }

       /* public List<Historia> traerDependencias()
        {

        }*/
    }
}
