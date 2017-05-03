using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataModels;
using TestTask.Models;


namespace TestTask.Controllers
{
    public class WorkerController : Controller
    {
        private CompanyDataAccess companyAccess;
        private WorkerDataAccess workerAccess;

        public WorkerController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
            workerAccess = new WorkerDataAccess(connectionString);
            companyAccess = new CompanyDataAccess(connectionString);
        }

        public ActionResult GetAllWorkerDetails()
        {
            try
            {
                List<WorkerModel> workerModels = new List<WorkerModel>();

                foreach (var worker in workerAccess.GetAllWorkers())
                {
                    WorkerModel workerModel = CopyDataToModel(worker);
                    workerModel.Company = CopyDataToModel(companyAccess.GetCompany(workerModel.WorkerId));
                    workerModels.Add(workerModel);
                }
                return View(workerModels);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        private WorkerModel CopyDataToModel(Worker worker)
        {
            return new WorkerModel()
            {
                WorkerId = worker.WorkerId,
                LastName = worker.LastName,
                FirstName = worker.FirstName,
                MiddleName = worker.MiddleName,
                EntryDate = worker.EntryDate,
                Position = worker.Position,
                CompanyId = worker.CompanyId,
            };
        }

        private CompanyModel CopyDataToModel(Company company)
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
        public ActionResult AddWorker()
        {
            try
            {
                ViewBag.Companies = companyAccess.GetAllCompanies();
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

           
        [HttpPost]
        public ActionResult AddWorker(WorkerModel worker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    workerAccess.AddWorker(CopyDataToWorker(worker));

                    return RedirectToAction("GetAllWorkerDetails");
                }

                ViewBag.Companies = companyAccess.GetAllCompanies();
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        private Worker CopyDataToWorker(WorkerModel worker)
        {
            return new Worker()
            {
                WorkerId = worker.WorkerId,
                LastName = worker.LastName,
                FirstName = worker.FirstName,
                MiddleName = worker.MiddleName,
                EntryDate = worker.EntryDate,
                Position = worker.Position,
                CompanyId = worker.CompanyId,
            };
        }

        [HttpGet]
        public ActionResult EditWorkerDetails(int id)
        {
            try
            {
                WorkerModel workerwModel = CopyDataToModel(workerAccess.GetWorker(id));
                ViewBag.Companies = companyAccess.GetAllCompanies();
                return View(workerwModel);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }



        [HttpPost]
        public ActionResult EditWorkerDetails(WorkerModel workerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Worker worker = CopyDataToWorker(workerModel);
                    workerAccess.EditWorker(worker.WorkerId, worker);

                    return RedirectToAction("GetAllWorkerDetails");
                }

                ViewBag.Companies = companyAccess.GetAllCompanies();
                return View(workerModel);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

         
        public ActionResult DeleteWorker(int id)
        {
            try
            {
                workerAccess.DeleteWorker(id);
                return RedirectToAction("GetAllWorkerDetails");

            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        
    }
}
