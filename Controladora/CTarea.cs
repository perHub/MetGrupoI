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

        //Arreglar, sacar fechas y usuario-sistema.

 /*       public void agregar(String desc,  decimal estima, DateTime ffin, DateTime fini, Historia hist, String obse, UsuarioSistema usu)
        {

            Tarea auxTarea = new Tarea(desc, estima, ffin, fini, hist, obse, usu);
            dataTarea.agregar(auxTarea);
        }*/

        //Correción:

        /*public void agregar(string descr, decimal estima, Historia h, String observ)
        {
            Tarea t = new Tarea(descr, estima, h, observ, "No iniciada."); //Agregar constructor sin estado.
            dataTarea.agregar(t);
        }*/
        public void agregar(string descr, decimal estima, Historia h, String observ)
        {
            Tarea t = new Tarea(descr, estima, h, observ, "No iniciada."); //Agregar constructor sin estado.
            dataTarea.agregarConNulls(t);
        }

        public void setFechaInicio(DateTime dia, int id) {
            dataTarea.setearFechaInicio(dia, id);
        }
        public int buscarTareaByDescripcion(String desc) {
            return dataTarea.buscaIDporDescripcion(desc);
        }
        public void setFechaFin(DateTime ff, int idd) {
            dataTarea.setearFechaFin(ff, idd);
        }
        public void setEstado(String estado, int id) {
            dataTarea.setearEstado(estado, id);
        }



        public void eliminar(Tarea tarea)
        {
            dataTarea.eliminar(tarea);
        }

        public void modificar(int id, Tarea tarea)
        {
            dataTarea.modificar(id, tarea);
        }
        public void modificarConNulls(int id, Tarea tarea) {
            dataTarea.modificarConNulls(id, tarea);
        }
        public List<Tarea> buscarPorSprint(int id) {
            return dataTarea.historiasporSprint(id);
        }
        public void agregarEstadoTareaConDesc(EstadoTarea et, String descipcion) { //Preguntar sobre este método
            dataTarea.agregarEstadoTareaConNombre(et, descipcion);
        }

        public void agregarEstadoTarea(EstadoTarea et)
        {
            dataTarea.agregarEstadoTarea(et);
        }

        public Tarea buscarPorID(int id) {
            return dataTarea.buscarPorID(id);
        }

        public void eliminarEstadoPorFecha(EstadoTarea et)
        {
            dataTarea.eliminarEstadoPorFecha(et);
        }

    }
}
