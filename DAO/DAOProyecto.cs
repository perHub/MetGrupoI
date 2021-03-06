﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DAOProyecto : IDAO<Proyecto>
    {
        private static DAOProyecto _instance;
        List<Proyecto> listProyectos = new List<Proyecto>();

        private DAOProyecto(){}

        public static DAOProyecto Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOProyecto();
            }
            return _instance;
        }

        public void agregar(Proyecto pjx)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Proyectos(Nombre,IdEmpresa) VALUES (@Nombre,@IdEmpresa)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@IdEmpresa", System.Data.SqlDbType.Int);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = pjx.Nombre;
                cmdAgregar.Parameters["@IdEmpresa"].Value = pjx.oEmpresa.Id;
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

        public void eliminar(Proyecto data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, Proyecto data)
        {
            throw new NotImplementedException();
        }

        public Proyecto buscarPorID(int ID)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Proyectos where id=@ID", Conexion.cn);
                query.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                query.Parameters["@Id"].Value = ID;
                SqlDataReader reader = query.ExecuteReader();

                int id;
                String nom;
                Empresa oEmp;
                DAOEmpresa daoEmp = DAOEmpresa.Instance();

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                    nom = reader.GetString(1);
                    int nIDEmp = reader.GetInt32(2);
                    Conexion.close();
                    oEmp = daoEmp.buscarPorID(nIDEmp);

                    return new Proyecto(id,nom,oEmp);
                }
                else throw new Exception("Ese proyecto no existe.");

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

        public List<Proyecto> traerTodos()
        {
            throw new NotImplementedException();
        }

    }
}
