using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
   public class YaPoseeEstadoEnEseMomentoException: Exception
    {
        public YaPoseeEstadoEnEseMomentoException()
            : base("No puede crearse un estado para una tarea en el mismo momento.")
        {

        }
    }
}
