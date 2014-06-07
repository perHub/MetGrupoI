using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EstadoTarea
    {
        Estado estadoActual;
        Estado estadoAnterior;
        DateTime fecha;
        String observaciones;
       Tarea otarea;

        public Estado EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }

        public Estado EstadoAnterior
        {
            get { return estadoAnterior; }
            set { estadoAnterior = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public Tarea oTarea
        {
            get { return otarea; }
            set { otarea = value; }
        }
        public EstadoTarea() { 
        
        }
        public EstadoTarea(Estado estadoActual, Estado estadoAnterior, DateTime fecha, Tarea tarea,string observaciones)
        {
            this.estadoActual = estadoActual;
            this.EstadoAnterior = estadoAnterior;
            this.fecha = fecha;
            this.otarea = tarea;
            this.observaciones = observaciones;
        }

        public EstadoTarea(Estado estadoActual, Estado estadoAnterior, DateTime fecha,  string observaciones)
        {
            this.estadoActual = estadoActual;
            this.EstadoAnterior = estadoAnterior;
            this.fecha = fecha;
            this.observaciones = observaciones;
        }
    }
}
