using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    abstract public class UsuarioSistema:Usuario
    {
        List<Habilidad> listaHabilidades;
        bool scrumMaster;
        bool administrador;
        int idProyecto;


        public UsuarioSistema() { 
        
        }

        public UsuarioSistema(int id, String descripcion, int empresa, String nombre, String password, List<Habilidad> habilidades, bool sm, bool ad, int idproyecto) {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Empresa = empresa;
            this.Nombre = nombre;
            this.Password = password;
            this.listaHabilidades = habilidades;
            this.scrumMaster = sm;
            this.administrador = ad;
            this.IdProyecto = idProyecto;
        }
        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }

        public List<Habilidad> ListaHabilidades
        {
            get { return listaHabilidades; }
            set { listaHabilidades = value; }
        }

        public bool ScrumMaster
        {
            get { return scrumMaster; }
            set { scrumMaster = value; }
        }

        public bool Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }

    }
}
