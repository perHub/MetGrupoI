using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    class DAOHabilidad_Usuario:IDAO<Habilidad_Usuario>
    {
        private static DAOHabilidad_Usuario _instance;
        List<Sprint> listSprints = new List<Sprint>();

        private DAOHabilidad_Usuario() { }
        public static DAOHabilidad_Usuario Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOHabilidad_Usuario();
            }
            return _instance;
        }

        public void agregar(Habilidad_Usuario data)
        {
            throw new NotImplementedException();
        }

        public void eliminar(Habilidad_Usuario data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, Habilidad_Usuario data)
        {
            throw new NotImplementedException();
        }

        public Habilidad_Usuario buscarPorID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Habilidad_Usuario> traerTodos()
        {
            throw new NotImplementedException();
        }
        public List<Habilidad_Usuario> traerTodosByIDusuario(int idusuario) {
            try
            {
                Conexion.open();
                List<Habilidad_Usuario> lstHabilidades = new List<Habilidad_Usuario>();
                SqlCommand query = new SqlCommand("select * from Habilidades_Usuarios where IdUsuario=@id", Conexion.cn);
                query.Parameters.AddWithValue("@id", idusuario);
                query.Parameters["@id"].Value = idusuario ;

                SqlDataReader reader = query.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Conexion.close();

                foreach (DataRow dr in dt.Rows)
                {
                    int idHabilidad= Convert.ToInt32(dr["IdHabilidad"]);
                    Habilidad_Usuario habUsu= new Habilidad_Usuario(idusuario,idHabilidad);
                    lstHabilidades.Add(habUsu);
                }

                return lstHabilidades;
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
