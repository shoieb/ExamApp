using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Test.Repository;
using Test.Service.Interface;

namespace ExamApp.Service
{
    public interface IEmployeeService : IService<Employee>
    { }
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork unit;

        public EmployeeService(AppDbContext context)
        {
            unit = new UnitOfWork(context);
        }

        public List<Employee> GetAll()
        {
            return unit.EmployeeRepository.GetAll();
        }

        public void Save(Employee employee)
        {
            unit.EmployeeRepository.InsertOrUpdate(employee);
            unit.EmployeeRepository.Save();
        }

        public void Delete(Guid id)
        {
            unit.EmployeeRepository.Delete(id);
        }

        public Employee Find(Guid id)
        {
            return unit.EmployeeRepository.Find(id);
        }
    }
}
