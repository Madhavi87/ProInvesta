using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProInvesta.Models;
using System.Web.UI;
using System.Web.Security;

namespace ProInvesta.Controllers
{
    public class HomeController : Controller
    {
        DB_A34082_proinvestaEntities _db;

        public HomeController()
        {
            _db = new DB_A34082_proinvestaEntities();
        }

        public ActionResult HomePage()
        {
            return View();
        }
       
        public ActionResult WorkInProgress()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(User obj)
        {
                   
            var output = _db.Users.FirstOrDefault(m => (m.UserName == obj.UserName) && (m.Password == obj.Password));
             if (output != null)
             {
             ViewBag.msg = "Successful";
             Session["UserName"] = obj.UserName;
             ViewBag.user = obj.UserName;
            // FormsAuthentication.SetAuthCookie(obj.UserName, false);
             return Redirect("~/Enquiry/EnquiryListing");
             }
             else
             {
                 ViewBag.msg = "UnSuccessful";
             }
 
        return View();
         }
        public ActionResult ContactUS()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ContactUS(ContactU contact)
        {
            if (ModelState.IsValid)
            {
                contact.ID = Guid.NewGuid();
                _db.ContactUs.Add(contact);
                _db.SaveChanges();
                TempData["flag"] = "added";
            }
                //return RedirectToAction("Index");

            // Otherwise, reshow form
                ModelState.Clear();
                return View();
        }

       // [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FooterPartial()
        {
            ContactU contact = new ContactU();
           // contact.ID = Guid.NewGuid();
            //_db.ContactUs.Add(contact);
            //_db.SaveChanges();
            //ModelState.Clear();
            return PartialView();
        }  
       
     }
}
