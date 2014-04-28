using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Invitado:Usuario
    {
        public Invitado() { 
        
        }
        public Invitado(int id, string descripcion,int empresa,string nombre, string password) {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Empresa = empresa;
            this.Nombre = nombre;
            this.Password = password;
        }
    }
}
