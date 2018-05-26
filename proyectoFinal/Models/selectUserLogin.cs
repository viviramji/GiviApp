using System;
using System.Collections.Generic;
using proyectoFinal.Models.DataAccess;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class selectUserLogin
    {
        public UserLogin selectUserSP(string _username, string _password)
        {
            UserLogin aux = new UserLogin();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter { name = "_username", value = _username });
            parameters.Add(new Parameter { name = "_password", value = _password });
            try
            {
                MySqlDataReader reader = ExecuteSP.executeStoreProcedure("login", parameters);
                while (reader.Read())
                {
                    aux.username = reader["username_a"]+"";
                    aux.password = reader["password_a"]+"";
                    aux.typeUser = reader["typeUserID_fk"]+"";
                    aux.mySqlStatus = "ok";
                }
                return aux;
            }
            catch(MySqlException e)
            {
                aux.username = "";
                aux.password = "";
                aux.typeUser = "";
                aux.mySqlStatus = e.ToString();
                return aux;
            }
        }
    }
}