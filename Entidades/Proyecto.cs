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
        Empresa oempresa;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public virtual Empresa oEmpresa
        {
            get { return oempresa; }
            set { oempresa = value; }
        }

        public Proyecto() { }

        public Proyecto(int id, string nombre,Empresa oEmp) {
            this.Id = id;
            this.Nombre = nombre;
            this.oEmpresa = oEmp;
        }

        public Proyecto(string nombre)
        {
            this.Nombre = nombre;
        }

    }
}
