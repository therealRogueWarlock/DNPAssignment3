using System;
using System.Threading.Tasks;
using Data;
using DataAccess.model;
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
                
                User user = _userService.ValidateUser(userInfo.UserName,userInfo.Password);
                return Ok(user);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        
    }
    
    
}