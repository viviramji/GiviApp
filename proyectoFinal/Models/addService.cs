using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;

namespace proyectoFinal.Models
{
    public class addService
    {
        public string addServiceSP(Service _service)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_clientID_fk", value = _service.clientID });
            parameters.Add(new Parameter { name = "_adminID_fk", value = _service.adminID });
            parameters.Add(new Parameter { name = "_userID_fk", value = _service.userID });
            parameters.Add(new Parameter { name = "_description", value = _service.description });
            parameters.Add(new Parameter { name = "_typeService_fk", value = _service.typeService });
            parameters.Add(new Parameter { name = "_date", value = _service.date });
            parameters.Add(new Parameter { name = "_status_fk", value = _service.status });

            try
            {
                MySqlDataReader r = ExecuteSP.executeStoreProcedure("AddService", parameters);
                return "ok";
            }
            catch (MySqlException e)
            {
                return e.Number.ToString();
            }            
        }
    }
}