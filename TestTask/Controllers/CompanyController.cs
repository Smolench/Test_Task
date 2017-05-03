using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using DataAccess;
using DataModels;
using TestTask.Models;


namespace TestTask.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyDataAccess companyAccess;

        public CompanyController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
            companyAccess = new CompanyDataAccess(connectionString);
        }
           
        public ActionResult GetAllCompanyDetails()
        {
            try
            {
                List<CompanyModel> companyModels = new List<CompanyModel>();

                foreach (var company in companyAccess.GetAllCompanies())
                {
                    companyModels.Add(CopyDataToViewModel(company));
                }

                return View(companyModels);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        private CompanyModel CopyDataToViewModel(Company company)
        {
            return new CompanyModel()
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                Size = company.Size,
                Form = company.Form,
            };
        }

        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }

           
        [HttpPost]
        public ActionResult AddCompany(CompanyModel comp)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    companyAccess.AddCompany(CopyDataToCompany(comp));

                    return RedirectToAction("GetAllCompanyDetails");
                }
                catch
                {
                    return RedirectToAction("Error", "Main");
                }
            }

            return View();
        }

        private Company CopyDataToCompany(CompanyModel comp)
        {
            return new Company()
            {
                CompanyId = comp.CompanyId,
                Name = comp.Name,
                Size = comp.Size,
                Form = comp.Form,
            };
        }

        [HttpGet]
        public ActionResult EditCompanyDetails(int id)
        {
            try
            {
                CompanyModel companyModel = CopyDataToViewModel(companyAccess.GetCompany(id));

                return View(companyModel);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }

        }

            
        [HttpPost]
        public ActionResult EditCompanyDetails(CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Company company = CopyDataToCompany(companyModel);
                    companyAccess.EditCompany(company.CompanyId, company);

                    return RedirectToAction("GetAllCompanyDetails");
                }
                catch
                {
                    return RedirectToAction("Error", "Main");
                }
            }

            return View(companyModel);
        }

       
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                companyAccess.DeleteCompany(id);
                return RedirectToAction("GetAllCompanyDetails");
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        
    }
}
