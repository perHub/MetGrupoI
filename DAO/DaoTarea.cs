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
                SqlCommand cmdModificar = new SqlCommand("UPDATE Tareas SET Descripcion=@Descripcion,Estado=@Estado,Estimacion=@Estimacion,Inicio=@Inicio,Fin=@Fin,IdHistoria=@IdHistoria, IdUsuario_Sistema=@IdUsuario_Sistema, Observaciones=@Observaciones WHERE Id=@Id)", Conexion.cn);
                Conexion.open();
                //paso parametros
                cmdModificar.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar);
                cmdModificar.Parameters.Add("@Estado", System.Data.SqlDbType.VarChar);
                cmdModificar.Parameters.Add("@Estimacion", System.Data.SqlDbType.Decimal);
                cmdModificar.Parameters.Add("@Inicio", System.Data.SqlDbType.DateTime);
                cmdModificar.Parameters.Add("@Fin", System.Data.SqlDbType.DateTime);
                cmdModificar.Parameters.Add("@IdHistoria", System.Data.SqlDbType.Int);
                cmdModificar.Parameters.Add("@IdUsuario_Sistema", System.Data.SqlDbType.Int);
                cmdModificar.Parameters.Add("@Observaciones", System.Data.SqlDbType.VarChar);
                cmdModificar.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                //ahora los completo
                cmdModificar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdModificar.Parameters["@Estado"].Value = tarea.Estado;
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
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Tareas(Id,Descripcion,Estado,Estimacion,Inicio,Fin,IdHistoria, IdUsuario_Sistema, Observaciones) VALUES (@Id,@Descripcion,@Estado,@Estimacion,@Inicio,@Fin,@IdHistoria, @IdUsuario_Sistema, @Observaciones)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Estado", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Estimacion", System.Data.SqlDbType.Decimal);
                cmdAgregar.Parameters.Add("@Inicio", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Fin", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@IdHistoria", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@IdUsuario_Sistema", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@Observaciones", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@Id"].Value = tarea.Id;
                cmdAgregar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdAgregar.Parameters["@Estado"].Value = tarea.Estado;
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

    }
}
