using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;

		public LoginController(ILoginService loginService)
		{
			_loginService = loginService;
		}

		[HttpPost]
		public IActionResult Login([FromBody] LoginDto loginRequest)
		{
			// Valida las credenciales del usuario.

			if (!_loginService.IsValid(loginRequest?.Email ?? "", loginRequest?.Password ?? ""))
			{
				return BadRequest("Invalid credentials.");
			}
			return Ok();
		}
	}
}
