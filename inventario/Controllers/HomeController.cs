using inventario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoDCU.Models;
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
        public IActionResult Login(string correoElectronico, string password)
        {
        //    try
        //    {
        //        var result = Datos.UsuarioLogin(correoElectronico, password);
        //        if (result == null)
        //            return StatusCode((int)HttpStatusCode.NotFound, "Usuario o Clave Incorrecto");


        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
            return View();
        }

    }
}