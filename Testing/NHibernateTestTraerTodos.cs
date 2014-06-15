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
    class NHibernateTestTraerTodos
    {
        Configuration cfg;
        ISession sesion;
        ISessionFactory fab_sesion;

        [TestFixtureSetUp]
        public void init()
        {
            cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Empresa).Assembly);
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
        public void NhibernateTestGetAll()
        {
            int cant = sesion.QueryOver<Empresa>().RowCount();
            var empresas = sesion.CreateQuery("from Empresa").List<Empresa>();
            Assert.AreEqual(cant, empresas.Count);
        }

    }
}
