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
                Conexion.open();

                SqlCommand cmd = new SqlCommand("DELETE from tareas WHERE Id = @Id", Conexion.cn);
                cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                //ahora los completo
                cmd.Parameters["@Id"].Value = tarea.Id;
                cmd.ExecuteNonQuery();
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

        public void modificar(int id, Tarea tarea)
        {
            try
            {
                int? idUsr = (int?)ejecutarSQL_Scalar("select idusuario_sistema from Tareas where id=" + tarea.Id);

                if (idUsr != null && idUsr != tarea.Owner.Id)
                    throw new noPuedeCambiarseResponsableException();

                SqlCommand cmdModificar = new SqlCommand("UPDATE Tareas SET Descripcion=@Descripcion,Estimacion=@Estimacion,Inicio=@Inicio,Fin=@Fin,IdHistoria=@IdHistoria, IdUsuario_Sistema=@IdUsuario_Sistema, Observaciones=@Observaciones,@estado=estado WHERE Id=@Id)", Conexion.cn);
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
                cmdModificar.Parameters.Add("@estado", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdModificar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdModificar.Parameters["@Estimacion"].Value = tarea.Estimacion;
                cmdModificar.Parameters["@Inicio"].Value = tarea.Incio;
                cmdModificar.Parameters["@Fin"].Value = tarea.Fin;
                cmdModificar.Parameters["@IdHistoria"].Value = tarea.Historia.Id;
                cmdModificar.Parameters["@IdUsuario_Sistema"].Value = tarea.Owner.Id;
                cmdModificar.Parameters["@Id"].Value = tarea.Id;
                cmdModificar.Parameters["@Observaciones"].Value = tarea.Observaciones;
                cmdModificar.Parameters["@estado"].Value = tarea.Estado;
                cmdModificar.ExecuteNonQuery();
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


        public void agregar(Tarea tarea) //Agregué unas comprobaciones para que el test funcionara, 
                                         // lo ideal sería rehacer este método para que sólo inserte una tarea "básica", (sin el IdUsuarioSistema, ni Inicio, ni Fin, como lo hablamos en clase)
                                         // Tener en cuenta que el cammpo IdUsuarioSIstema en la BD debe aceptar nulls (actualmente no es así)
        {
            try
            {
                Conexion.open();

                Boolean tieneOwner = tarea.Owner != null;
                Boolean tieneInicio = tarea.Incio != null;
                Boolean tieneFin = tarea.Fin != null;

                String cmd = "INSERT INTO Tareas(Descripcion,Estimacion,IdHistoria, Observaciones, estado"; //Valores que siempre deberán estar disponibles (no nulos).

                //Cmprobaciones:

                if (tieneOwner)
                    cmd += ", IdUsuario_Sistema";
                if (tieneInicio)
                    cmd += ", Inicio";
                if (tieneFin)
                    cmd += ", Fin";

                cmd += ") values (@Descripcion,@Estimacion,@IdHistoria, @Observaciones, @estado";

                if (tieneOwner)
                    cmd += ", @IdUsuario_Sistema";
                if (tieneInicio)
                    cmd += ", @Inicio";
                if (tieneFin)
                    cmd += ", @Fin";

                cmd += ")";

                SqlCommand cmdAgregar = new SqlCommand(cmd, Conexion.cn);


                //paso parametros
                cmdAgregar.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Estimacion", System.Data.SqlDbType.Decimal);
                cmdAgregar.Parameters.Add("@IdHistoria", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@Observaciones", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@estado", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@estado"].Value = "No iniciada";
                cmdAgregar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdAgregar.Parameters["@Estimacion"].Value = tarea.Estimacion;
                cmdAgregar.Parameters["@IdHistoria"].Value = tarea.Historia.Id;
                cmdAgregar.Parameters["@Observaciones"].Value = tarea.Observaciones;

                if (tieneOwner)
                {
                    cmdAgregar.Parameters.Add("@IdUsuario_Sistema", System.Data.SqlDbType.Int);
                    cmdAgregar.Parameters["@IdUsuario_Sistema"].Value = tarea.Owner.Id;
                }
                if (tieneInicio)
                {
                    cmdAgregar.Parameters.Add("@Inicio", System.Data.SqlDbType.DateTime);
                    cmdAgregar.Parameters["@Inicio"].Value = tarea.Fin;
                }

                if (tieneFin)
                {
                    cmdAgregar.Parameters.Add("@Fin", System.Data.SqlDbType.DateTime);
                    cmdAgregar.Parameters["@Fin"].Value = tarea.Fin;
                }

                cmdAgregar.ExecuteNonQuery();



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

        public Tarea buscarPorID(int ID)
        {
            try{
                Conexion.open();
                SqlCommand query = new SqlCommand("select * from Tareas where Id=@id;", Conexion.cn);
                query.Parameters.AddWithValue("@id", ID);
                query.Parameters["@id"].Value = ID; ;

                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                Tarea tarea = new Tarea();

                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    String desc = Convert.ToString(dr["Descripcion"]);
                    decimal est = Convert.ToDecimal(dr["Estimacion"]);
                    int idHistoria = Convert.ToInt32(dr["idHistoria"]);
                    string observaciones=Convert.ToString(dr["observaciones"]);
                    String estado = Convert.ToString(dr["estado"]);

                    //Guardo las comprobaciones.
                    Boolean tieneInicio = dr["Inicio"] != DBNull.Value;
                    Boolean tieneFin = dr["Fin"] != DBNull.Value;
                    Boolean tieneusu = dr["idUsuario_Sistema"] != DBNull.Value;
                    Historia historia = daoHistoria.buscarPorID(Convert.ToInt32(dr["idHistoria"]));
                    tarea = new Tarea(id, desc, est, historia, observaciones,estado);

                    if (tieneInicio)
                        tarea.Incio = Convert.ToDateTime(dr["inicio"]);

                    if (tieneFin)
                        tarea.Fin = Convert.ToDateTime(dr["Fin"]);

                    if (tieneusu)
                        tarea.Owner = daoUsuarioSistema.buscarPorID(Convert.ToInt32(dr["idUsuario_Sistema"]));

                }

                return tarea;
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
        public List<Tarea> traerTodos()
        {
            throw new NotImplementedException();
        }

        public object ejecutarSQL_Scalar(string cmdtext)
        {
            SqlCommand cmd = new SqlCommand(cmdtext, Conexion.cn);
            Conexion.open();

            object res = cmd.ExecuteScalar();               //Se necesitará castear.
            Conexion.close();
            return res;                                     //Retorna el escalar (que será un valor cualquieradela BD(ID,Nombre, etc.)).
        }
        public Boolean estadoTareaExisteEnEseMomento(EstadoTarea et)
        {
            int cont = (int)ejecutarSQL_Scalar("select count(id) from Estados_Tareas where Feha=' " + et.Fecha.ToString("MM/dd/yyyy HH:mm:ss.fff") + "' and IdTarea=" + et.oTarea.Id);

            return cont > 0;
        }

        public void eliminarEstadoPorFecha(EstadoTarea et) //También tiene encuenta el idtarea
        {
            String cmdtext = "delete from Estados_Tareas where idtarea=" + et.oTarea.Id + " and Feha='" + et.Fecha.ToString("MM/dd/yyyy HH:mm:ss.fff") + "'";
            SqlCommand cmd = new SqlCommand(cmdtext, Conexion.cn);
            Conexion.open();
            cmd.ExecuteNonQuery();
            Conexion.close();
        }
        public void agregarEstadoTarea(EstadoTarea et) {
            try
            {
               
                if (estadoTareaExisteEnEseMomento(et))
                {
                    throw new YaPoseeEstadoEnEseMomentoException();
                }

                Conexion.open();

                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Estados_Tareas(idEstadoAnterior,idEstadoActual,feha,idTarea,observaciones) VALUES (@IdEstadoAnterior,@IdEstadoActual,@fecha,@idTarea,@observaciones)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@IdEstadoAnterior", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@IdEstadoActual", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@idTarea", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@observaciones", System.Data.SqlDbType.VarChar);

                cmdAgregar.Parameters["@IdEstadoAnterior"].Value = et.EstadoAnterior.Id;
                cmdAgregar.Parameters["@IdEstadoActual"].Value = et.EstadoActual.Id;
                cmdAgregar.Parameters["@fecha"].Value = et.Fecha;
                cmdAgregar.Parameters["@idTarea"].Value = et.oTarea.Id;
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
        public void agregarEstadoTareaConNombre(EstadoTarea et, string descripcion) // Preguntar sobre este método.
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Estados_Tareas(idEstadoAnterior,idEstadoActual,feha,idTarea,observaciones) VALUES (@IdEstadoAnterior,@IdEstadoActual,@fecha,@idTarea,@observaciones)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@IdEstadoAnterior", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@IdEstadoActual", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@idTarea", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@observaciones", System.Data.SqlDbType.VarChar);

                cmdAgregar.Parameters["@IdEstadoAnterior"].Value = et.EstadoAnterior.Id;
                cmdAgregar.Parameters["@IdEstadoActual"].Value = et.EstadoActual.Id;
                cmdAgregar.Parameters["@fecha"].Value = et.Fecha;
                cmdAgregar.Parameters["@idTarea"].Value = this.buscaIDporDescripcion(descripcion);
                cmdAgregar.Parameters["@observaciones"].Value = et.Observaciones;
                Conexion.open();
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
        public int buscaIDporDescripcion(String descripcion) {
            try{
              
                Conexion.open();
                int idInsertado = new int();
                SqlCommand query = new SqlCommand("select id from Tareas where Descripcion=@descripcion;", Conexion.cn);
                query.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
                query.Parameters["@descripcion"].Value = descripcion;
                SqlDataReader reader = query.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                foreach (DataRow dr in dt.Rows)
                {

                    idInsertado = Convert.ToInt32(dr["id"]);
                }
                return idInsertado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
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
                    Tarea oTarea = buscarPorID(idTarea);
                    EstadoTarea estadoTarea = new EstadoTarea(actual, anterior, fecha, oTarea, observaciones);
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


/*       public List<Tarea> tareasByHistoria(int idHist)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Tareas where IdHistoria=@id", Conexion.cn);
                query.Parameters.AddWithValue("@id", idHist);
                query.Parameters["@id"].Value = idHist; ;

                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                List<Tarea> lstTarea = new List<Tarea>();

                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    String desc = Convert.ToString(dr["Descripcion"]);
                    decimal est = Convert.ToDecimal(dr["Estimacion"]);
                    int idHistoria = Convert.ToInt32(dr["idHistoria"]);
                    string observaciones=Convert.ToString(dr["observaciones"]);

                    //Guardo las comprobaciones.
                    Boolean tieneInicio = dr["Inicio"] != DBNull.Value;
                    Boolean tieneFin = dr["Fin"] != DBNull.Value;
                    Boolean tieneusu = dr["idUsuario_Sistema"] != DBNull.Value;
                    Historia historia = daoHistoria.buscarPorID(idHist);
                    Tarea tarea = new Tarea(id, desc, est, historia, observaciones);

                    if (tieneInicio)
                        tarea.Incio = Convert.ToDateTime(dr["inicio"]);

                    if (tieneFin)
                        tarea.Fin = Convert.ToDateTime(dr["Fin"]);

                    if (tieneusu)
                        tarea.Owner = daoUsuarioSistema.buscarPorID(Convert.ToInt32(dr["idUsuario_Sistema"]));


                    lstTarea.Add(tarea);
                }

                return lstTarea;
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
       
        /*public List<Tarea> buscarTareaPorProyecto(int idProyecto) {
            try
            {
                List<Historia> historias = daoHistoria.historiasPorProyecto(idProyecto);
                List<Tarea> lsttareas = new List<Tarea>();
                foreach (Historia his in historias)
                {
                    lsttareas.AddRange(this.tareasByHistoria(his.Id));
                } return lsttareas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                Conexion.close();
            }

        }*/
        public List<Tarea> tareasByHistoria(int idHist)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Tareas where IdHistoria=@id;", Conexion.cn);
                query.Parameters.AddWithValue("@id", idHist);
                query.Parameters["@id"].Value = idHist; ;

                SqlDataReader reader = query.ExecuteReader();

                DAOProyecto DAOPro = DAOProyecto.Instance();
                DAOSprint DAOSpr = DAOSprint.Instance();

                List<Tarea> lstTarea = new List<Tarea>();

                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    String desc = Convert.ToString(dr["Descripcion"]);
                    decimal est = Convert.ToDecimal(dr["Estimacion"]);
                    int idHistoria = Convert.ToInt32(dr["idHistoria"]);
                    string observaciones=Convert.ToString(dr["observaciones"]);
                    String estado = Convert.ToString(dr["estado"]);

                    //Guardo las comprobaciones.
                    Boolean tieneInicio = dr["Inicio"] != DBNull.Value;
                    Boolean tieneFin = dr["Fin"] != DBNull.Value;
                    Boolean tieneusu = dr["idUsuario_Sistema"] != DBNull.Value;
                    Historia historia = daoHistoria.buscarPorID(idHist);
                    Tarea tarea = new Tarea(id, desc, est, historia, observaciones,estado);

                    if (tieneInicio)
                        tarea.Incio = Convert.ToDateTime(dr["inicio"]);

                    if (tieneFin)
                        tarea.Fin = Convert.ToDateTime(dr["Fin"]);

                    if (tieneusu)
                        tarea.Owner = daoUsuarioSistema.buscarPorID(Convert.ToInt32(dr["idUsuario_Sistema"]));


                    lstTarea.Add(tarea);
                }

                return lstTarea;
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

       public List<Tarea> historiasporSprint(int idsprint) {

           List<Historia> lsthistoria = new List<Historia>();
           List<Tarea> lstarea=new List<Tarea>();
           lsthistoria=daoHistoria.historiasPorSrpint(idsprint);
           foreach (Historia h in lsthistoria) {
               lstarea.AddRange(this.tareasByHistoria(h.Id));
           } return lstarea;
       }

       public Tarea traerTareaPorConsulta(String consulta, List<SqlParameter> parametros)
       {
           try
           {
               Conexion.open();
               SqlCommand query = new SqlCommand(consulta, Conexion.cn);

               foreach (SqlParameter p in parametros)
               {
                   query.Parameters.Add(p);
               }

               SqlDataReader reader = query.ExecuteReader();

               DAOProyecto DAOPro = DAOProyecto.Instance();
               DAOSprint DAOSpr = DAOSprint.Instance();

               Tarea tarea = new Tarea();

               DataTable dt = new DataTable();
               dt.Load(reader);
               reader.Close();
               Conexion.close();

               foreach (DataRow dr in dt.Rows)
               {
                   int id = Convert.ToInt32(dr["Id"]);
                   String desc = Convert.ToString(dr["Descripcion"]);
                   decimal est = Convert.ToDecimal(dr["Estimacion"]);
                   int idHistoria = Convert.ToInt32(dr["idHistoria"]);
                   string observaciones = Convert.ToString(dr["observaciones"]);
                   String estado = Convert.ToString(dr["estado"]);

                   //Guardo las comprobaciones.
                   Boolean tieneInicio = dr["Inicio"] != DBNull.Value;
                   Boolean tieneFin = dr["Fin"] != DBNull.Value;
                   Boolean tieneusu = dr["idUsuario_Sistema"] != DBNull.Value;
                   Historia historia = daoHistoria.buscarPorID(Convert.ToInt32(dr["idHistoria"]));
                   tarea = new Tarea(id, desc, est, historia, observaciones, estado);

                   if (tieneInicio)
                       tarea.Incio = Convert.ToDateTime(dr["inicio"]);

                   if (tieneFin)
                       tarea.Fin = Convert.ToDateTime(dr["Fin"]);

                   if (tieneusu)
                       tarea.Owner = daoUsuarioSistema.buscarPorID(Convert.ToInt32(dr["idUsuario_Sistema"]));

               }

               return tarea;
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
