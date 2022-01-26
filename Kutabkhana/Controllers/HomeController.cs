using Kutabkhana_DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutabkhana.Controllers
{
    public class HomeController : Controller
    {
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult LoginUser(tbl_Users tbl_Users) 
        {
            try
            {
                    var finduser = db.tbl_Users.Where(u => u.Username == tbl_Users.Username && u.Password == tbl_Users.Password && u.IsActive == true).FirstOrDefault();
                    if (finduser != null)
                    {
                        Session["UserID"] = finduser.UserID;
                        Session["UserTypeID"] = finduser.UserTypeID;
                        Session["Username"] = finduser.Username;
                        Session["Password"] = finduser.Password;
                        Session["EmployeeID"] = finduser.EmployeeID;
                        //UserTypeID       UserTypeName
                        //1                 Admin
                        //2                 Operator
                        //3                 Teacher
                        //4                 Student

                        if (finduser.UserTypeID == 2)
                        {
                            return RedirectToAction("About", "Home");
                        }
                        else if (finduser.UserTypeID == 3)
                        {
                            return RedirectToAction("About", "Home");
                        }
                        else if (finduser.UserTypeID == 4)
                        {
                            return RedirectToAction("About", "Home");
                        }
                        else if (finduser.UserTypeID == 1)
                        {
                            return RedirectToAction("About", "Home");
                        }
                    }
                    else
                    {
                        Session["UserID"] = finduser.UserID;
                        Session["UserTypeID"] = finduser.UserTypeID;
                        Session["Username"] = finduser.Username;
                        Session["Password"] = finduser.Password;
                        Session["EmployeeID"] = finduser.EmployeeID;
                        ViewBag.Message = "Username and Password is Incorrect!!";
                        return RedirectToAction("Login", "Index");
                    }
            }
            catch (Exception ex)
            {
                Session["UserID"] = string.Empty;
                Session["UserTypeID"] = string.Empty;
                Session["Username"] = string.Empty;
                Session["Password"] = string.Empty;
                Session["EmployeeID"] = string.Empty;
                ViewBag.Message = ex.Message;
            }

            return View("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            return View("Login");
        }
    }
}