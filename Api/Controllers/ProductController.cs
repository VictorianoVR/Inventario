using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var products =  _productService.GetProduct();

			return Ok(products);
		}
		
	}
}
