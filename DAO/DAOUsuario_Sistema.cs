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
/*        public void agregar(UsuarioSistema usu)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdAgregar = new SqlCommand("INSERT INTO Usuarios(Nombre,Email,Fecha_Nac,Sexo,Password,Foto,Baja) VALUES (@Nombre,@Email,@Fecha_Nac,@Sexo,@Password,@Foto,False)", Conexion.cn);
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Fecha_Nac", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Sexo", System.Data.SqlDbType.Char);
                cmdAgregar.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = usu.Nombre;
                cmdAgregar.Parameters["@Email"].Value = usu.Email;
                cmdAgregar.Parameters["@Fecha_Nac"].Value = usu.Fecha_nac;
                cmdAgregar.Parameters["@Sexo"].Value = usu.Sexo;
                cmdAgregar.Parameters["@Password"].Value = usu.Password;
                cmdAgregar.Parameters["@Foto"].Value = usu.Foto;
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

        public Usuario MiUsuario(String mail, String pass)
        {
            try
            {
                Usuario usu = null;
                Conexion.open();
                SqlCommand cmdExiste = new SqlCommand("Select Nombre,Email,Fecha_Nac,Sexo,Password,Foto,Baja,IdUsuario FROM Usuarios WHERE Email = '" + @mail + "' AND Password = '" + @pass + "'", Conexion.cn);
                cmdExiste.Parameters.Add("@mail", System.Data.SqlDbType.VarChar);
                cmdExiste.Parameters.Add("@pass", System.Data.SqlDbType.VarChar);
                cmdExiste.Parameters["@mail"].Value = mail;
                cmdExiste.Parameters["@pass"].Value = pass;
                SqlDataReader reader = cmdExiste.ExecuteReader();
                String cNombre = "";
                String cEmail = "";
                DateTime dFecha_nac;
                Char cSexo;
                String cPass;
                int cFoto = 0;
                Boolean lBaja;
                int idusua = 0;
                while (reader.Read())
                {
                    cNombre = reader.GetString(0);
                    cEmail = reader.GetString(1);
                    dFecha_nac = reader.GetDateTime(2);
                    cSexo = Convert.ToChar(reader.GetValue(3));
                    //var buffer = new char[1];
                    //cSexo = 'M'; // (char)reader.GetChars(4, 0, buffer, 0, 1);
                    cPass = reader.GetString(4);
                    cFoto = reader.GetInt32(5);
                    lBaja = reader.GetBoolean(6);
                    idusua = reader.GetInt32(7);
                    usu = new Usuario(cNombre, cEmail, dFecha_nac, cSexo, cPass, cFoto, lBaja);
                }
                usu.IdUsuario = idusua;
                //Conexion.close();
                return usu;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.close();
            }
        }

        public int Existe(string unNombre)
        {
            try
            {
                int idUsuario = -1;
                SqlCommand cmd = new SqlCommand("SELECT IdUsuario FROM USUARIOS WHERE Nombre='" + @unNombre + "'  ", Conexion.cn);
                Conexion.open();
                cmd.Parameters.Add("@unNombre", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@unNombre"].Value = unNombre;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    idUsuario = (int)reader.GetInt32(0);
                reader.Close();
                Conexion.close();
                return idUsuario;
            }
            catch (Exception ex)
            {
                return -1;
            }

            finally
            {
                Conexion.close();
            }
        }

        public List<Usuario> BusquedaUsuarios(string unNombre)
        {
            try
            {
                List<Usuario> lUsu = new List<Usuario>();
                SqlCommand cmd = new SqlCommand("SELECT Nombre,Email,Fecha_Nac,Sexo,Password,Foto,Baja,IdUsuario FROM USUARIOS WHERE Nombre like '%" + @unNombre + "%'", Conexion.cn);
                Conexion.open();
                Usuario usu = null;
                cmd.Parameters.Add("@unNombre", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@unNombre"].Value = unNombre;

                SqlDataReader reader = cmd.ExecuteReader();
                String cNombre = "";
                String cEmail = "";
                DateTime dFecha_nac;
                Char cSexo;
                String cPass;
                int cFoto;
                Boolean lBaja;
                while (reader.Read())
                {
                    cNombre = reader.GetString(0);
                    cEmail = reader.GetString(1);
                    dFecha_nac = reader.GetDateTime(2);
                    cSexo = Convert.ToChar(reader.GetValue(3));
                    //var buffer = new char[1];
                    //cSexo = 'M'; // (char)reader.GetChars(4, 0, buffer, 0, 1);
                    cPass = reader.GetString(4);
                    cFoto = reader.GetInt32(5);

                    //  cFoto = reader.GetString(6);
                    lBaja = reader.GetBoolean(6);
                    usu = new Usuario(cNombre, cEmail, dFecha_nac, cSexo, cPass, cFoto, lBaja);
                    usu.IdUsuario = (int)reader.GetValue(7);
                    lUsu.Add(usu);
                }
                //Conexion.close();

                reader.Close();
                Conexion.close();
                return lUsu;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.close();
            }
        }

        public List<Usuario> MisAmigos(int idusu)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdExiste = new SqlCommand("Select Nombre,Email,Fecha_Nac,Sexo,Password,Foto,Baja,IdUsuario FROM Usuarios WHERE idusuario=@IdUsuario", Conexion.cn);
                cmdExiste.Parameters.Add("@IdUsuario", System.Data.SqlDbType.Int);
                cmdExiste.Parameters["@IdUsuario"].Value = idusu;
                List<Usuario> listAmigos = new List<Usuario>();
                SqlDataReader reader = cmdExiste.ExecuteReader();
                String cNombre = "";
                String cEmail = "";
                DateTime dFecha_nac;
                Char cSexo;
                String cPass;
                int cFoto = 0;
                Boolean lBaja;
                while (reader.Read())
                {
                    cNombre = reader.GetString(0);
                    cEmail = reader.GetString(1);
                    dFecha_nac = reader.GetDateTime(2);
                    cSexo = Convert.ToChar(reader.GetValue(3));
                    //var buffer = new char[1];
                    //cSexo = 'M'; // (char)reader.GetChars(4, 0, buffer, 0, 1);
                    cPass = reader.GetString(4);
                    cFoto = reader.GetInt32(5);
                    lBaja = reader.GetBoolean(6);
                    Usuario usu = new Usuario(cNombre, cEmail, dFecha_nac, cSexo, cPass, cFoto, lBaja);
                    usu.IdUsuario = reader.GetInt32(7);
                    listAmigos.Add(usu);

                }
                //Conexion.close();
                return listAmigos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.close();
            }
        }

        public List<Usuario> UsuariosSinMi(int idusu)
        {
            try
            {
                Conexion.open();
                SqlCommand cmdExiste = new SqlCommand("Select Nombre,Email,Fecha_Nac,Sexo,Password,Foto,Baja,IdUsuario FROM Usuarios WHERE idusuario<>@IdUsuario", Conexion.cn);
                cmdExiste.Parameters.Add("@IdUsuario", System.Data.SqlDbType.Int);
                cmdExiste.Parameters["@IdUsuario"].Value = idusu;
                List<Usuario> listUsuarios = new List<Usuario>();
                SqlDataReader reader = cmdExiste.ExecuteReader();
                String cNombre = "";
                String cEmail = "";
                DateTime dFecha_nac;
                Char cSexo;
                String cPass;
                int cFoto;
                Boolean lBaja;
                while (reader.Read())
                {
                    cNombre = reader.GetString(0);
                    cEmail = reader.GetString(1);
                    dFecha_nac = reader.GetDateTime(2);
                    cSexo = Convert.ToChar(reader.GetValue(3));
                    //var buffer = new char[1];
                    //cSexo = 'M'; // (char)reader.GetChars(4, 0, buffer, 0, 1);
                    cPass = reader.GetString(4);
                    cFoto = reader.GetInt32(5);
                    lBaja = reader.GetBoolean(6);
                    Usuario usu = new Usuario(cNombre, cEmail, dFecha_nac, cSexo, cPass, cFoto, lBaja);
                    usu.IdUsuario = reader.GetInt32(7);
                    listUsuarios.Add(usu);

                }
                //Conexion.close();
                return listUsuarios;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.close();
            }
        }

        public void Eliminar(Usuario usu)
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
        }

        public void Modificar(Usuario usu)
        {
            try
            {
                SqlCommand cmdAgregar = new SqlCommand("UPDATE Usuarios SET Nombre=@Nombre,Email=@Email,Fecha_Nac=@Fecha_Nac,Domicilio=@Domicilio,Sexo=@Sexo,Password=@Password WHERE IdUsuario=@IdUsuario)", Conexion.cn);
                Conexion.open();
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Fecha_Nac", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Domicilio", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Sexo", System.Data.SqlDbType.Char);
                cmdAgregar.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = usu.Nombre;
                cmdAgregar.Parameters["@Email"].Value = usu.Email;
                cmdAgregar.Parameters["@Fecha_Nac"].Value = usu.Fecha_nac;
                cmdAgregar.Parameters["@Sexo"].Value = usu.Sexo;
                cmdAgregar.Parameters["@Password"].Value = usu.Password;
                cmdAgregar.Parameters["@Foto"].Value = usu.Foto;
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

        public Usuario obtenerUsuario(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Nombre,Email,Fecha_Nac,Sexo,Password,Foto,Baja,IdUsuario FROM USUARIOS WHERE IdUsuario=" + @id, Conexion.cn);
                Conexion.open();
                Usuario encontrado = null;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@id"].Value = id;

                SqlDataReader reader = cmd.ExecuteReader();
                String cNombre = "";
                String cEmail = "";
                DateTime dFecha_nac;
                Char cSexo;
                String cPass;
                int cFoto;
                Boolean lBaja;
                if (reader.Read())
                {
                    cNombre = reader.GetString(0);
                    cEmail = reader.GetString(1);
                    dFecha_nac = reader.GetDateTime(2);
                    cSexo = Convert.ToChar(reader.GetValue(3));
                    //var buffer = new char[1];
                    //cSexo = 'M'; // (char)reader.GetChars(4, 0, buffer, 0, 1);
                    cPass = reader.GetString(4);
                    //if (reader.GetString(6) == null)
                    cFoto = Convert.ToInt32(reader.GetValue(5));
                    //else
                    //  cFoto = reader.GetString(6);
                    lBaja = reader.GetBoolean(6);
                    encontrado = new Usuario(cNombre, cEmail, dFecha_nac, cSexo, cPass, cFoto, lBaja);
                    encontrado.IdUsuario = (int)reader.GetValue(7);
                }

                reader.Close();
                //Conexion.close();
                return encontrado;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.close();
            }
        }

        public int ExisteMail(string unNombre)
        {
            try
            {
                int idUsuario = -1;
                SqlCommand cmd = new SqlCommand("SELECT IdUsuario FROM USUARIOS WHERE Email='" + @unNombre + "'  ", Conexion.cn);
                Conexion.open();
                cmd.Parameters.Add("@unNombre", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@unNombre"].Value = unNombre;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    idUsuario = (int)reader.GetInt32(0);
                reader.Close();
                Conexion.close();
                return idUsuario;
            }
            catch (Exception ex)
            {
                return -1;
            }

            finally
            {
                Conexion.close();
            }
        }
*/

        public void agregar(UsuarioSistema data)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<UsuarioSistema> traerTodos()
        {
            throw new NotImplementedException();
        }
    }

}
