using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Entidades;
using DAO;
using Controladora;
using System.Data;
using System.Data.SqlClient;

namespace Testing
{
    [TestFixture]
    public class TestBorrarSprintConHistorias
    {

        Sprint S;
        CSprint CS;

        [SetUp]
        public void SetUp()
        {
            CS = new CSprint();
            S = null;
            S = CS.buscarPorId(1);
        }

        [Test]
        [ExpectedException("System.Data.SqlClient.SqlException")]
        public void TestBorrar()
        {
            Conexion.open();
            //cableo la eliminación trayendo un sprint que se que tiene historias aunque debería primero hacer una consulta trayendo un sprint con historias y luego borrar ese
            SqlCommand cmd = new SqlCommand("DELETE from Sprints WHERE Id = 1", Conexion.cn);
            cmd.ExecuteNonQuery();
        }
    }
}
