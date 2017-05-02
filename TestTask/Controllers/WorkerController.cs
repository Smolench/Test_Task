using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;
using TestTask.Repository;

namespace TestTask.Controllers
{
    public class WorkerController : Controller
    {
           
        public ActionResult GetAllWorkerDetails()
        {

            WorkerRepository WorkRepository = new WorkerRepository();
            ModelState.Clear();
            return View(WorkRepository.GetAllWorkers());
        }

         
        public ActionResult AddWorker()
        {
            return View();
        }

           
        [HttpPost]
        public ActionResult AddWorker(Worker worker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WorkerRepository WorkRepository = new WorkerRepository();

                    if (WorkRepository.AddWorker(worker))
                    {
                        ViewBag.Message = "Worker details added successfully";
                    }
                }

                return RedirectToAction("GetAllWorkerDetails");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult EditWorkerDetails(int id)
        {
            WorkerRepository WorkRepository = new WorkerRepository();


            return View(WorkRepository.GetAllWorkers().Find(worker => worker.WorkerId == id));

        }



        [HttpPost]
        public ActionResult EditWorkerDetails(int id, Worker obj)
        {
            try
            {
                WorkerRepository WorkRepository = new WorkerRepository();


                WorkRepository.UpdateWorker(obj);

                return RedirectToAction("GetAllWorkerDetails");
            }
            catch
            {
                return RedirectToAction("GetAllWorkerDetails");
            }
        }

         
        public ActionResult DeleteWorker(int id)
        {
            try
            {
                WorkerRepository WorkRepository = new WorkerRepository();
                if (WorkRepository.DeleteWorker(id))
                {
                    ViewBag.AlertMsg = "Worker details deleted successfully";

                }
                return RedirectToAction("GetAllWorkerDetails");

            }
            catch
            {
                return RedirectToAction("GetAllWorkerDetails");
            }
        }

        public ActionResult GetAllWorkers()
        {
            return RedirectToAction("GetAllWorkerDetails");
        }
    }
}
