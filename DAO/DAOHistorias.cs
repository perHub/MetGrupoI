using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    class DAOHistorias:IDAO<Historia>
    {

        public void agregar(Historia data)
        {
            List<SqlParameter> Params = new List<SqlParameter>();
            string cmdtext = "insert into Historias(Descripcion, Estimacion, Prioridad, IdProyecto, IdSprint, Inicio, Fin) values (@desc, @est, @pri, @idpro, @idspr, @inicio, @fin)";

            Params.Add(new SqlParameter("@Desc", data.Descripcion));
            Params.Add(new SqlParameter("@est", data.Estimacion));
            Params.Add(new SqlParameter("@pri", data.Prioridad));
            Params.Add(new SqlParameter("@idpro", data.oProyecto.Id));
            Params.Add(new SqlParameter("@idspr", data.oSprint.Id));
            Params.Add(new SqlParameter("@inicio", data.Inicio));
            Params.Add(new SqlParameter("@fin", data.Fin));

        }
        public void eliminar(Historia data)
        {
            throw new NotImplementedException();
        }

        public void modificar(int ID, Historia data)
        {
            throw new NotImplementedException();
        }

        public Historia buscarPorID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Historia> traerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
