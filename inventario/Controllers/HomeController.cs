
using inventario.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace inventario.Controllers
{
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;	
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

		public IActionResult Inventario()
		{
			//return View();
			try
			{
				GetDataProducts getDataProducts = new GetDataProducts();
				var products = getDataProducts.GetProducts();

				// Devuelve el listado de productos a la vista
				return View(products);

			}
			catch (Exception e)
			{

					return StatusCode((int)HttpStatusCode.InternalServerError);
			}

		}
		public IActionResult searchInventario()
		{
			//return View();
			try
			{
				GetDataProducts getDataProducts = new GetDataProducts();
				var products = getDataProducts.GetProducts();

				// Devuelve el listado de productos a la vista
				return View(products);

			}
			catch (Exception e)
			{

				return StatusCode((int)HttpStatusCode.InternalServerError);
			}

		}




		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       
	

		public IActionResult Login()
		{

			return View();
		}
	
	}
}

    
