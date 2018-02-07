using ExamApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;
using Test.Repository;
using Test.Service.Interface;

namespace ExamApp.Service
{
    public interface IUserService : IService<User>
    { }
    public class UserService : IUserService
    {
        private readonly UnitOfWork unit;

        public UserService(AppDbContext context)
        {
            unit = new UnitOfWork(context);
        }

        public List<User> GetAll()
        {
            return unit.UserRepository.GetAll();
        }

        public void Save(User user)
        {
            unit.UserRepository.InsertOrUpdate(user);
            unit.UserRepository.Save();
        }

        public void Delete(Guid id)
        {
            unit.UserRepository.Delete(id);
        }

        public User Find(Guid id)
        {
            return unit.UserRepository.Find(id);
        }
    }
}
