using ManageEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageEmployees.Controllers
{
    public class EmployeeController : Controller
    {
        //Mock data
        List<Employee> employees = new List<Employee>() {
                new Employee() {Id=1, Name="Ram", City="Delhi", Salary=10000 },
               new Employee() {Id=1, Name="Raj", City="Mumbai", Salary=20000 },
                new Employee() {Id=1, Name="Rahul", City="Banglore", Salary=15000 }
            };
        public ActionResult Index()
        {
            if (Session["EmployeesData"] != null)
            {
                employees = (List<Employee>)Session["EmployeesData"];
            }
            else
            {
                Session["EmployeesData"] = employees;
            }
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create an employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var data = employees;
            employee.Id = data.Count() + 1;
            employees.Add(employee);
            Session["EmployeesData"] = employees;

            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("index");
        }

        /// <summary>
        /// Edit employee detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if(Session["EmployeesData"] != null)
            {
                employees = (List<Employee>)Session["EmployeesData"];
            }
            var data = employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var editedEmployee = employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (editedEmployee != null)
            {
                editedEmployee.City = employee.City;
                editedEmployee.Name = employee.Name;
                editedEmployee.Salary = employee.Salary;
            }
            //TODO: with entity framework its easy with modify but here with mock data 
            employees.Remove(employees.Where(x => x.Id == employee.Id).FirstOrDefault());
            employees.Add(editedEmployee);
            Session["EmployeesData"] = employees;

            return RedirectToAction("index");
        }

        /// <summary>
        /// View an employee details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        /// <summary>
        /// Delete an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var data = employees.Where(x => x.Id == id).FirstOrDefault();
            employees.Remove(data);
            Session["EmployeesData"] = employees;
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        /// <summary>
        /// mock data
        /// </summary>
        /// <returns></returns>
        private List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>() {
                new Employee() {Id=1, Name="Ram", City="Delhi", Salary=10000 },
               new Employee() {Id=2, Name="Raj", City="Mumbai", Salary=20000 },
                new Employee() {Id=3, Name="Rahul", City="Banglore", Salary=15000 }
            };
            return employees;
        }  // GET: Employee

    }
}