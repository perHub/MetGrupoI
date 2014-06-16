using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Entidades;
using DAO;
using NHibernate;

namespace Testing		// Esta clase está MUY mal hecha con propósitos de debugging, no se asusten si la ven... :P
{
     [TestFixture]
    class NHibernateSprintPrecario
    {
         Sprint oSprint; //Objeto a guardar.
         Proyecto oPro; //Objeto relacionado.
         Empresa oEmp;

         DAOProyecto dPro;
         DAOSprintNHibernate dSpr;
         
         

         [SetUp]
         public void setup()
         {
             dPro = DAOProyecto.Instance();
             dSpr = DAOSprintNHibernate.Instance();
             oEmp = new Empresa(1, "AAA", "X"); //Hardcodeo empresa 1.
             oPro = new Proyecto(2, "Proyecto X", oEmp);

             ISession sesion = NHHelper.openSession(typeof(Historia));
             var hists = sesion.CreateQuery("from Historia").List<Historia>();
             List<Historia> lstHist = (List<Historia>)hists;
             oSprint = new Sprint(0, oPro, Convert.ToDateTime("1990-01-01"),Convert.ToDateTime("1990-02-01"), "Sprint X", lstHist);
         }
         [Test]
         public void testAgregarSprintNH()
         {
             dPro.agregar(oPro); //Agrego proyecto de prueba a la BD. (usa el DAO 'normal')

             dSpr.agregar(oSprint); // Intento almacenar sprint.
         }
         [Test]
         public void testTraerPorId()
         {

             Sprint ospr2 = dSpr.buscarPorID(1);
             Boolean t = ospr2.Id == 0;
         }
         [Test]
         public void modificarSprint()
         {
             dSpr.agregar(oSprint); // Intento almacenar sprint.
             oSprint.Nombre = "Sprint Z";
             dSpr.modificar(oSprint.Id, oSprint);
         }
         [Test]
         public void eliminarSprint()
         {
             dSpr.agregar(oSprint);
             dSpr.eliminar(oSprint);
         }
         [Test]
         public void traerTodos()
         {
             dSpr.agregar(oSprint);
             List<Sprint> lstSpr = dSpr.traerTodos();
             int i = lstSpr.Count;
         }

         [Test]
         public void productBacklog()
         {
             Sprint spr = dSpr.buscarPorID(1);
             var hax = dSpr.SprintBackLog(spr);
             Boolean a = (0 == 0);
         }

         [Test]
         public void sprintsPorProyecto()
         {
             Proyecto oProy = new Proyecto(1,"test",oEmp);
            var test = dSpr.sprintsPorProyecto(oProy);
            Boolean a = (0 == 0);
         }
    }
}
