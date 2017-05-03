using System.Web.Mvc;
using TestTask.Models;
using TestTask.Repository;

namespace TestTask.Controllers
{
    public class CompanyController : Controller
    {
           
        public ActionResult GetAllCompanyDetails()
        {

            CompanyRepository compRepository = new CompanyRepository();
            ModelState.Clear();
            return View(compRepository.GetAllCompanies());
        }

       
        public ActionResult AddCompany()
        {
            return View();
        }

           
        [HttpPost]
        public ActionResult AddCompany(Company comp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CompanyRepository compRepository = new CompanyRepository();

                    if (compRepository.AddCompany(comp))
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
            CompanyRepository compRepository = new CompanyRepository();



            return View(compRepository.GetAllCompanies().Find(comp => comp.CompanyId == id));

        }

            
        [HttpPost]

        public ActionResult EditCompanyDetails(int id, Company obj)
        {
            try
            {
                CompanyRepository compRepository = new CompanyRepository();

                compRepository.UpdateCompany(obj);




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
                CompanyRepository compRepository = new CompanyRepository();
                if (compRepository.DeleteCompany(id))
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

        public ActionResult Home()
        {
            return View("~/Views/Main/Index.cshtml");
        }
    }
}
