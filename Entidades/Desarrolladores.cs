using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    class Desarrolladores:Usuarios_Sistemas
    {
        public Desarrolladores(int id, string descripcion,int empresa,string nombre, string password, List<Habilidades >listaHabilidades) {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Empresa = empresa;
            this.Nombre = nombre;
            this.Password = password;
            this.ListaHabilidades = listaHabilidades;
        }
    }
}
