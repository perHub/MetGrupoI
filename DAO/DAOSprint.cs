﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace DAO
{
    public class DAOSprint : IDAO<Sprint>
    {
        private static DAOSprint _instance;
        List<Sprint> listSprints = new List<Sprint>();

        private DAOSprint() { }
        public static DAOSprint Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOSprint();
            }
            return _instance;
        }

        public void agregar(Sprint spr)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Sprints(IdProyecto,Inicio,Fin,Nombre) VALUES (@IdProyecto,@Inicio,@Fin,@Nombre)", Conexion.cn);
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
          
            public List<Historia> SprintBackLog(Sprint miSprint)
            {
                try
                {
                    List<Historia> listHistorias = new List<Historia>();
                    SqlCommand cmd = new SqlCommand("SELECT HI.Descripcion,HI.Estimacion,HI.Prioridad,HI.Inicio,SP.ID as IdSprint,HI.Id as ID"+
                    "FROM HISTORIAS as HI JOIN SPRINTS as SP ON HI.IdSprint = SP.Id WHERE SP.Id = @IdSprint", Conexion.cn);
                    Conexion.open();
                    cmd.Parameters.Add("@IdSprint", System.Data.SqlDbType.Int);
                    cmd.Parameters["@IdSprint"].Value = miSprint.Id;
                        
                    SqlDataReader reader = cmd.ExecuteReader();
                    String cDescripcion = "";
                    Decimal nEstimacion = 0;
                    int nPrioridad = 0;
                    DateTime dInicio;
                    int nIdSprint = 0;
                    int nId = 0;
                    while (reader.Read())
                    {
                        cDescripcion = reader.GetString(0);
                        nEstimacion = reader.GetDecimal(1);
                        nPrioridad = reader.GetInt32(2);
                        dInicio = reader.GetDateTime(3);
                        nIdSprint = reader.GetInt32(4);
                        nId = reader.GetInt32(5);
                        //Historia hist = new Historia(nId,cDescripcion,nEstimacion,nPrioridad,nId,dInicio);
                        //listHistorias.Add(hist);
                    }

                    reader.Close();
                    Conexion.close();
                    return listHistorias;
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

            public void modificar(Sprint sprint)
            {
                try
                {
                    SqlCommand cmdAgregar = new SqlCommand("UPDATE Sprint SET Inicio=@inicio,Fin=@fin,Nombre=@Nombre WHERE Id=@Id)", Conexion.cn);
                    Conexion.open();
                    //paso parametros
                    cmdAgregar.Parameters.Add("@inicio", System.Data.SqlDbType.DateTime);
                    cmdAgregar.Parameters.Add("@fin", System.Data.SqlDbType.DateTime);
                    cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                    cmdAgregar.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    //ahora los completo
                    cmdAgregar.Parameters["@inicio"].Value = sprint.Nombre;
                    cmdAgregar.Parameters["@fin"].Value = sprint.Fin;
                    cmdAgregar.Parameters["@Nombre"].Value = sprint.Nombre;
                    cmdAgregar.Parameters["@Id"].Value = sprint.Id;
                    cmdAgregar.ExecuteNonQuery();

                    //Agrego historias.


                    SqlCommand agregarHistorias = new SqlCommand();


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

            public Sprint miSprint(int id)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id,IdProyecto,Inicio,Fin,Nombre FROM Sprints WHERE Id=" + @id, Conexion.cn);
                    Conexion.open();
                    Sprint encontrado = null;
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
                    cmd.Parameters["@id"].Value = id;

                    SqlDataReader reader = cmd.ExecuteReader();
                    Int32 nId = 0;
                    Int32 nIdProy = 0;
                    DateTime dInicio;
                    DateTime dFin;
                    String cNombre = "";
                    if (reader.Read())
                    {
                        nId = reader.GetInt32(0);
                        nIdProy = reader.GetInt32(1);
                        dInicio = reader.GetDateTime(2);
                        dFin = reader.GetDateTime(3);
                        cNombre = reader.GetString(4);
                        //aca habría que traer el objeto proyecto pero no llegue a hacerlo
                        encontrado = new Sprint(nId, dInicio, dFin, cNombre);
                    }

                    reader.Close();
                    Conexion.close();
                    return encontrado;
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

            
            public void eliminar(Sprint data)
            {
                throw new NotImplementedException();
            }

            public void modificar(int ID, Sprint data)
            {
                throw new NotImplementedException();
            }

            public Sprint buscarPorID(int ID)
            {
                return miSprint(ID); //Debería ser este método directamente, consultar.
            }

            public List<Sprint> traerTodos()
            {
                throw new NotImplementedException();
            }

            public List<Sprint> sprintsPorProyecto(Proyecto oPro)
            {
                try
                {
                    int idproyecto = oPro.Id;
                    Conexion.open();

                    SqlCommand query = new SqlCommand("select * from Sprints where IdProyecto=@id", Conexion.cn);
                    query.Parameters.AddWithValue("@id", idproyecto);
                    query.Parameters["@id"].Value = idproyecto; ;

                    SqlDataReader reader = query.ExecuteReader();

                    DAOProyecto DAOPro = DAOProyecto.Instance();

                    List<Sprint> lstSpr = new List<Sprint>();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    Conexion.close();

                    foreach (DataRow dr in dt.Rows)
                    {
                        int id = Convert.ToInt32(dr["Id"]);
                        String nombre = dr["Nombre"].ToString();
                        DateTime Inic = Convert.ToDateTime(dr["Inicio"]);
                        DateTime Fin = Convert.ToDateTime(dr["Fin"]);
                        
                        Sprint oSpr = new Sprint(id, oPro, Inic, Fin,nombre, null); //AUn no creo la lista de historias por simplicidad.
                        lstSpr.Add(oSpr);
                    }

                    return lstSpr;
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
