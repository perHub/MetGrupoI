using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DAOUsuario_Sistema : IDAO<UsuarioSistema>
    {
        private static DAOUsuario_Sistema _instance;
        List<UsuarioSistema> lUsuarios = new List<UsuarioSistema>();

        public static DAOUsuario_Sistema Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new DAOUsuario_Sistema();
            }
            return _instance;
        }

        public void agregar(UsuarioSistema data)
        {
            try{
                Conexion.open();
                // agrego a tabla usuario
                SqlCommand cmdAgregarUsu = new SqlCommand("INSERT INTO dbo.Usuarios(Descripcion,IdEmpresa,Nombre,Password)VALUES (@Descripcion,@IdEmpresa,@Nombre,@Password)", Conexion.cn);
                cmdAgregarUsu.Parameters.Add("@Descripcion", System.Data.SqlDbType.VarChar);
                cmdAgregarUsu.Parameters.Add("@IdEmpresa", System.Data.SqlDbType.Int);
                cmdAgregarUsu.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregarUsu.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);

                cmdAgregarUsu.Parameters["@Descripcion"].Value = data.Descripcion;
                cmdAgregarUsu.Parameters["@IdEmpresa"].Value = data.Empresa;
                cmdAgregarUsu.Parameters["@Nombre"].Value = data.Nombre;
                cmdAgregarUsu.Parameters["@Password"].Value = data.Password;
                cmdAgregarUsu.ExecuteNonQuery();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO dbo.Usuarios_Sistema(IdUsuario,EsAdministrador,EsScrumMaster,IdProyecto) VALUES (@IdUsuario,@EsAdministrador,@EsScrumMaster,@IdProyecto)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@IdUsuario", System.Data.SqlDbType.Int);
                cmdAgregar.Parameters.Add("@EsAdministrador", System.Data.SqlDbType.Bit);
                cmdAgregar.Parameters.Add("@EsScrumMaster", System.Data.SqlDbType.Bit);
                cmdAgregar.Parameters.Add("@IdProyecto", System.Data.SqlDbType.Int);
                //ahora los completo
                cmdAgregar.Parameters["@IdUsuario"].Value = data.Id// aca deberia hacer un select en tabla usuario , debe corregirse esto
                    ;
                cmdAgregar.Parameters["@EsAdministrador"].Value =data.Administrador;
                cmdAgregar.Parameters["@EsScrumMaster"].Value =data.ScrumMaster;
                cmdAgregar.Parameters["@IdProyecto"].Value =data.IdProyecto;
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

        public void eliminar(UsuarioSistema data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, UsuarioSistema data)
        {
            throw new NotImplementedException();
        }

        public UsuarioSistema buscarPorID(int ID)
        {
            try
            {
                Conexion.open();

                SqlCommand query = new SqlCommand("select * from Usuarios where id=@ID", Conexion.cn);
                query.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                query.Parameters["@Id"].Value = ID;
                SqlDataReader reader = query.ExecuteReader();

                int id;
                String descripcion;
                int empresa;
                String nombre;
                String password;

                if (reader.Read())
                {
                    id=reader.GetInt32(0);
                    descripcion= reader.GetString(1);
                    empresa=reader.GetInt32(2);
                    nombre=reader.GetString(3);
                    password=reader.GetString(4);
                    Conexion.close();
                    return new Desarrollador(id, descripcion, empresa, nombre, password, null);
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

        public List<UsuarioSistema> traerTodos()
        {
            throw new NotImplementedException();
        }
    }

}
