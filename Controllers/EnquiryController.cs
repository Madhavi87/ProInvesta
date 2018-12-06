using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProInvesta.Models;
namespace ProInvesta.Controllers
{
    public class EnquiryController : Controller
    {
        DB_A34082_proinvestaEntities _db;
        public EnquiryController()
        {
            _db = new DB_A34082_proinvestaEntities();
        }
     
        public ActionResult Create()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="New", Value = "New" },
                new SelectListItem{ Text="Resale", Value = "Resale" },
                new SelectListItem{ Text="Take Over", Value = "Take Over"},
            }; 

            var list1 = new List<SelectListItem>
             {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="Yes", Value = "Yes" },
                new SelectListItem{ Text="No", Value = "No" },
            }; 

            ViewData["LoanType"] = list;
            ViewData["RinnRaksha"] = list1;
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoanData obj)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="New", Value = "New" },
                new SelectListItem{ Text="Resale", Value = "Resale" },
                new SelectListItem{ Text="Take Over", Value = "Take Over"},
            };

            var list1 = new List<SelectListItem>
             {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="Yes", Value = "Yes" },
                new SelectListItem{ Text="No", Value = "No" },
            };

            ViewData["LoanType"] = list;
            ViewData["RinnRaksha"] = list1;
            try
            {
                if (ModelState.IsValid)
                {

                    obj.createdby = Convert.ToString(Session["UserName"]);
                    _db.LoanDatas.Add(obj);
                    _db.SaveChanges();
                   return RedirectToAction("Listing");  
                }
                   
                else
                {
                   return RedirectToAction("Create");  

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create");  

            }

            
        }

        public ActionResult View(int id)
        {
            /*var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="New", Value = "New" },
                new SelectListItem{ Text="Resale", Value = "Resale" },
                new SelectListItem{ Text="Take Over", Value = "Take Over"},
            };

            var list1 = new List<SelectListItem>
             {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="Yes", Value = "Yes" },
                new SelectListItem{ Text="No", Value = "No" },
            };

            ViewData["LoanType"] = list;
            ViewData["RinnRaksha"] = list1;
            */
            try
            {
                var data = _db.LoanDatas.Where(m => m.ID == id).FirstOrDefault();
                return View(data);
            }
            catch
            {
                return RedirectToAction("Listing");
            }
        }

        public ActionResult Edit(int id)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="New", Value = "New" },
                new SelectListItem{ Text="Resale", Value = "Resale" },
                new SelectListItem{ Text="Take Over", Value = "Take Over"},
            };

            var list1 = new List<SelectListItem>
             {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="Yes", Value = "Yes" },
                new SelectListItem{ Text="No", Value = "No" },
            };

            ViewData["LoanType"] = list;
            ViewData["RinnRaksha"] = list1;

            try
            {
                var data = _db.LoanDatas.Where(m => m.ID == id).FirstOrDefault();
                return View(data);
            }
            catch
            {
                return RedirectToAction("Listing");
            }
        }

        [HttpPost]
        public ActionResult Edit(LoanData obj)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="New", Value = "New" },
                new SelectListItem{ Text="Resale", Value = "Resale" },
                new SelectListItem{ Text="Take Over", Value = "Take Over"},
            };

            var list1 = new List<SelectListItem>
             {
                new SelectListItem{ Text="--Select--", Value = "", Selected=true},
                new SelectListItem{ Text="Yes", Value = "Yes" },
                new SelectListItem{ Text="No", Value = "No" },
            };

            ViewData["LoanType"] = list;
            ViewData["RinnRaksha"] = list1;

            try
            {
                var data = _db.LoanDatas.Where(m => m.ID == obj.ID).FirstOrDefault();
                data.Loan_Amount = obj.Loan_Amount;
                data.Loan_No = obj.Loan_No;
                data.Loan_Type = obj.Loan_Type;
                data.Login_Date = obj.Login_Date;
                data.Mobile_No = obj.Mobile_No;
                data.Name = obj.Name;
                data.Rinn_Raksha = obj.Rinn_Raksha;
                data.Sourcing_Person = obj.Sourcing_Person;
                data.Sourcing_Branch = obj.Sourcing_Branch;
                _db.SaveChanges();
                return RedirectToAction("Listing");
            }
            catch
            {
                return RedirectToAction("Edit",obj.ID);
            }
        }

        public ActionResult Delete(int id)
        {
           
            try
            {
                var data =_db.LoanDatas.Where(m => m.ID == id).FirstOrDefault();
                _db.LoanDatas.Remove(data);
                _db.SaveChanges();
                return RedirectToAction("Listing");
            }
            catch
            {
                return RedirectToAction("Listing");
            }
        }

        public ActionResult Listing() 
        {
            var user = Convert.ToString(Session["UserName"]);
            if (user == "admin")
            {
                var data = _db.LoanDatas.ToList();
                return View(data);
            }
            else
            {
                var data = _db.LoanDatas.Where(m => m.createdby == user).ToList();
                return View(data);
            }
        }

        public ActionResult Enquiry()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Enquiry(Enquiry enquiry)
        {
            try
            {
                var success = false;
                if (ModelState.IsValid)
                {
                    enquiry.ID = Guid.NewGuid();
                    _db.Enquiries.Add(enquiry);
                    _db.SaveChanges();
                    success =true;
                }

                if (success)
                {
                    TempData["Success"] = "added";
                    if (enquiry.LoanType == "Home")
                        return Redirect("~/Loan/HomeLoan");
                    else if (enquiry.LoanType == "Car")
                        return Redirect("Enquiry?LoanType=Car");
                    else if (enquiry.LoanType == "Personal")
                        return Redirect("Enquiry?LoanType=Personal");
                    else
                    {
                        TempData["Success"] = "";
                        return View();
                    }
                }
                else
                {
                    TempData["Success"] = "";
                    return View();
                }
               
               
                //ModelState.Clear();
            }
            catch(Exception e){
                
                return View();
            }
            
            
        }

        public ActionResult EnquiryListing()
        {

            DB_A34082_proinvestaEntities dc = new DB_A34082_proinvestaEntities();
            
                // dc.Conf                          iguration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var data = dc.Enquiries.ToList();
  
            return View( data);

        }

    }
}
