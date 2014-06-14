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
    class testVariosEstadosMismoMomento // Prueba la imposibilidad de agregar dos o más estados para una tarea en un mismo momento. 
    {
        CTarea cT;
        EstadoTarea ET1;
        EstadoTarea ET2;

        Tarea T;
        DateTime momento;

        Estado noIniciada;
        Estado enProgreso;
        Estado finalizada;



        [SetUp]
        public void setup()
        {
           cT = new CTarea();
           T = cT.buscarPorID(2);

           noIniciada = new Estado(1, "No iniciada."); //Creo los estados en memoria, los ids corresponden a los de la BD.
           enProgreso = new Estado(2, "En progreso.");
           finalizada = new Estado(3, "Finalizada."); 

            momento = new DateTime(1990, 1, 1);


            ET1 = new EstadoTarea(enProgreso, noIniciada, momento, T, "No iniciada");
            ET2 = new EstadoTarea(finalizada, enProgreso, momento, T,  "Iniciada.");


        }

        [Test]
        [ExpectedException(typeof(YaPoseeEstadoEnEseMomentoException))]
        public void testEstadosMismoMomento()
        {
            cT.agregarEstadoTarea(ET1);     // Agrego el primer estado.
            cT.agregarEstadoTarea(ET2);     //Aquí debería ser lanzada la excepción.
        }

        [TearDown]
        public void cleanup()
        {
            cT.eliminarEstadoPorFecha(ET1);
        }
    }
}
