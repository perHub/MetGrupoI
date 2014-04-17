using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Sprints
    {
        int id;
        int proyecto;
        DateTime inicio;
        DateTime fin;
        String nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }


        public DateTime Incio
        {
            get { return inicio; }
            set { inicio = value; }
        }


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
        public Sprints() { 
            
        }
        public Sprints(int id, int proyecto, DateTime inicio,DateTime fin,string nombre)
        {
            this.id = id;
            this.proyecto = proyecto;
            this.inicio = inicio;
            this.fin = fin;
            this.nombre = nombre;
        }

    }
}
