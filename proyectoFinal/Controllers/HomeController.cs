using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectoFinal.Models;

namespace proyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string _username, string _password) 
        {
            UserLogin userLogged;
            modelFacade facade = new modelFacade();
            userLogged = facade.loginResponse(_username, _password);
            if(userLogged.mySqlStatus == "ok" && userLogged.typeUser == "0")
            {
                Session["username"] = userLogged.username;
                return RedirectToAction("Dashboard", "Admin", new { id = userLogged.username });
            }
            else if (userLogged.mySqlStatus == "ok" && userLogged.typeUser == "1")
            {
                Session["username"] = userLogged.username;
                return RedirectToAction("Dashboard", "normal"/*, new { id = userLogged.username}*/);
            }
            else
            {
                return RedirectToAction("LoginFail", userLogged);
            }
        }

        public ActionResult loginFail()
        {
            ViewBag.Message = "Your username or password are incorrect";
            return View();
        }
    }
}