using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Controladora;
using Entidades;
using DAO;
namespace Testing
{
    [TestFixture]
    class testNoDebeCambiarResponsable
    {
        CTarea cT;
        CUsuario_sistema cUS;
        Tarea T;


        [SetUp]
        public void setup()
        {
            cT = new CTarea();
            cUS = new CUsuario_sistema();

            T = cT.buscarPorID(2); //Tarea "Crear diagrama de clases" asignada al usuario "5".

        }

        [Test]
        [ExpectedException(typeof(noPuedeCambiarseResponsableException))]
        public void testCambiarResponsable()
        {
            T.Owner = cUS.buscarByID(6); //Cambio al usuario "6"
            cT.modificar(T.Id, T); //Debe lanzar la excepción
        }
    }
}
