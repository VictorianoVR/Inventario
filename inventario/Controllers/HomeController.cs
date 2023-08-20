using inventario.Models;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }
        public IActionResult Inventario()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		//login
		[HttpPost]
		public IActionResult RedLogin(LoginViewModel model)
		{
			try
			{
				
				var modelData = new Usuario()
				{
					CorreoElectronico = model.CorreoElectronico ?? "",
					Password = model.Password ?? ""


				};
				Datos.UsuarioLogin(modelData);
				var res = Datos.UsuarioLogin(modelData);
				
				if (res != null) 
				{
					return RedirectToAction("Index");

				}
				
				return RedirectToAction("Login");
			}
			catch (Exception e)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
			//try
			//{
			//    var result = Datos.UsuarioLogin(correoElectronico, password);
			//    if (result == null)
			//        return StatusCode((int)HttpStatusCode.NotFound, "Usuario o Clave Incorrecto");


			//}
			//catch (Exception e)
			//{
			//    return StatusCode((int)HttpStatusCode.InternalServerError);
			//}
			//return View();
		}

		public IActionResult Login()
		{

			return View();
		}
		[HttpPost]
		public IActionResult PostProducto(ProductoViewModel model)
		{
			try
			{
				var modelData = new Producto()
				{
					IdProducto = model.IdProducto ?? "",
					Nombre = model.Nombre ?? "",
					Unidades = model.Unidades ?? 0,
					Precio = model.Precio ?? 0

				};

				Datos.CrearProducto(modelData);
				return RedirectToAction("Index");

			}
			catch (Exception e)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}

		}
		public IActionResult ModificarProducto(ProductoViewModel model)
		{
			try
			{
				var modelData = new Producto()
				{
					IdProducto = model.IdProducto ?? "",
					Nombre = model.Nombre ?? "",
					Unidades = model.Unidades ?? 0,
					Precio = model.Precio ?? 0

				};

				Datos.ModificarProducto(modelData);
				return RedirectToAction("Index");

			}
			catch (Exception e)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}

		}
		public IActionResult BuscarProducto(ProductoViewModel model)
		{
			try
			{
				var modelData = new Producto()
				{
					IdProducto = model.IdProducto ?? "",
					Nombre = model.Nombre ?? "",
				};

				Datos.BuscarProducto(modelData);
				return RedirectToAction("Inventario");

			}
			catch (Exception e)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}

		}

	}
}

    
