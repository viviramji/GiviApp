using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using proyectoFinal.Models;

namespace proyectoFinal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {

            ViewBag.selectMenu = "Dashboard";
            ViewBag.nameLogged = (string)Session["username"];
            if (Session["Services"] == null)
            {
                modelFacade facade = new modelFacade();
                List<Service> services = facade.selectServicesResponse();
                Session["Services"] = services;
            }
            
            if(Session["Clients"] == null)
            {
                modelFacade facade = new modelFacade();
                List<Client> clients = facade.SelectClientsResponse();
                Session["Clients"] = clients;
            }
            if(Session["Users"] == null)
            {
                modelFacade facade = new modelFacade();
                List<User> users = facade.selectUsersResponse();
                Session["Users"] = users;
            }
            
            return View();
        }
        [HttpPost]
        public JsonResult addUser(User _user)
        {
            bool isThere = false;
            List<User> users = (List<User>)Session["Users"];
            foreach(User u in users)
            {
                if(u.id == _user.id)
                {
                    isThere = true;
                }
            }
            if (!isThere)
            {
                if (addUserToDB(_user))
                {
                    modelFacade facade = new modelFacade();
                    users = facade.selectUsersResponse();
                    Session["Users"] = users;
                    return Json(new { msg = "ok" });
                }
                else
                {
                    return Json(new { msg = "errorBackend" });
                }
            }
            else
            {
                return Json(new { msg = "exists" });
            }
        }
        
        [HttpPost]
        public JsonResult addClient(Client _client)
        {
            bool isThere = false; string response = "";
            List<Client> clients = (List<Client>)Session["Clients"];
            foreach(Client c in clients)
            {
                if(c.id == _client.id)
                {
                    isThere = true;
                }
            }
            if (!isThere)
            {
                if(addClientToDB(_client, ref response))
                {
                    clients.Add(_client);
                    Session["Clients"] = clients;
                    return Json(new { msg = "ok" });
                }
                else
                {
                    return Json(new { msg = "errorBackend" });
                }
            }
            else
            {
                return Json(new { msg = "exists" });
            }            
        }
        
        [HttpPost]
        public JsonResult addService(Service _service)
        {
            if (addServiceToDB(_service))
            {
                modelFacade facade = new modelFacade();
                List<Service> services = facade.selectServicesResponse();
                Session["Services"] = services;                
                return Json(new { msg = "ok" });
            }
            else
            {
                return Json(new { msg = "BackendError" });
            }
        }

        [HttpPost]
        public JsonResult deleteService(element _id)
        {
            modelFacade facade = new modelFacade();
            string response = facade.deleteServiceResponse(_id);
            if (response == "ok")
            {
                List<Service> services = facade.selectServicesResponse();
                Session["Services"] = services;
                return Json(new { msg = "ok" });
            }
            else if (response == "bad")
            {
                return Json(new { msg = "bad" });
            }
            else
            {
                return Json(new { msg = "error" });
            }
                
            
        }

        [HttpPost]
        public bool addUserToDB(User _user)
        {
            modelFacade facade = new modelFacade();
            var response = facade.addUserResponse(_user);
            if(response == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public bool addClientToDB(Client _client, ref string response)
        {
            modelFacade facade = new modelFacade();
            response = facade.addClientResponse(_client);
            if (response == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public bool addServiceToDB(Service _service)
        {
            modelFacade facade = new modelFacade();
            var response = facade.addServiceResponse(_service);
            if(response == "ok")
            {
                return true;
            }
            else
            {
                return false;
            }       
        }

        [HttpGet]
        public async Task<ActionResult> getServices()
        {
            //vistaParcial, variableDeSession
            return PartialView("servicePartial", Session["Services"]);
        }
        [HttpGet]
        public async Task<ActionResult> getClients()
        {
            return PartialView("listClientsPartial", Session["Clients"]);
        }
        [HttpGet]
        public async Task<ActionResult> getUsers()
        {
            return PartialView("listUsersPartial", Session["Users"]);
        }

        public ActionResult Profile()
        {
            ViewBag.selectMenu = "Profile";
            ViewBag.nameLogged = (string)Session["username"];
            modelFacade facade = new modelFacade();
            ViewBag.user = facade.selectProfileResponse(ViewBag.nameLogged);
            return View();
        }

        public ActionResult logout()
        {
            if (Session["Services"] != null)
            {
                Session["Services"] = null;
            }

            if (Session["Clients"] != null)
            {
                Session["Clients"] = null;
            }
            if (Session["Users"] != null)
            {
               Session["Users"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

    }
}