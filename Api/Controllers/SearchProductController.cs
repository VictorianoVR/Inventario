using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SearchProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public SearchProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult Get(string idType)
		{
			var products = _productService.GetProduct(idType);

			return Ok(products);
		}
	}
}
