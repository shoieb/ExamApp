using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Domain;
using ExamApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            var allEmployee = _employeeService.GetAll();
            return allEmployee;
        }
        [HttpGet("{id}")]
        public Employee GetById(Guid id)
        {
            var employee = _employeeService.Find(id);
            return employee;
        }

        [HttpPost]
        public IActionResult InsertOrUpdate([FromBody]Employee employee)
        {
            _employeeService.Save(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            _employeeService.Delete(id);
            return Ok(id);
        }
    }
}