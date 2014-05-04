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

                string cmdtext = "insert into Historias(Descripcion, Estimacion, Prioridad, IdProyecto, Numero) values (@desc, @est, @pri, @idpro, @num)";

                SqlCommand query = new SqlCommand(cmdtext, Conexion.cn);


                query.Parameters.Add(new SqlParameter("@Desc", data.Descripcion));
                query.Parameters.Add(new SqlParameter("@est", data.Estimacion));
                query.Parameters.Add(new SqlParameter("@pri", data.Prioridad));
                query.Parameters.Add(new SqlParameter("@idpro", data.oProyecto.Id));
                query.Parameters.Add(new SqlParameter("@num", data.Numero));

                query.Parameters["@desc"].Value = data.Descripcion;
                query.Parameters["@est"].Value = data.Estimacion;
                query.Parameters["@pri"].Value = data.Prioridad;
                query.Parameters["@idpro"].Value = data.oProyecto.Id;
                query.Parameters["@num"].Value = data.Numero;

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

                Boolean tieneSprint = data.oSprint != null;
                Boolean tieneInicio = data.Inicio != Convert.ToDateTime(null);
                Boolean tieneFin = data.Fin != Convert.ToDateTime(null);

                string qparams= "update Historias set Descripcion=@desc, Estimacion=@est, Prioridad=@pri, IdProyecto=@idpro,"+
                                             "Numero=@Num";
                if (tieneSprint)
                    qparams += ",IdSprint=@idspr";
                if (tieneInicio)
                    qparams += ",Inicio=@inicio";
                if (tieneFin)
                    qparams += ",Fin=@fin";

                string cmdtext = qparams + " where id=@id";

                SqlCommand query = new SqlCommand(cmdtext, Conexion.cn);

                query.Parameters.Add(new SqlParameter("@id", data.Id));
                query.Parameters.Add(new SqlParameter("@Desc", data.Descripcion));
                query.Parameters.Add(new SqlParameter("@est", data.Estimacion));
                query.Parameters.Add(new SqlParameter("@pri", data.Prioridad));
                query.Parameters.Add(new SqlParameter("@idpro", data.oProyecto.Id));
                query.Parameters.Add(new SqlParameter("@Num", data.Numero));

                if(tieneSprint)
                    query.Parameters.Add(new SqlParameter("@idspr", data.oSprint.Id));
                if(tieneInicio)
                    query.Parameters.Add(new SqlParameter("@inicio", data.Inicio.ToString("yyyy/MM/dd")));
                if(tieneFin)
                    query.Parameters.Add(new SqlParameter("@fin", data.Fin.ToString("yyyy/MM/dd")));

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

                SqlCommand query = new SqlCommand("select * from Historias where id=@ID", Conexion.cn);
                query.Parameters.Add(new SqlParameter("@ID",ID));
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
                    int nIdSpr = -1;
                    Boolean tieneSprint = !reader.IsDBNull(5);
                    DateTime Inic = new DateTime();
                    DateTime Fin = new DateTime();
                    int num = reader.GetInt32(8);

                    Boolean existeInicio = !reader.IsDBNull(6);
                    Boolean existeFin = !reader.IsDBNull(7);

                    if (tieneSprint)
                        nIdSpr = reader.GetInt32(5);
                    if(existeInicio)
                        Inic = reader.GetDateTime(6);
                    if (existeFin)
                        Fin = reader.GetDateTime(7);


                    Conexion.close();

                    Proyecto oPro = DAOPro.buscarPorID(nIdProy);

                    Historia hu = new Historia(id, desc, est, prio, oPro, num);

                    if (tieneSprint)
                        hu.oSprint = DAOSpr.buscarPorID(nIdSpr);

                    if (existeInicio)
                        hu.Inicio = Inic;

                    if (existeFin)
                        hu.Fin = Fin;


                    return hu;
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

       /* public List<Historia> traerTodos() 
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
        }*/

        public List<Historia> historiasPorProyecto(int idproyecto)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Historias where Idproyecto=@id", Conexion.cn);
                query.Parameters.AddWithValue("@id", idproyecto);
                query.Parameters["@id"].Value = idproyecto; ;

                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                List<Historia> lstHu = new List<Historia>();

                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    String desc = Convert.ToString(dr["Descripcion"]);
                    decimal est = Convert.ToDecimal(dr["Estimacion"]);
                    int prio = Convert.ToInt32(dr["Prioridad"]);
                    Proyecto oPro = DAOPro.buscarPorID(Convert.ToInt32(dr["IdProyecto"]));
                    int num = Convert.ToInt32(dr["Numero"]);

                    //Guardo las comprobaciones.
                    Boolean tieneSprint = dr["IdSprint"] != DBNull.Value;
                    Boolean existeInicio = dr["Inicio"] != DBNull.Value;
                    Boolean existeFin = dr["Fin"] != DBNull.Value;

                    Historia hu = new Historia(id, desc, est, prio, oPro, num);

                    if (tieneSprint)
                        hu.oSprint = DAOSpr.buscarPorID(Convert.ToInt32(dr["IdSprint"]));

                    if (existeInicio)
                        hu.Inicio = Convert.ToDateTime(dr["Inicio"]);

                    if (existeFin)
                        hu.Fin = Convert.ToDateTime(dr["Fin"]);


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

                SqlCommand query = new SqlCommand("select * from Historias where IdSprint=@id", Conexion.cn);
                query.Parameters.AddWithValue("@id", idsprint);
                query.Parameters["@id"].Value = idsprint; ;

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
                    int num = Convert.ToInt32(dr["Numero"]);

                    //Guardo las comprobaciones.
                    Boolean tieneSprint = dr["IdSprint"] != DBNull.Value;
                    Boolean existeInicio = dr["Inicio"] != DBNull.Value;
                    Boolean existeFin = dr["Fin"] != DBNull.Value;

                    Historia hu = new Historia(id, desc, est, prio, oPro, num);

                    if (tieneSprint)
                        hu.oSprint = DAOSpr.buscarPorID(Convert.ToInt32(dr["IdSprint"]));

                    if (existeInicio)
                        hu.Inicio = Convert.ToDateTime(dr["Inicio"]);

                    if (existeFin)
                        hu.Fin = Convert.ToDateTime(dr["Fin"]);


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
        public Historia historiaBYString(String descrip) {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from historias where descripcion=@descripcion");
                query.Parameters.Add(new SqlParameter("@descripcion", System.Data.SqlDbType.VarChar));
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
                    int nIdSpr = -1;
                    Boolean tieneSprint = !reader.IsDBNull(5);
                    DateTime Inic = new DateTime();
                    DateTime Fin = new DateTime();
                    int num = reader.GetInt32(8);

                    Boolean existeInicio = !reader.IsDBNull(6);
                    Boolean existeFin = !reader.IsDBNull(7);

                    if (tieneSprint)
                        nIdSpr = reader.GetInt32(5);
                    if (existeInicio)
                        Inic = reader.GetDateTime(6);
                    if (existeFin)
                        Fin = reader.GetDateTime(7);


                    Conexion.close();

                    Proyecto oPro = DAOPro.buscarPorID(nIdProy);

                    Historia hu = new Historia(id, desc, est, prio, oPro, num);

                    if (tieneSprint)
                        hu.oSprint = DAOSpr.buscarPorID(nIdSpr);

                    if (existeInicio)
                        hu.Inicio = Inic;

                    if (existeFin)
                        hu.Fin = Fin;


                    return hu;
                }
                else throw new Exception("Esa historia no existe.");
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


        public List<Historia> traerTodos()
        {
            throw new NotImplementedException();
        }
    }
       /* public List<Historia> traerDependencias()
        {

        }*/
    }

