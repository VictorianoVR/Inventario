using inventario.Data;
using inventario.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace inventario.Controllers
{
	public class LoginController : Controller
	{

		public  IActionResult Login()
		{
			
			return View();
		}

		[HttpPost]
		public IActionResult RedLogin(LoginDto model)
		{
			try
			{
				GetDataLoginUser getData = new GetDataLoginUser();
				var result = getData.getData(model?.Email ?? "", model?.Password ?? "");
				if (result !=  null && result.IsSuccessStatusCode) 
				{ return RedirectToAction("Home","Home"); }
				return RedirectToAction("Login");
				

			}
			catch (Exception e)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}
	}
}
