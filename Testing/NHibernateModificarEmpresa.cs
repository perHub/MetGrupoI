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
    class NHibernateModificarEmpresa
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
            //new SchemaExport(cfg).Execute(true, true, false); // Crearía las tablas.
            fab_sesion = cfg.BuildSessionFactory();
            sesion = fab_sesion.OpenSession();
            e = new Empresa(1, "aucas libreria", "italia 3973");
        }
        [SetUp]
        public void setup()
        {
            sesion = fab_sesion.OpenSession();
        }
        [Test]
        public void NHibernateModificarEmpresas() {
            sesion.Update(e);
            var eDEbbdd= sesion.Get<Empresa>(e.Id);
            Assert.AreEqual(e, eDEbbdd);
        }
    }
}
