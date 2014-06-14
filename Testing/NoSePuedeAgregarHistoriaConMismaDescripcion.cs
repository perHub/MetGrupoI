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
    class TestNoSePuedeAgregarHistoriaConMismaDescripcion
    {
        CHistoria chi;
        Proyecto p;
        [SetUp]
        public void SetUp()
        {
            p = new Proyecto(1, "un proyecto", null);
            chi = new CHistoria();
        }
        [Test]
        [ExpectedException(typeof(Exception))]
        public void testAgregaHistoria()
        {
            chi.agregar("Crear Proyecto", 1, 1, p, 1);
        }


    }
}
