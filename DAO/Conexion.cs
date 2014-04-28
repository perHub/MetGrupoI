using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    static public class Conexion
    {
        static string ConnectionString = "Data Source=NICOLAS-PC\\SQL2005;Initial Catalog=PS;User ID=sa;Password=bobesponja";
        //static string ConnectionString = "Data Source=notebook\\SQLEXPRESS;Initial Catalog=ShareThis; Persist Security Info=true; Integrated Security=SSPI;";

        static public SqlConnection cn = new SqlConnection(ConnectionString);

        static public void open()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }
        static public void close()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }



    }
}
