using API.Dtos;
using API.Models;
using API.Services;
using FluentNHibernate.Automapping;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddProcdutController : ControllerBase
	{
		private readonly IProductService _productservice;

		public AddProcdutController(IProductService productservice)
		{
			
			_productservice = productservice;
		}
		
		[HttpPost]
		public IActionResult AddProduct([FromBody] Product product)
		{
			// Agrega el producto 
			_productservice.CreateProduct(product);

			// Devuelve una respuesta al cliente
			return Ok();
		}
	}
}
