using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.DataAccess;
using Test.Repository.Interface;

namespace ExamApp.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public void Delete(Guid id)
        {
            var itemToRemove = context.Employee.SingleOrDefault(x => x.Id == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.Employee.Remove(itemToRemove);
                Save();
            }
        }

        public Employee Find(Guid id)
        {
            return context.Employee.Where(s => s.Id == id).FirstOrDefault();
        }

        public void InsertOrUpdate(Employee employee)
        {
            if (employee.Id == Guid.Empty)
            {
                // New entity
                context.Employee.Add(employee);
            }
            else
            {
                // Existing entity
                var s = context.Employee.Where(c => c.Id == employee.Id).FirstOrDefault();
                s.Name = employee.Name;
                s.Email = employee.Email;
                s.Attendance = employee.Attendance;
                s.OverTime = employee.OverTime;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
