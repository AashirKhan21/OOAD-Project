using Kutabkhana_DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutabkhana.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        private KutabkhanaDBEntities db = new KutabkhanaDBEntities();

        public ActionResult NewPurchase()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tempur = db.tbl_PurTemDetails.ToList();

            return View(tempur);
        }

        public ActionResult AddItem(int BID, int Qty, float Price)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            var find = db.tbl_PurTemDetails.Where(i => i.BookID == BID && i.Qty == Qty && i.UnitPrice == Price).FirstOrDefault();
            if (find == null)
            {
                if (BID > 0 && Qty > 0 && Price > 0)
                {
                    var newitem = new tbl_PurTemDetails()
                    { 
                        BookID = BID,
                        Qty = Qty,
                        UnitPrice = Price
                    };

                    db.tbl_PurTemDetails.Add(newitem);
                    db.SaveChanges();
                    ViewBag.Message = "Book Add Successfully.";

                }
            }
            else
            {
                ViewBag.Message = "Already Exists! Please Check";
            }

            return RedirectToAction("NewPurchase");
        }
    }
}
