using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Estados
    {
        int id;
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

       public int Id
       {
           get { return id; }
           set { id = value; }
       }
       public Estados() { 
           
       }
       public Estados(int id, string nombre) {
           this.id = id;
           this.nombre = nombre;
       }
 
    }
}
