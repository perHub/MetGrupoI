using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAO;

namespace Controladora
{
    public class CUsuario_sistema
    {
        DAOUsuario_Sistema daoUsuSist = DAOUsuario_Sistema.Instance();
        public CUsuario_sistema() { }
        public UsuarioSistema buscarByID(int id) {
            UsuarioSistema usu = daoUsuSist.buscarPorID(id);
            return usu;
        }
    }
}
