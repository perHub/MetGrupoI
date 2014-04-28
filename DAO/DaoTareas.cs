using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class DaoTareas, IDAO<Tareas>
    {
       /* public void Eliminar(Tareas tarea)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Baja = 1 WHERE IdUsuario = @IdUsuario", Conexion.cn);
                cmd.Parameters.Add("@IdUsuario", System.Data.SqlDbType.Int);
                //ahora los completo
                cmd.Parameters["@IdUsuario"].Value = usu.IdUsuario;
                cmd.ExecuteNonQuery();
                //Conexion.close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Conexion.close();
            }
        }*/

        public void Modificar(int id,Tareas tarea)
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
                //ahora los completo
                cmdModificar.Parameters["@Descripcion"].Value = tarea.Descripcion;
                cmdModificar.Parameters["@Estado"].Value = tarea.Estado;
                cmdModificar.Parameters["@Estimacion"].Value = tarea.Estimacion;
                cmdModificar.Parameters["@Inicio"].Value = tarea.Incio;
                cmdModificar.Parameters["@Fin"].Value = tarea.Fin;
                cmdModificar.Parameters["@IdHistoria"].Value = tarea.Historia.Id;
                cmdModificar.Parameters["@IdUsuario_Sistema"].Value = tarea.Owner.Id;
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

/*
        public void Agregar(Sprints spr)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Tareas(Id,Descripcion,Estado,Estimacion,Inicio,Fin,IdHistoria, IdUsuario_Sistema, Observaciones) VALUES (@Id,@Descripcion,@Estado,@Estimacion,@Inicio,@Fin,@IdHistoria, @IdUsuario_Sistema, @Observaciones)"), Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@IdProyecto", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@Inicio", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Fin", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@IdProyecto"].Value = spr.Proyecto;
                cmdAgregar.Parameters["@Inicio"].Value = spr.Incio;
                cmdAgregar.Parameters["@Fin"].Value = spr.Fin;
                cmdAgregar.Parameters["@Nombre"].Value = spr.Nombre;
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

    }*/
}
