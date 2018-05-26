using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinal.Models
{
    public class modelFacade
    {
        public UserLogin loginResponse(string _username, string _password)
        {
            return new selectUserLogin().selectUserSP(_username, _password);
        }

        public User selectProfileResponse(string _username)
        {
            return new selectProfile().selectProfileSP(_username);
        }

        public string addUserResponse(User _user)
        {
            return new AddUser().addUserSP(_user);
        }        

        public string addServiceResponse(Service _service)
        {
            return new addService().addServiceSP(_service);
        }

        public string deleteServiceResponse(element _id)
        {
            return new deleteService().deleteServiceSP(_id);
        }

        public List<Service> selectServicesResponse()
        {
            return new selectServices().selectServicesSP();
        }       

        public string addClientResponse(Client _client)
        {
            return new addClient().addClientSP(_client);
        }
        
        public List<Client> SelectClientsResponse()
        {
            return new SelectClients().selectClientsSP();
        }
        public List<User> selectUsersResponse()
        {
            return new SelectListUser().selectListUserSP();
        }

        public bool updateServiceResponse(element _id)
        {
            return new updateService().updateServiceSP(_id);
        }
    }
}