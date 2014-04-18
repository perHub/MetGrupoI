using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Proyectos
    {
        int id;
        string nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Proyectos() { }

        public Proyectos(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
