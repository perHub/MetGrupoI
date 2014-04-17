using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    abstract class Usuarios_Sistemas:Usuarios
    {
        List<Habilidades> listaHabilidades;

        internal List<Habilidades> ListaHabilidades
        {
            get { return listaHabilidades; }
            set { listaHabilidades = value; }
        }
    }
}
