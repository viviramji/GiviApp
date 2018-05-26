using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;

namespace proyectoFinal.Models
{
    public class AddUser
    {
        public string addUserSP(User _user)
        {
            //objetc _user is divived into pieces ...
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_ID", value = _user.id});
            parameters.Add(new Parameter { name = "_firstName", value = _user.firstName });
            parameters.Add(new Parameter { name = "_lastName", value = _user.lastName });
            parameters.Add(new Parameter { name = "_email", value = _user.email });
            parameters.Add(new Parameter { name = "_phoneNumber", value = _user.phoneNumber });
            parameters.Add(new Parameter { name = "_city", value = _user.city });
            parameters.Add(new Parameter { name = "_username", value = _user.username });
            parameters.Add(new Parameter { name = "_password", value = _user.password });
            parameters.Add(new Parameter { name = "_typeUserID_fk", value = _user.typeUser });
            try
            {
                MySqlDataReader reader = ExecuteSP.executeStoreProcedure("AddAnUser", parameters);
            }
            catch (MySqlException e)
            {
                return e.Number.ToString();
            }
            return "ok";
        }
    }
}