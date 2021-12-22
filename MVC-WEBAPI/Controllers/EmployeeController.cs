using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC_WEBAPI.Data.WebApiData;

namespace MVC_WEBAPI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employee = EmployeeWebApi.GetEmployee();
            return View(employee);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee employee = EmployeeWebApi.GetEmployee(id);
            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            return View(employees);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            bool result = EmployeeWebApi.EditEmployee(employee);
            if (result)
            {
                return RedirectToAction("/");
            }
            return RedirectToAction("/");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = EmployeeWebApi.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            bool result = EmployeeWebApi.EditEmployee(employee);
            if (result)
            {
                return RedirectToAction("/");
            }
            return RedirectToAction("/");
        }
        public ActionResult Delete(int id) 
        {
            bool result = EmployeeWebApi.DeleteEmployee(id);
            if (result)
            {
                return RedirectToAction("/");
            }
            return RedirectToAction("unsucces");
        }
        public PartialViewResult _Create()
        {
            return PartialView();
        }

        
        }
        
        
    }
