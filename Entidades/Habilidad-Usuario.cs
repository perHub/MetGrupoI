using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Habilidad_Usuario
    {
        int idUsuario;
        int idHabilidad;

        public int IdHabilidad
        {
            get { return idHabilidad; }
            set { idHabilidad = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public Habilidad_Usuario() { 
        }
        public Habilidad_Usuario(int idusuario,int habilidad)
        {
            this.idHabilidad = habilidad;
            this.idUsuario = IdUsuario;
        }
    }
}
