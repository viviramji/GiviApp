using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using proyectoFinal.Models.DataAccess;

namespace proyectoFinal.Models
{
    public class SelectListUser
    {
        public List<User> selectListUserSP()
        {
            User aux = new User();
            List<User> users = new List<User>();
            try
            {
                MySqlDataReader r = ExecuteSP.ExecuteSPWithoutParameters("selectAllUsers");
                while (r.Read())
                {
                    aux.id = r["adminID_a"] + "";
                    aux.firstName = r["firstName_a"] + "";
                    aux.lastName = r["lastName"] + "";
                    aux.phoneNumber = r["phoneNumber"] + "";
                    aux.city = r["city"] + "";
                    aux.email = r["email"] + "";
                    aux.username = r["username_a"] + "";
                    aux.typeUser = r["typeName"] + "";
                    aux.password = r["password_a"] + "";               
                    users.Add(aux);
                    aux = new User();
                }
                return users;
            }
            catch (MySqlException e)
            {
                aux.firstName = e.Number.ToString();
                users.Add(aux);
                return users;
            }
            
        }
    }
}