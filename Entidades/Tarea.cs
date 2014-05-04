using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Tarea
    {
        int id;
        String descripcion;
        decimal estimacion;
        DateTime fin;
        DateTime inicio;
        Historia historia;
        string observaciones;
        UsuarioSistema owner;
        string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        List<EstadoTarea> listaDeEstados;

        public Tarea(int id, string descr, decimal estima,Historia h, String observ, string estado){
            this.id = id;
            this.descripcion = descr;
            this.estimacion = estima;
            this.historia = h;
            this.observaciones = observ;
            this.Estado = estado;
        }

        public List<EstadoTarea> ListaDeEstados
        {
            get { return listaDeEstados; }
            set { listaDeEstados = value; }
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

        public Historia Historia
        {
            get { return historia; }
            set { historia = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public UsuarioSistema Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public Tarea(){
        }

        public Tarea(int id, string descripcion, decimal estimacion,DateTime fin,DateTime inicio, Historia historia,string observaciones, UsuarioSistema owner) {
            this.id = id;
            this.descripcion = descripcion;
            this.estimacion = estimacion;
            this.fin = fin;
            this.inicio = inicio;
            this.historia = historia;
            this.observaciones = observaciones;
            this.owner=owner;
        }

        public Tarea(string descripcion,  decimal estimacion, DateTime fin, DateTime inicio, Historia historia, string observaciones, UsuarioSistema owner)
        {
            this.descripcion = descripcion;
            this.estimacion = estimacion;
            this.fin = fin;
            this.inicio = inicio;
            this.historia = historia;
            this.observaciones = observaciones;
            this.owner = owner;
        }

    }
}
