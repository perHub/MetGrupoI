using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Entidades;
using System.Data;

namespace Testing
{
    [TestFixture]
    public class TestBorrarSprintConHistorias
    {

        Sprint sprTest;
        Proyecto oPro;

        [SetUp]
        public void SetUp()
        {
            sprTest = new Sprint(1, null, Convert.ToDateTime(null), Convert.ToDateTime(null), "S1", null);
            oPro = new Proyecto();
        }

       /* [Test]
        [ExpectedException(typeof(NoNullAllowedException))]*/



    }
}
