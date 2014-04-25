using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Proyecto
    {
        int id;
        string nombre;
        int idempresa;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int IdEmpresa
        {
            get { return idempresa; }
            set { idempresa = value; }
        }

        public Proyecto() { }

        public Proyecto(int id, string nombre,int idemp) {
            this.Id = id;
            this.Nombre = nombre;
            this.IdEmpresa = idemp;
        }
    }
}
