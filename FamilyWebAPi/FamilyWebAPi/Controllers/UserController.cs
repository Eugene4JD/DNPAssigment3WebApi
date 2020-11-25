using System;
using System.Threading.Tasks;
using DNPAssigment1.Data;
using DNPAssigment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyWebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }


        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string login,[FromQuery] string password)
        {
            try
            {
                var user = await _userService.ValidateUserAsync(login, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            try
            {
                var newUser = await _userService.AddUserAsync(user);
                return Ok(newUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}