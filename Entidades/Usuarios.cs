using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    abstract public class Usuarios
    {
        int id;
        String descripcion;
        int empresa;
        String nombre;
        String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
