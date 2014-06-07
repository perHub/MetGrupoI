using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de cAccesoDB
/// </summary>
public class cAccesoDB
{
    SqlConnection cn = new SqlConnection(@"Data Source=localhost;Initial Catalog=PS;Integrated Security=True");
 

    private void conectar()
    {
        if (cn.State != ConnectionState.Open)
            //throw new Exception("Conexión abierta");

        cn.Open();
    }

    private void desconectar()
    {
        if (cn.State == ConnectionState.Closed)
            throw new Exception("Conexión cerrada");

        cn.Close();
    }

    public DataTable cargarDatos(string cmdtext)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(cmdtext, cn);

        conectar();

        SqlDataReader reader = cmd.ExecuteReader();

        dt.Load(reader);

        desconectar();

        return dt;
    }

    //Métodos para escribir en la BD (en realidad puede ejecutar cualquier consulta)

    public void ejecutarSQL(string cmdtext)
    {
        SqlCommand cmd = new SqlCommand(cmdtext, cn);
        conectar();
        cmd.ExecuteNonQuery();
        desconectar();
    }

    public object ejecutarSQL_Scalar(string cmdtext)
    {
        SqlCommand cmd = new SqlCommand(cmdtext, cn);
        conectar();

        object res = cmd.ExecuteScalar();               //Se necesitará castear.
        desconectar();
        return res;                                     //Retorna el escalar (que será un valor cualquieradela BD(ID,Nombre, etc.)).
    }

    public void ejecutarConParams(string cmdtext, List<SqlParameter> Params)
    {
        SqlCommand cmd = new SqlCommand(cmdtext, cn);

        foreach (SqlParameter P in Params)
        {
            cmd.Parameters.Add(P);
        }

        conectar();
        cmd.ExecuteNonQuery();
        desconectar();
    }

    public void ejecutarStored(string cmdtext, List<SqlParameter> Params)
    {
        SqlCommand cmd = new SqlCommand(cmdtext, cn);
        cmd.CommandType = CommandType.StoredProcedure;

        foreach (SqlParameter P in Params)
        {
            cmd.Parameters.Add(P);
        }

        conectar();
        cmd.ExecuteNonQuery();
        desconectar();
    }
}