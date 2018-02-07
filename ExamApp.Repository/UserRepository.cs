using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.DataAccess;
using Test.Repository.Interface;

namespace ExamApp.Repository
{
    public class UserRepository : IRepository<User>
    {
        AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<User> GetAll()
        {
            return context.User.ToList();
        }

        public void Delete(Guid id)
        {
            var itemToRemove = context.User.SingleOrDefault(x => x.Id == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.User.Remove(itemToRemove);
                Save();
            }
        }

        public User Find(Guid id)
        {
            return context.User.Where(s => s.Id == id).FirstOrDefault();
        }

        public void InsertOrUpdate(User user)
        {
            if (user.Id == Guid.Empty)
            {
                // New entity
                context.User.Add(user);
            }
            else
            {
                // Existing entity
                var s = context.User.Where(c => c.Id == user.Id).FirstOrDefault();
                s.UserName = user.UserName;
                s.Password = user.Password;
                s.Role = user.Role;
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
