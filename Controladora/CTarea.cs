using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Entidades;
using System.Data;

namespace Controladora
{
    public class CTarea
    {
        DAOTarea dataTarea = DAOTarea.Instance();

        public void agregar(String desc,  decimal estima, DateTime ffin, DateTime fini, Historia hist, String obse, UsuarioSistema usu)
        {

            Tarea auxTarea = new Tarea(desc, estima, ffin, fini, hist, obse, usu);
            dataTarea.agregar(auxTarea);
        }

        public void eliminar(Tarea tarea)
        {
            dataTarea.eliminar(tarea);
        }

        public void modificar(int id, Tarea tarea)
        {
            dataTarea.eliminar(tarea);
            dataTarea.agregar(tarea);
        }
        public List<Tarea> buscarPorSprint(int id) {
            return dataTarea.historiasporSprint(id);
        }
        public void agregarEstadoTareaConDesc(EstadoTarea et, String descipcion) {
            dataTarea.agregarEstadoTareaConNombre(et, descipcion);
        }
        public Tarea buscarPorID(int id) {
            return dataTarea.buscarPorID(id);
        }

    }
}
