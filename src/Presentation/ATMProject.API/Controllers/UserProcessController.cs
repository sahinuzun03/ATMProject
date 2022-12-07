using ATMProject.Application.Models.DTOs;
using ATMProject.Application.Services.UserProcessService;
using ATMProject.Application.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserProcessController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserProcessService _userProcessService;
        public UserProcessController(IUserService userService,IUserProcessService userProcessService)
        {
            _userService = userService;
            _userProcessService = userProcessService;
        }

        [HttpGet("{userID}")]
        public async Task<IActionResult> GetBalance(int userID)
        {
            var userBalance = _userProcessService.GetUserBalance(userID);
            if(userBalance != null)
            {
                return Ok(userBalance);
            }

            return BadRequest("Geçersiz İşlem");
        }

        [HttpPost("{userID}")]
        public async Task<ActionResult> MoneyWithdraw(int userID,[FromBody] ProcessDTO model)
        {
            var userProcess =  await _userProcessService.AddUserProcess(model, userID);
            
            if (userProcess != null)
            {
                return Ok(userProcess);
            }

            return BadRequest("İşlem Başarısız");
            
        }
    }
}
