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
    class TestAgregarTarea
    {
        Tarea T;

        String descripcion;
        decimal estimacion;
        String observaciones;
        int IdHistoria;

        CTarea cT;
        Historia H;

        [TearDown]              //Limpio la BD.
        public void cleanup()
        {
            cT.eliminar(T);
        }

        [SetUp]
        public void SetUp()
        {
             descripcion = "Codificar UI";
             estimacion = 2;
             observaciones = "Preguntar al cliente";
             IdHistoria = 9;

            T = null;
            CHistoria CH = new CHistoria();
            cT = new CTarea();
            H = CH.buscarPorId(IdHistoria);
        }

        [Test]
        public void testAgregar()
        {
            cT.agregar(descripcion, estimacion, H, observaciones); //Método a probar.

            //Intento recuperar los datos:

            DAOTarea dT = DAOTarea.Instance();

            List<SqlParameter> parameteres = new List<SqlParameter>();
            parameteres.Add(new SqlParameter("@Desc", descripcion));
            parameteres.Add(new SqlParameter("@Est", estimacion));
            parameteres.Add(new SqlParameter("@IdHist", IdHistoria));

           T = dT.traerTareaPorConsulta("select * from Tareas where Descripcion=@Desc and Estimacion=@Est and IdHistoria=@IdHist and Descripcion=@Desc", parameteres);


           Assert.IsNotNull(T);


        }
    }
}
