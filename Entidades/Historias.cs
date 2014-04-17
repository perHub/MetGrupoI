using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Historias
    {
        int id;
        List<Historias> depende;
        string descripcion; 
        decimal estimacion;
        int prioridad;
        int proyecto;
        int sprint; //solo un sprint? consultar

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
    }
}
