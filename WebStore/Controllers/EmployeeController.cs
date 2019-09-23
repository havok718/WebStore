using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        // GET: Home
        [Route("all")]
        public ActionResult Index()
        {
            //return Content("Hello. I am your first Controller!");
            return View(_employeeServices.GetAll());
        }

        [Route("{id}")]
        public ActionResult Details(int id)
        {
            return View(_employeeServices.GetById(id));
        }

        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeView());

            EmployeeView model = _employeeServices.GetById(id.Value);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Id > 0) // if there is an Id - edit model
            {
                var dbItem = _employeeServices.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();

                dbItem.FirstName = model.FirstName;
                dbItem.LastName = model.LastName;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Age = model.Age;
            }
            else
            {
                _employeeServices.AddNew(model);
            }
            _employeeServices.Commit();

            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id?}")]
        public IActionResult Delete(int id)
        {
            _employeeServices.Delete(id);
            return RedirectToAction("Index");
        }
    }
}