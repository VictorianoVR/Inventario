using inventario.Data;
using Microsoft.AspNetCore.Mvc;


namespace inventario.Controllers
{
	public class InventarioController : Controller
	{
		[HttpPost]
		public IActionResult Inventario()
		{
			//GetDataProducts getData = new GetDataProducts();
			//var result = getData.GetProducts();
			return View();
		}

	}	
}
