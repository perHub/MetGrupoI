﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Estados_Tareas
    {
        int estadoActual;
        int estadoAnterior;
        DateTime fecha;
        String observaciones;
        int tarea;

        public int EstadoActual
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }

        public int EstadoAnterior
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

        public int Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }
        public Estados_Tareas() { 
        
        }
        public Estados_Tareas(int estadoActual, int estadoAnterior, DateTime fecha, int tarea,string observaciones)
        {
            this.estadoActual = estadoActual;
            this.EstadoAnterior = estadoAnterior;
            this.fecha = fecha;
            this.tarea = tarea;
            this.observaciones = observaciones;
        }
    }
}
