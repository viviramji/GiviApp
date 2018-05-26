using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;

namespace proyectoFinal.Models
{
    public class updateService
    {
        public bool updateServiceSP(element _id)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_id", value = _id.id });
            try
            {
                MySqlDataReader reader = ExecuteSP.executeStoreProcedure("updateService", parameters);
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            
        }
    }
}