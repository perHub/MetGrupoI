using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class noPuedeCambiarseResponsableException: Exception
    {
        public noPuedeCambiarseResponsableException()
            : base("No es posible cambiar el responsable una vez asignado.")
        {
        }
    }
}
