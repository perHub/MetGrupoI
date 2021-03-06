﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Empresa
    {
        int id;
        string direccion;
        string nombre;

        public virtual string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }


        public virtual string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public Empresa() { 
            
        }
        public Empresa(int id, string direccion, string nombre) {
            this.direccion = direccion;
            this.id = id;
            this.nombre = nombre;
        }
        public Empresa(int id, string direccion)
        {
            this.direccion = direccion;
            this.id = id;
        }
    }
}
