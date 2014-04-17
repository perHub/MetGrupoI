using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Invitados:Usuarios
    {
        public Invitados() { 
        
        }
        public Invitados(int id, string descripcion,int empresa,string nombre, string password) {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Empresa = empresa;
            this.Nombre = nombre;
            this.Password = password;
        }
    }
}
