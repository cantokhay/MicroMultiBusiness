using MicroMultiBusiness.IdentityServer.DTOs;
using MicroMultiBusiness.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroMultiBusiness.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;

		public LoginsController(SignInManager<ApplicationUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDTO)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDTO.UserName, userLoginDTO.Password, false, false);
			if (result.Succeeded)
			{
				return Ok("Login Succesfully!");
			}

			return Ok("Invalid User Name or Password");
		}
	}
}
