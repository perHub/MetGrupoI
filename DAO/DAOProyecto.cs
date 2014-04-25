using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    class DAOProyecto : IDAO<DAOSprint>
    {
        private static DAOProyecto _instance;
        List<Proyecto> listProyectos = new List<Proyecto>();

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

        public void Agregar(Proyecto pjx)
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
                cmdAgregar.Parameters["@IdEmpresa"].Value = pjx.IdEmpresa;
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

    }
}
