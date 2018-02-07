using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Domain;
using ExamApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            var allUser = _userService.GetAll();
            return allUser;
        }
        [HttpGet("{id}")]
        public User GetById(Guid id)
        {
            var user = _userService.Find(id);
            return user;
        }

        [HttpPost]
        public IActionResult InsertOrUpdate([FromBody]User user)
        {
            _userService.Save(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            _userService.Delete(id);
            return Ok(id);
        }
    }
}