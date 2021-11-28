using System;
using System.Threading.Tasks;
using Blazor.Data;
using Data;
using Blazor.model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private IUserService _userService;


        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> ValidateUser([FromBody] User userInfo)
        {
            
            try
            {
                
                User user = await _userService.ValidateUser(userInfo.UserName,userInfo.Password);
                return Ok(user);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        
    }
    
    
}