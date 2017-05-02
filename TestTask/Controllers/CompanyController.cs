using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;
using TestTask.Repository;

namespace TestTask.Controllers
{
    public class CompanyController : Controller
    {
           
        public ActionResult GetAllCompanyDetails()
        {

            CompanyRepository CompRepository = new CompanyRepository();
            ModelState.Clear();
            return View(CompRepository.GetAllCompanies());
        }

       
        public ActionResult AddCompany()
        {
            return View();
        }

           
        [HttpPost]
        public ActionResult AddCompany(Company Comp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CompanyRepository CompRepository = new CompanyRepository();

                    if (CompRepository.AddCompany(Comp))
                    {
                        ViewBag.Message = "Company details added successfully";
                    }
                }

                return RedirectToAction("GetAllCompanyDetails");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult EditCompanyDetails(int id)
        {
            CompanyRepository CompRepository = new CompanyRepository();



            return View(CompRepository.GetAllCompanies().Find(Comp => Comp.CompanyId == id));

        }

            
        [HttpPost]

        public ActionResult EditCompanyDetails(int id, Company obj)
        {
            try
            {
                CompanyRepository CompRepository = new CompanyRepository();

                CompRepository.UpdateCompany(obj);




                return RedirectToAction("GetAllCompanyDetails");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                CompanyRepository CompRepository = new CompanyRepository();
                if (CompRepository.DeleteCompany(id))
                {
                    ViewBag.AlertMsg = "company details deleted successfully";

                }
                return RedirectToAction("GetAllCompanyDetails");

            }
            catch
            {
                return RedirectToAction("GetAllCompanyDetails");
            }
        }

        public ActionResult GetAllCompanies()
        {
            return RedirectToAction("GetAllCompanyDetails");
        }
    }
}
