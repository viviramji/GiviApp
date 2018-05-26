using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using proyectoFinal.Models;

namespace proyectoFinal.Controllers
{
    public class NormalController : Controller
    {
        // GET: Normal
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
            return View();
        }

        public JsonResult updateService(element _id)
        {
            modelFacade facade = new modelFacade();
            if (facade.updateServiceResponse(_id))
            {
                List<Service> services = facade.selectServicesResponse();
                Session["Services"] = services;
                return Json(new { msg = "ok" });
            }
            else
            {
                return Json(new { msg = "" });
            }
            
        }

        public ActionResult logout()
        {
            if (Session["Services"] != null)
            {
                Session["Services"] = null;
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            ViewBag.selectMenu = "Profile";
            ViewBag.nameLogged = (string)Session["username"];
            modelFacade facade = new modelFacade();
            ViewBag.user = facade.selectProfileResponse(ViewBag.nameLogged);
            return View();
        }

        public async Task<ActionResult> getServices()
        {
            //vistaParcial, variableDeSession
            return PartialView("serviceNormalPartial", Session["Services"]);
        }
    }
}