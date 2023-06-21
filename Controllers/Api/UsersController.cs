using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mo3askerpro2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
      

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
          
        }
        [HttpDelete]
        public async Task< IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
             return NotFound();

           var result= await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
             throw new Exception();

            return Ok();
        } 
    }
}
