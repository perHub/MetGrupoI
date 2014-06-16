using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Sprint
    {
        int id;
        Proyecto proyecto;
        DateTime inicio;
        DateTime fin;
        String nombre;
       IList<Historia> historias;
       IList<Tarea> tareas;

       public virtual IList<Tarea> Tareas
       {
           get { return tareas; }
           set { tareas = value; }
       }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual Proyecto Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }


        public virtual DateTime Incio
        {
            get { return inicio; }
            set { inicio = value; }
        }


        public virtual DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }

        public virtual String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public virtual IList<Historia> Historias
        {
            get { return historias; }
            set { historias = value; }
        }
        public Sprint() { 
            
        }

        public Sprint(int id, DateTime inicio, DateTime fin, string nombre)
        {
            this.id = id;
            this.inicio = inicio;
            this.fin = fin;
            this.nombre = nombre;
        }

        public Sprint(int id, Proyecto proyecto, DateTime inicio,DateTime fin,string nombre, List<Historia> lista)
        {
            this.id = id;
            this.proyecto = proyecto;
            this.inicio = inicio;
            this.fin = fin;
            this.nombre = nombre;
            this.Historias = lista;
        }

    }
}
