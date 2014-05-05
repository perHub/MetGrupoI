using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAOestados: IDAO<Estado>
    {
        private static DAOestados _instance;

        private DAOestados() { }

        public static DAOestados Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOestados();
            }
            return _instance;
        }

        public void agregar( Estado estado)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO dbo.Estados(Nombre) VALUES (@Nombre)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = estado.Nombre;
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

        public void eliminar(Estado data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, Estado data)
        {
            throw new NotImplementedException();
        }

        public Estado buscarPorID(int ID)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from dbo.Estados where id=@ID", Conexion.cn);
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
                    return new Estado(id,nom);
                }
                else throw new Exception("Ese estado no existe.");

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

        public List<Estado> traerTodos()
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Estados", Conexion.cn);
                SqlDataReader reader = query.ExecuteReader();

                List<Estado> lstEstado = new List<Estado>();

                DataTable dt = new DataTable();
                dt.Load(reader);
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["id"]);
                    string nombre = Convert.ToString(dr["nombre"]);
                    Estado estado = new Estado(id, nombre);
                    lstEstado.Add(estado);
                }

                return lstEstado;
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
