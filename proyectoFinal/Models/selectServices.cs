using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using proyectoFinal.Models.DataAccess;

namespace proyectoFinal.Models
{
    public class selectServices
    {
        public List<Service> selectServicesSP()
        {
            List<Service> services = new List<Service>();
            Service aux = new Service();
            try
            {
                //r = reader it's easer to write a one letter than more than five
                MySqlDataReader r = ExecuteSP.ExecuteSPWithoutParameters("selectServices");
                    while (r.Read())
                    {
                        aux.id = r["serviceID"] + "";
                        aux.companyName = r["companyName"] + "";
                        aux.description = r["description"] + "";
                        aux.date = r["date"] + "";
                        aux.status = r["status"] + "";
                        aux.typeService = r["typeService"] + "";
                        aux.adminID = r["username_a"] + "";
                        aux.userID = r["username_u"] + "";
                        aux.checker = "OK";
                        services.Add(aux);
                        aux = new Service();
                    }
                    return services;
                
            }
            catch(MySqlException e)
            {
                aux.companyName = "";
                aux.description = "";
                aux.date = "";
                aux.status = "";
                aux.typeService = "";
                aux.adminID = "";
                aux.userID = "";
                aux.checker = e.Number.ToString();
                services.Add(aux);
                return services;
            }
            
        }

        public string returnRealDate(string d)
        {
            return "";
        }
    }
}