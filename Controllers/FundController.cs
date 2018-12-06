using ProInvesta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProInvesta.Controllers
{
    public class FundController : Controller
    {
        DB_A34082_proinvestaEntities _db;
        public FundController()
        {
            _db = new DB_A34082_proinvestaEntities();
        }
        public ActionResult MutualFund()
        {
            return View();
        }


        public ActionResult MutualFundEnquiry()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MutualFundEnquiry(MutualFundEnquiry enquiry)
        {

            if (ModelState.IsValid)
            {
                enquiry.ID = Guid.NewGuid();
                _db.MutualFundEnquiries.Add(enquiry);
                _db.SaveChanges();
                TempData["mflag"] = "added";
                return Redirect("~/Fund/MutualFund");

            }
            else
            {
                TempData["mflag"] = null;
                return View();
            }
            }
            
         
       
    }
}
