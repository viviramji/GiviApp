using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;

namespace proyectoFinal.Models
{
    public class addClient
    {
        public string addClientSP(Client _client)
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_clientID", value = _client.id });
            parameters.Add(new Parameter { name = "_name", value = _client.companyName });
            parameters.Add(new Parameter { name = "_phoneNumber", value = _client.phoneNumber });
            parameters.Add(new Parameter { name = "_address", value = _client.address });
            parameters.Add(new Parameter { name = "_email", value = _client.email });
            parameters.Add(new Parameter { name = "_city", value = _client.city });
            try
            {
                MySqlDataReader reader = ExecuteSP.executeStoreProcedure("AddClient", parameters);
            }
            catch (MySqlException e)
            {
                return e.Number.ToString();
            }
            return "ok";
        }
    }
}