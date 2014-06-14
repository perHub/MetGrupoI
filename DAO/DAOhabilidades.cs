using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;

namespace DAO
{
    class DAOHabilidad: IDAO<Habilidad>
    {
        private static DAOHabilidad _instance;

        private DAOHabilidad(){}

        public static DAOHabilidad Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOHabilidad();
            }
            return _instance;
        }

        public void agregar(Habilidad data)
        {
            throw new NotImplementedException();
        }

        public void eliminar(Habilidad data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, Habilidad data)
        {
            throw new NotImplementedException();
        }

        public Habilidad buscarPorID(int ID)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Habilidades where id=@ID", Conexion.cn);
                query.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                query.Parameters["@Id"].Value = ID;
                SqlDataReader reader = query.ExecuteReader();

                int id;
                String nom;

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                    nom = reader.GetString(1);
                    Conexion.close();
                    return new Habilidad(id, nom);
                }
                else throw new Exception("No existe dicha habilidad");
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

        public List<Habilidad> traerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
