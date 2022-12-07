using ATMProject.Application.Models.DTOs;
using ATMProject.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ATMProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDTO model)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(model);
                
                return Ok("Kullanıcı Başarıyla Eklendi");
            }

            return StatusCode(500);
        }
    }
}
