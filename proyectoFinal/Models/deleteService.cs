using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;
namespace proyectoFinal.Models
{
    public class deleteService
    {
        public string deleteServiceSP(element _id)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_id", value = _id.id });
            string response = "";
            try
            {
                MySqlDataReader r = ExecuteSP.executeStoreProcedure("deleteService", parameters);
                while (r.Read())
                {
                    response = r["mensaje"] + "";
                }
               
            }
            catch(MySqlException e)
            {
                response =  e.Number.ToString();
                
            }
            return response;

        }
    }
}