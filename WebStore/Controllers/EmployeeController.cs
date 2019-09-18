using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly List<EmployeeView> _employees = new List<EmployeeView>()
        {
            new EmployeeView
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Пузиков",
                Patronymic = "Сергеевич",
                Age = 22
            },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Петр",
                LastName = "Копайгородский",
                Patronymic = "Васильевич",
                Age = 38
            }
        };

        // GET: Home
        public ActionResult Index()
        {
            //return Content("Hello. I am your first Controller!");
            return View(_employees);
        }

        public ActionResult Details(int id)
        {
            return View(_employees.FirstOrDefault(x => x.Id == id));
        }
    }
}