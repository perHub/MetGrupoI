using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DAOHistoria:IDAO<Historia>
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
            try
            {
                Conexion.open();

                string cmdtext = "update set Historias Descripcion=@desc, Estimacion=@est, Prioridad=@pri, IdProyecto=@idpro,"+
                                            "IdSprint=@idspr, Inicio=@inicio, Fin=@fin where id=@id";

                SqlCommand query = new SqlCommand(cmdtext, Conexion.cn);

                query.Parameters.Add(new SqlParameter("@id", data.Id));
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


        public Historia buscarPorID(int ID)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Historias where id=@ID");
                query.Parameters.Add(new SqlParameter("@ID",System.Data.SqlDbType.Int));
                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    String desc = reader.GetString(1);
                    decimal est = reader.GetDecimal(2);
                    int prio = reader.GetInt32(3);
                    int nIdProy = reader.GetInt32(4);
                    Conexion.close();
                    Proyecto oPro = DAOPro.buscarPorID(nIdProy);
                    int nIdSpr = reader.GetInt32(5);
                    Sprint oSpr = DAOSpr.buscarPorID(nIdSpr);
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
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Historias");
                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                List<Historia> lstHu = new List<Historia>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    String desc = reader.GetString(1);
                    decimal est = reader.GetDecimal(2);
                    int prio = reader.GetInt32(3);
                    int nIdProy = reader.GetInt32(4);
                    Conexion.close();
                    Proyecto oPro = DAOPro.buscarPorID(nIdProy);
                    int nIdSpr = reader.GetInt32(5);
                    Conexion.close();
                    Sprint oSpr = DAOSpr.buscarPorID(nIdSpr);
                    DateTime Inic = reader.GetDateTime(6);
                    DateTime Fin = reader.GetDateTime(7);

                    Historia hu = new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin);
                    lstHu.Add(hu);
                }

                return lstHu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.close();
            }
        }

        public List<Historia> historiasPorProyecto(int idproyecto)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Historias where FIN IS NULL AND IdProyecto=@id", Conexion.cn);
                query.Parameters.AddWithValue("@id", idproyecto);
                query.Parameters["@id"].Value = idproyecto; ;

                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                List<Historia> lstHu = new List<Historia>();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    String desc = Convert.ToString(dr["Descripcion"]);
                    decimal est = Convert.ToDecimal(dr["Estimacion"]);
                    int prio = Convert.ToInt32(dr["Prioridad"]);
                    Proyecto oPro = DAOPro.buscarPorID(Convert.ToInt32(dr["IdProyecto"]));
                    Sprint oSpr = DAOSpr.buscarPorID(Convert.ToInt32(dr["IdSprint"]));
                    DateTime Inic = Convert.ToDateTime(dr["Inicio"]);
                    DateTime Fin = Inic.AddMonths(1);
                    Historia hu = new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin);
                    lstHu.Add(hu);
                }

                return lstHu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.close();
            }
        }

        public List<Historia> historiasPorSrpint(int idsprint)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Historias where IdProyecto=@id");
                query.Parameters.AddWithValue("@id", idsprint);

                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                List<Historia> lstHu = new List<Historia>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    String desc = reader.GetString(1);
                    decimal est = reader.GetDecimal(2);
                    int prio = reader.GetInt32(3);
                    Proyecto oPro = DAOPro.buscarPorID(reader.GetInt32(4));
                    Sprint oSpr = DAOSpr.buscarPorID(reader.GetInt32(5));
                    DateTime Inic = reader.GetDateTime(6);
                    DateTime Fin = reader.GetDateTime(7);

                    Historia hu = new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin);
                    lstHu.Add(hu);
                }

                return lstHu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.close();
            }
        }

        /*public List<Historia> retornarHistoriasQuery(String Sqlquery)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand(Sqlquery);
                query.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.Int));
                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = new DAOSprint();

                List<Historia> lstHu = new List<Historia>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    String desc = reader.GetString(1);
                    decimal est = reader.GetDecimal(2);
                    int prio = reader.GetInt32(3);
                    Proyecto oPro = DAOPro.buscarPorID(reader.GetInt32(4));
                    Sprint oSpr = DAOSpr.buscarPorID(reader.GetInt32(5));
                    DateTime Inic = reader.GetDateTime(6);
                    DateTime Fin = reader.GetDateTime(7);

                    Historia hu = new Historia(id, desc, est, prio, oPro, oSpr, Inic, Fin);
                    lstHu.Add(hu);
                }

                return lstHu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.close();
            }*/
        }
       /* public List<Historia> traerDependencias()
        {

        }*/
    }

