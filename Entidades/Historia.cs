using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Historia
    {
        int id;
        List<Historia> depende;
        string descripcion; 
        decimal estimacion;
        int prioridad;
        DateTime inicio;

        public DateTime Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }
        DateTime fin;

        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }
        Proyectos oproyecto;
        Sprints osprint;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        internal List<Historia> Depende
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

        public Proyectos oProyecto
        {
            get { return oproyecto; }
            set { oproyecto = value; }
        }

        public Sprints oSprint
        {
            get { return oSprint; }
            set { oSprint = value; }
        }
        public Historia() { 
        
        }
        public Historia( int id, List<Historia> depende, string descripcion,decimal estimacion, int prioridad,Proyectos proyecto, Sprints sprint,
                            DateTime Inicio, DateTime Fin){
            this.id = id;
            this.depende = depende;
            this.descripcion=descripcion;
            this.estimacion=estimacion;
            this.prioridad = prioridad;
            this.oproyecto = proyecto;
            this.osprint = sprint;
            this.inicio = Inicio;
            this.fin = Fin;
        }
    }
}
