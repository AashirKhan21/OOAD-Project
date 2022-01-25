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

        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            try
            {
                if (email != null && password != null)
                {
                    var finduser = db
                }

            }
            catch (Exception ex)
            {

            }
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
    }
}