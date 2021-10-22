using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAppModels;
using DbMyApp.DbOperations;

namespace EFApproachwithMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repository = null;

        public HomeController()
        {
            repository = new EmployeeRepository();
        }
        // GET: Home
        public ActionResult  Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);
                if(id>0)
                {
                    ModelState.Clear();
                    ViewBag.IsSucess ="Data SAVED";
                }
            }
            return View();
        }
        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllEmpolyees();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = repository.GetEmpolyee(id);
            return View(result);
        }

        public ActionResult  Edit(int id)
        {
            var result = repository.GetEmpolyee(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                repository.UpdateEmpolyee(model.Id, model);
                return RedirectToAction("GetAllRecords");
            }
             return View();
        }
        
        public ActionResult  Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteEmployee(id);
                return RedirectToAction("GetAllRecords");
            }
            return View();
        }






    }
}