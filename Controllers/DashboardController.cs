using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProInvesta.Models;
using System.Web.UI;

namespace ProInvesta.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Dashboard() {
            return View();
        }
        //Write action for return json data
        [HttpGet]
        public ActionResult LoadData()
        {
            using (DB_A34082_proinvestaEntities dc = new DB_A34082_proinvestaEntities())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var data = dc.Enquiries.ToList();
        
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
               }
        }

        [HttpPost]
        public ActionResult LoadContact()
        {
            using (DB_A34082_proinvestaEntities dc = new DB_A34082_proinvestaEntities())
            {
                var data = dc.ContactUs.ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult LoadMutualFund()
        {
            using (DB_A34082_proinvestaEntities dc = new DB_A34082_proinvestaEntities())
            {
                var data = dc.MutualFundEnquiries.ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
     
    }
}
