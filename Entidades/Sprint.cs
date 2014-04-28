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
       List<Historia> historias;
       List<Tarea> tareas;

       public List<Tarea> Tareas
       {
           get { return tareas; }
           set { tareas = value; }
       }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Proyecto Proyecto
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

        public List<Historia> Historias
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
