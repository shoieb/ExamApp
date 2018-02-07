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
        [HttpPost]
        public IActionResult GetUser([FromBody]User user)
        {
            try
            {
                var foundUser = _userService.FindUser(user);
                return Ok(foundUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}