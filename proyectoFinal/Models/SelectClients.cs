using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using proyectoFinal.Models.DataAccess;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class SelectClients
    {
        public List<Client> selectClientsSP()
        {
            Client aux = new Client();
            List<Client> clients = new List<Client>();
            try
            {
                MySqlDataReader r = ExecuteSP.ExecuteSPWithoutParameters("selectClients");
                while (r.Read())
                {
                    aux.id = r["clientID"] + "";
                    aux.companyName = r["companyName"] + "";
                    aux.phoneNumber = r["phoneNumber"] + "";
                    aux.address = r["address"] + "";
                    aux.email = r["email"] + "";
                    aux.city = r["city"] + "";
                    clients.Add(aux);
                    aux = new Client();
                }
                return clients;
            }
            catch(MySqlException e)
            {
                aux.id = e.Number.ToString();
                clients.Add(aux);
                return clients;
            }
           
        }
    }
}