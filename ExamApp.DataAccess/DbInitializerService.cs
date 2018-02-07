using ExamApp.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.DataAccess
{
    public interface IDbInitializerService
    {
        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        void SeedData();
    }
    public class DbInitializerService : IDbInitializerService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    // Add default user
                    var user1 = new User { Id = new Guid(), UserName = "manager", Password = "test1", Role= "manager" };
                    var user2 = new User { Id = new Guid(), UserName = "hr", Password = "test2", Role = "manager" };
                    if (!context.User.Any())
                    {
                        context.Add(user1);
                        context.Add(user1);
                        context.SaveChanges();
                    }
                    
                }
            }
        }

    }
}
