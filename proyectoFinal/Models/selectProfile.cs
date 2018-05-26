using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;

namespace proyectoFinal.Models
{
    public class selectProfile
    {
        public User selectProfileSP(string _username)
        {
            User u = new User();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_username", value = _username });         
            try
            {
                MySqlDataReader r = ExecuteSP.executeStoreProcedure("profile", parameters);
                while (r.Read())
                {
                    u.id = r["adminID_a"] + "";
                    u.firstName = r["firstName_a"] + "";
                    u.lastName = r["lastName"] + "";
                    u.email = r["email"] + "";
                    u.city = r["city"] + "";
                    u.phoneNumber = r["phoneNumber"] + "";
                    u.username = r["username_a"] + "";
                    u.password = r["password_a"] + "";
                    u.typeUser = r["typeName"] + "";
                }
                return u;
            }catch(MySqlException e)
            {
                u.id = e.Number.ToString();
                return u;
            }
        }
    }
}