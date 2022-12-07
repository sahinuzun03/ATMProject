using ATMProject.Application.Models.DTOs;
using ATMProject.Application.Services.UserService;
using ATMProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService) => _userService= userService;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            var token = await _userService.Login(loginDTO);
            if(token != null)
            {
                return Ok(token);
            }

            return NotFound();
        }
    }
}
