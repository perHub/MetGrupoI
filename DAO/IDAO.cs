using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    interface IDAO <T>
    {
            void agregar(T data);
            void eliminar(T data);
            void modificar(int ID, T data);
            T buscarPorID(int ID);
            List<T> traerTodos();
    }
}
