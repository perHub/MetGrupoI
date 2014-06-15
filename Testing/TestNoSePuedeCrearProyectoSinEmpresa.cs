using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Entidades;
using Controladora;
using System.Data.SqlClient;
using DAO;

namespace Testing
{
    [TestFixture]
    class TestNoSePuedeCrearProyectoSinEmpresa
    {
        CProyecto CP = new CProyecto();

        [SetUp]
        public void SetUp()
        {
            CP = new CProyecto();

        }
        [Test]
        [ExpectedException("System.NullReferenceException")]
        public void testAgregar()
        {
            CP.Agregar("Proyecto de Prueba");

            //ahora voy a buscar el proyecto
            DAOProyecto DP = DAOProyecto.Instance();

        }
    }
}
