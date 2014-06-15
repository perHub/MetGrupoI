using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using NUnit.Framework;
using Entidades;
using Controladora;
using System.Data.SqlClient;

namespace Testing
{
    [TestFixture]
    class NHibernateTestEliminarEmpresa
    {
        Configuration cfg;
        ISession sesion;
        ISessionFactory fab_sesion;
        Empresa miEmp;
        [TestFixtureSetUp]
        public void init()
        {
            cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Empresa).Assembly);
            //new SchemaExport(cfg).Execute(true, true, false); // Crearía las tablas.
            fab_sesion = cfg.BuildSessionFactory();
            sesion = fab_sesion.OpenSession();

            //miEmp = sesion.CreateQuery("from Empresa WHERE Id=5 Select Empresa").List<Empresa>().First(); //LINQ
            //no está bueno esto, sería ideal buscar un id existente
            miEmp = sesion.Get<Empresa>(9);

        }

        [SetUp]
        public void setup()
        {
            sesion = fab_sesion.OpenSession();
        }

        [Test]
        public void TestEliminarEmpresa()
        {
            sesion.Delete(miEmp);
            sesion.Flush();

            var emps = sesion.CreateQuery("from Empresa where Direccion='" + miEmp.Direccion+"' AND Nombre='"+miEmp.Nombre+"'").List<Empresa>();
            Assert.IsTrue(emps.Count==0);

        }

        [TearDown]
        public void cleanup()
        {
            sesion.Save(miEmp);
            sesion.Flush();

        }
    }
}
