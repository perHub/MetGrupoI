using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Entidades;
using Controladora;

namespace Testing
{
    
    [TestFixture]
    class TestAgregarTarea
    {
        Tarea T1;
        CTarea cT;
        Historia h;

        [SetUp]
        public void SetUp()
        {
            CHistoria CH = new CHistoria();
            cT = new CTarea();
            h = CH.buscarPorId(1);
        }

        [Test]
        public void testAgregar()
        {
            cT.agregar("Dev UI", 2, h, "", "No iniciada.");

        }
    }
}
