using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Sprints
    {
        int id;

        String nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        int proyecto;

        public int Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }
        DateTime incio;

        public DateTime Incio
        {
            get { return incio; }
            set { incio = value; }
        }
        DateTime fin;

        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
