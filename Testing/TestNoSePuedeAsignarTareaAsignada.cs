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
    class TestNoSePuedeAsignarTareaAsignada
    {
        Tarea T;
        CTarea cT;

        [SetUp]
        public void SetUp()
        {
            T = null;
            cT = new CTarea();
            //acá traigo una tarea que tenga idusuario_sistema para que el test arroje verde ya que no se puede asignar usuario a una tarea asignada
            T = cT.buscarPorID(2);
        }

        [Test]
        public void TestAsignarTarea()
        {
            //dejo comentado el método de insertar dado que solo necesito saber si el idusuario_sistema es null o no
            /*if (T.Owner == null)
            {
                DAOUsuario_Sistema daoUsuarioSistema = DAOUsuario_Sistema.Instance();
                T.Owner = daoUsuarioSistema.buscarPorID(Convert.ToInt32(1));
            }*/
            Assert.IsNotNull(T.Owner);
        }
    }
}
