using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Historias
    {
        int id;
        List<Historias> depende;
        string descripcion; 
        decimal estimacion;
        int prioridad;
        int proyecto;
        int sprint; //solo un sprint? consultar

        DateTime inicio;
        DateTime fin;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        internal List<Historias> Depende
        {
            get { return depende; }
            set { depende = value; }
        }
        
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal Estimacion
        {
            get { return estimacion; }
            set { estimacion = value; }
        }

        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public int Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }

        public int Sprint
        {
            get { return sprint; }
            set { sprint = value; }
        }

        public DateTime Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }

        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }

        public Historias() { 
        
        }
        public Historias( int id, List<Historias> depende, string descripcion,decimal estimacion, int prioridad,int proyecto,int sprint){
            this.id = id;
            this.depende = depende;
            this.descripcion=descripcion;
            this.estimacion=estimacion;
            this.prioridad = prioridad;
            this.proyecto = proyecto;
            this.sprint = sprint;
        }
        public Historias(int id, string descripcion, decimal estimacion, int prioridad, int sprint, DateTime inicio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.estimacion = estimacion;
            this.prioridad = prioridad;
            this.sprint = sprint;
            this.Inicio = inicio;
        }

    }
}
