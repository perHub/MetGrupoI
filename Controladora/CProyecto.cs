﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAO;

namespace Controladora
{
    public class CProyecto
    {
        DAOProyecto DPro = DAOProyecto.Instance();

       public Proyecto buscarPorId(int id){
            return DPro.buscarPorID(id);
        
        }

        //este método va sin empresa para poder usarlo en el test
       public void Agregar(String nombre)
       {
           Proyecto miProyecto = new Proyecto(nombre);
           DPro.agregar(miProyecto);
       }

    }
}
