using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;


namespace DAO
{
    public class DAOEmpresa : IDAO<Empresa>
    {
        private static DAOEmpresa _instance;

        public static DAOEmpresa Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOEmpresa();
            }
            return _instance;
        }

        public void agregar(Empresa miEmpresa)
        {
            try
            {
                SqlCommand cmdAgregar;
                cmdAgregar = new SqlCommand("INSERT INTO Empresas(Direccion,Nombre) VALUES (@direccion,@nombre)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@direccion"].Value = miEmpresa.Direccion;
                cmdAgregar.Parameters["@nombre"].Value = miEmpresa.Nombre;
                Conexion.open();
                cmdAgregar.ExecuteNonQuery();
                Conexion.close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void eliminar(Empresa miEmpresa)
        {
            try
            {
                SqlCommand cmdAgregar;
                cmdAgregar = new SqlCommand("DELETE FROM Empresas where (IdEmpresa=@Id)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                //ahora los completo
                cmdAgregar.Parameters["@Id"].Value = miEmpresa.Id;
                Conexion.open();
                cmdAgregar.ExecuteNonQuery();
                Conexion.close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        public void modificar(int ID, Empresa data)
        {
            throw new NotImplementedException();
        }

        public Empresa buscarPorID(int ID)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Empresas where id=@ID",Conexion.cn);
                query.Parameters.Add(new SqlParameter("@ID",System.Data.SqlDbType.Int));
                query.Parameters["@ID"].Value = ID;
                SqlDataReader reader = query.ExecuteReader();

                int id;
                String dir;
                String nom;

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                    dir = reader.GetString(1);
                    nom = reader.GetString(2);

                    return new Empresa(id, dir, nom);
                }
                else throw new Exception("Esa empresa no existe.");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally{
                Conexion.close();
            }
        }


        public List<Empresa> traerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
