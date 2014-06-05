using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Historia
    {
        int id;
        //List<Historia> depende;
        string descripcion; 
        decimal estimacion;
        int prioridad;
        DateTime inicio;
        Proyecto oproyecto;
        Sprint osprint;
        int numero;

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

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public Proyecto oProyecto
        {
            get { return oproyecto; }
            set { oproyecto = value; }
        }

        public Sprint oSprint
        {
            get { return osprint; }
            set { osprint = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }


        public Historia(int id, string descripcion,decimal estimacion, int prioridad,Proyecto proyecto, Sprint sprint,
                            DateTime Inicio, DateTime Fin, int num){
            this.id = id;
            //this.depende = depende;
            this.descripcion=descripcion;
            this.estimacion=estimacion;
            this.prioridad = prioridad;
            this.oproyecto = proyecto;
            this.osprint = sprint;
            this.inicio = Inicio;
            this.fin = Fin;
            this.Numero = num;
        }

        // sin fecha fin, para el product backlog
        public Historia(int id, string descripcion, decimal estimacion, int prioridad, Proyecto proyecto, Sprint sprint,
                    DateTime Inicio, int num)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Estimacion = estimacion;
            this.Prioridad = prioridad;
            this.oProyecto = proyecto;
            this.oSprint = sprint;
            this.Inicio = Inicio;
            this.Numero = num;
        }

        // para el alta
        public Historia(string descripcion, decimal estimacion, int prioridad, Proyecto proyecto, int Num)
        {
            this.Descripcion = descripcion;
            this.Estimacion = estimacion;
            this.Prioridad = prioridad;
            this.oProyecto = proyecto;
            this.Numero = Num;
        }

        public Historia(int id, string descripcion, decimal estimacion, int prioridad, Proyecto proyecto, int Num):this(descripcion,estimacion,prioridad,proyecto, Num)
        {
            this.id = id;
        }
        public override string ToString()
        {
            return descripcion;
        }
    }
}
