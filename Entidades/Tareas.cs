using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Tareas
    {
        int id;
        String descripcion;
        String estado;
        decimal estimacion;
        DateTime fin;
        DateTime inicio;
        int historia;
        string observaciones;
        int owner;


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

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public decimal Estimacion
        {
            get { return estimacion; }
            set { estimacion = value; }
        }

        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }

        public DateTime Incio
        {
            get { return inicio; }
            set { inicio = value; }
        }

        public int Historia
        {
            get { return historia; }
            set { historia = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        internal int Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public Tareas(){
        }

        public Tareas(int id, string descripcion, string estado, decimal estimacion,DateTime fin,DateTime inicio,int historia,string observaciones, int owner) {
            this.id = id;
            this.descripcion = descripcion;
            this.estado = estado;
            this.estimacion = estimacion;
            this.fin = fin;
            this.inicio = inicio;
            this.historia = historia;
            this.observaciones = observaciones;
            this.owner=owner;
        }

    }
}
