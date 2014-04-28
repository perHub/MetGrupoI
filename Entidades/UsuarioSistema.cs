using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    abstract public class UsuarioSistema:Usuario
    {
        List<Habilidad> listaHabilidades;

        internal List<Habilidad> ListaHabilidades
        {
            get { return listaHabilidades; }
            set { listaHabilidades = value; }
        }
    }
}
