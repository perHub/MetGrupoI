using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOTarea: IDAO<Tarea>
    {
        private static DAOTarea _instance;
        DAOestados daoEstados = DAOestados.Instance();
        DAOHistoria daoHistoria = DAOHistoria.Instance();
        DAOUsuario_Sistema daoUsuarioSistema = DAOUsuario_Sistema.Instance();
        private DAOTarea()
        {
        }
        public static DAOTarea Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOTarea();
            }
            return _instance;
        }

        public void eliminar(Tarea tarea)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE tareas WHERE Id = @Id", Conexion.cn);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                //ahora los completo
                cmd.Parameters["@Id"].Value = tarea.Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexion.close();
            }
        }

        public void modificar(int id, Tarea tarea)
        {
            try
            {
                SqlCommand cmdModificar = new SqlCommand("UPDATE Tareas SET Descripcion=@Descripcion,Estimacion=@Estimacion,Inicio=@Inicio,Fin=@Fin,IdHistoria=@IdHistoria, IdUsuario_Sistema=@IdUsuario_Sistema, Observaciones=@Observaciones WHERE Id=@Id)", Conexion.cn);
                Conexion.open();
                //paso parametros
                cmdModificar.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar);
                cmdModificar.Parameters.Add("@Estimacion", System.Data.SqlDbType.Decimal);
                cmdModificar.Parameters.Add("@Inicio", System.Data.SqlDbType.DateTime);
                cmdModificar.Parameters.Add("@Fin", System.Data.SqlDbType.DateTime);
                cmdModificar.Parameters.Add("@IdHistoria", System.Data.SqlDbType.Int);
                cmdModificar.Parameters.Add("@IdUsuario_Sistema", System.Data.SqlDbType.Int);
                cmdModificar.Parameters.Add("@Observaciones", System.Data.SqlDbType.VarChar);
                cmdModificar.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                //ahora los completo
                cmdModificar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdModificar.Parameters["@Estimacion"].Value = tarea.Estimacion;
                cmdModificar.Parameters["@Inicio"].Value = tarea.Incio;
                cmdModificar.Parameters["@Fin"].Value = tarea.Fin;
                cmdModificar.Parameters["@IdHistoria"].Value = tarea.Historia.Id;
                cmdModificar.Parameters["@IdUsuario_Sistema"].Value = tarea.Owner.Id;
                cmdModificar.Parameters["@Id"].Value = tarea.Id;
                cmdModificar.Parameters["@Observaciones"].Value = tarea.Observaciones;
                cmdModificar.ExecuteNonQuery();
                Conexion.close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexion.close();
            }
        }


        public void agregar(Tarea tarea)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Tareas(Id,Descripcion,Estimacion,Inicio,Fin,IdHistoria, IdUsuario_Sistema, Observaciones) VALUES (@Id,@Descripcion,@Estimacion,@Inicio,@Fin,@IdHistoria, @IdUsuario_Sistema, @Observaciones)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Estimacion", System.Data.SqlDbType.Decimal);
                cmdAgregar.Parameters.Add("@Inicio", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Fin", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@IdHistoria", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@IdUsuario_Sistema", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@Observaciones", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@Id"].Value = tarea.Id;
                cmdAgregar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdAgregar.Parameters["@Estimacion"].Value = tarea.Estimacion;
                cmdAgregar.Parameters["@Inicio"].Value = tarea.Incio;
                cmdAgregar.Parameters["@Fin"].Value = tarea.Fin;
                cmdAgregar.Parameters["@IdHistoria"].Value = tarea.Historia.Id;
                cmdAgregar.Parameters["@IdUsuario_Sistema"].Value = tarea.Owner.Id;
                cmdAgregar.Parameters["@Observaciones"].Value = tarea.Observaciones;

                cmdAgregar.ExecuteNonQuery();
                Conexion.close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexion.close();
            }
        }

        public Tarea buscarPorID(int ID)
        {
            throw new NotImplementedException();
        }
        public List<Tarea> traerTodos()
        {
            throw new NotImplementedException();
        }

        public void agregarEstadoTarea(EstadoTarea et) {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Estados_Tareas(idEstadoAnterior,idEstadoActual,fecha,idTarea,observaciones) VALUES (@IdEstadoAnterior,@IdEstadoActual,@fecha,@idTarea,@observaciones)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@IdEstadoAnterior", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@IdEstadoActual", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@idTarea", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@observaciones", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@IdEstadoAnterior"].Value = et.EstadoAnterior;
                cmdAgregar.Parameters["@IdEstadoActual"].Value = et.EstadoActual;
                cmdAgregar.Parameters["@fecha"].Value = et.Fecha;
                cmdAgregar.Parameters["@idTarea"].Value = et.Tarea;
                cmdAgregar.Parameters["@observaciones"].Value = et.Observaciones;
                cmdAgregar.ExecuteNonQuery();
                Conexion.close();
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
        public List<EstadoTarea> buscarEstadosByIdTarea(int idTarea) {
            try
            {
                Conexion.open();
                
                SqlCommand query = new SqlCommand("select * from dbo.Estados_Tareas where idTarea=@id", Conexion.cn);
                query.Parameters.AddWithValue("@id", idTarea);
                query.Parameters["@id"].Value = idTarea; ;

                SqlDataReader reader = query.ExecuteReader();

                List<EstadoTarea> lstEstadoTarea = new List<EstadoTarea>();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Conexion.close();
                
                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    int idEstadoActual = Convert.ToInt32(dr["idEstadoActual"]);
                    int idEstadoAnterior = Convert.ToInt32(dr["idEstadoAnterior"]);
                    DateTime fecha = Convert.ToDateTime(dr["fecha"]);
                    String observaciones= Convert.ToString(dr["observaciones"]);
                    Estado actual = daoEstados.buscarPorID(idEstadoActual);
                    Estado anterior= daoEstados.buscarPorID(idEstadoAnterior);
                    EstadoTarea estadoTarea = new EstadoTarea(actual, anterior, fecha, idTarea, observaciones);
                    lstEstadoTarea.Add(estadoTarea);
                }

                return lstEstadoTarea;
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


        public List<Tarea> tareasByHistoria(int idHist)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Tareas where IdHistoria=@id");
                query.Parameters.AddWithValue("@id", idHist);

                SqlDataReader reader = query.ExecuteReader();

                DAOTarea DAOt = DAOTarea.Instance();
                DAOUsuario_Sistema DAOus = DAOUsuario_Sistema.Instance();

                List<Tarea> lstTareas = new List<Tarea>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string descripcion = reader.GetString(1);
                    decimal estimacion = reader.GetDecimal(2);
                    DateTime inicio = reader.GetDateTime(3);
                    DateTime fin = reader.GetDateTime(4);
                    int idHistoria = reader.GetInt32(5);
                    int idUsuario_sistema = reader.GetInt32(6);
                    String observaciones = reader.GetString(7);
                    Historia historia = daoHistoria.buscarPorID(idHistoria);
                    UsuarioSistema usuario = daoUsuarioSistema.buscarPorID(idUsuario_sistema);
                    Tarea tarea = new Tarea(id, descripcion, estimacion, fin, inicio, historia, observaciones, usuario);
                    lstTareas.Add(tarea);
                }

                return lstTareas;
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

    }
}
