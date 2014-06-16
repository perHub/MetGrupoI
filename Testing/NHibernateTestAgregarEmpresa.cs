using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using NUnit.Framework;
using Entidades;

namespace Testing
{
    [TestFixture]
    class NHibernateTestAgregarEmpresa
    {
        Configuration cfg;
        ISession sesion;
        ISessionFactory fab_sesion;
        Empresa e;

        [TestFixtureSetUp]
        public void init()
        {
            cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Empresa).Assembly);
            e = new Empresa(3, "ABC123", "EmpTest");

            //new SchemaExport(cfg).Execute(true, true, false); // Crearía las tablas.
            fab_sesion = cfg.BuildSessionFactory();
            sesion = fab_sesion.OpenSession();
        }

        [SetUp]
        public void setup()
        {
            sesion = fab_sesion.OpenSession();
        }

        [Test]
        public void testAgregarTareaNHibernate()
        {
            sesion.Save(e);
            sesion.Flush();


           var emps = sesion.CreateQuery("from Empresa where Nombre='EmpTest'").List<Empresa>(); //LINQ
           Assert.Greater(emps.Count,0);

        }

        [TearDown]
        public void cleanup()
        {
            sesion.CreateSQLQuery("delete from Empresas where Nombre='EmpTest'").ExecuteUpdate();
            sesion.Close();

        }
    }
}
