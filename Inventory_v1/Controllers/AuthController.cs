using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_v1.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Login(string txtUsername, string txtPassword)   // Username and Password view connected here from Login design page
        //{
        //    ViewBag.Username = txtUsername;       // ViewBag e Username in hoilo
        //    return View();                      // after Login successful there will be a Login successful popup then if press Ok then it will redirect to Home page
        //}
        public ActionResult Login(string txtUsername, string txtPassword)   // Username and Password view connected here from Login design page
        {
            //Session["Username"] = txtUsername;              // Session e Username store korlam
            return Redirect(Url.Action("Index", "Home"));  // Redirect to Home page directly after login
        }                                                 // We can use any one method from above two methods for Login 
    }





     

}
