using MicroMultiBusiness.IdentityServer.DTOs;
using MicroMultiBusiness.IdentityServer.Models;
using MicroMultiBusiness.IdentityServer.Tools;
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
		private readonly UserManager<ApplicationUser> _userManager;

		public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDTO)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDTO.UserName, userLoginDTO.Password, false, false);
			var user = await _userManager.FindByNameAsync(userLoginDTO.UserName);

			if (result.Succeeded)
			{
				GetCheckAppUserVM model = new GetCheckAppUserVM();
				model.UserName = userLoginDTO.UserName;
				model.Id = user.Id;
				var token = JwtTokenGenereator.GenerateToken(model);
				return Ok(token);
			}

			return Ok("Invalid User Name or Password");
		}
	}
}
