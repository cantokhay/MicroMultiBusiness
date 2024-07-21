using MicroMultiBusiness.IdentityServer.DTOs;
using MicroMultiBusiness.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MicroMultiBusiness.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDTO userRegisterDTO)
        {
            var user = new ApplicationUser()
            {
                UserName = userRegisterDTO.Username,
                Email = userRegisterDTO.Email,
                Name = userRegisterDTO.Name,
                LastName = userRegisterDTO.LastName
            };
            var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);
            if (result.Succeeded)
            {
                return Ok("Register Successfully");
            }
            else
            {
                return Ok("There is an error while registering!!!");
            }
        }
    }
}
