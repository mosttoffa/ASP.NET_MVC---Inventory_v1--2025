using Inventory_v1.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            BaseMember baseMember = new BaseMember();  // BaseMember class er object create kora hoise

            //// DataTable use kore ValidateMemberAsDataTable function call kora hoise
            //DataTable dt =baseMember.ValidateMemberAsDataTable(txtUsername, txtPassword);  // ValidateMemberAsDataTable function call kora hoise and parameter pass kora hoise

            //if (dt.Rows.Count > 0)  // Jodi data table er row count 0 er beshi hoy
            //{
            //    Session["Username"] = txtUsername;              // Session e Username store korlam
            //    return Redirect(Url.Action("Index", "Home"));  // Redirect to Home page directly after login
            //}
            //else
            //{
            //    ViewBag.Message = "Invalid Username or Password";  // Jodi Username or Password invalid hoy tahole ei message ta show korbe
            //    return View();                                    // Login page e thakbe
            //}

            ////Session["Username"] = txtUsername;              // Session e Username store korlam
            ////return Redirect(Url.Action("Index", "Home"));  // Redirect to Home page directly after login
            ///


            // List use kore ValidateMemberAsList function call kora hoise
            List<BaseMember> lstMember = baseMember.ValidateMemberAsList(txtUsername, txtPassword);  // ValidateMemberAsList function call kora hoise and parameter pass kora hoise
            bool statusValid = false;  // statusValid false kora hoise
            foreach (BaseMember baseMember1 in lstMember)
            {
                if (baseMember1.Name == txtUsername && baseMember1.Password == txtPassword)  // Jodi Username and Password match hoy
                {
                    statusValid = true;
                }
            }
            if (statusValid)
            {
                Session["Username"] = txtUsername;              // Session e Username store korlam
                //return Redirect(Url.Action("Index", "Home"));  // Redirect to Home page directly after login
            }

            return View();  // Login page e thakbe
        }

        // We can use any one method from above two methods for Login 



        // Logout Part
        public ActionResult Logout()     // Logout function
        {
            if (Session["Username"] != null)  // 
            {
                Session.Remove("Username");  
            }
            return Redirect(Url.Action("Login", "Auth"));  // Redirect to Login page after Logout
        }
    }



}
