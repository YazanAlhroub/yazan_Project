using Microsoft.AspNetCore.Mvc;
using mo3askerpro2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Controllers
{
    public class EmployeesController : Controller
    {
       
        private Applicationdbcontext db;
        public EmployeesController(Applicationdbcontext _db)
        {
            db = _db;

        }
        public IActionResult Index()
        {
            return View(db.employees);
        }
        public IActionResult Details(int id)
        {
            var Employee = db.employees.Find(id);
                return View(Employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)

        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Employee = db.employees.Find(id);
            return View(Employee);

        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Update(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = db.employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
