using Azure.Core;
using inventario.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace inventario.Data
{
	public class GetDataProducts : ProductDto
	{
		public HttpResponseMessage getData()
		{
			// Crea una instancia del cliente de API web
			var client = new HttpClient();

			// Crea una solicitud HTTP
			var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5214/api/Product");
			//ProductDto requestContent = new() { };
			//request.Content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");
			// Envia la solicitud
			return client.Send(request);
		}

		string StreamToString(Stream stream)
		{
			stream.Position = 0;
			using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
			return reader.ReadToEnd();
		}
		[HttpGet]
		public List<ProductDto> GetProducts()
		{
		
		var getDataProducts = new GetDataProducts();

				// Obtiene la respuesta HTTP
				var response = getDataProducts.getData();

				// Verifica el código de estado de la respuesta HTTP
			// Obtiene el cuerpo de la respuesta HTTP
					var content = response.Content;

					// Convierte el cuerpo de la respuesta HTTP a una cadena JSON
					var stringContent = StreamToString(content.ReadAsStream());

					// Deserializa la cadena JSON a una lista de objetos ProductDto
					var products = JsonConvert.DeserializeObject<List<ProductDto>>(stringContent);

					return  products;
		
		}
		[HttpGet]
		public List<ProductDto> GetProducts(string idType)
		{

			var getDataProducts = new GetDataProducts();

			// Obtiene la respuesta HTTP
			var response = getDataProducts.getData();

			// Verifica el código de estado de la respuesta HTTP
			// Obtiene el cuerpo de la respuesta HTTP
			var content = response.Content;

			// Convierte el cuerpo de la respuesta HTTP a una cadena JSON
			var stringContent = StreamToString(content.ReadAsStream());

			// Deserializa la cadena JSON a una lista de objetos ProductDto
			var products = JsonConvert.DeserializeObject<List<ProductDto>>(stringContent);

			return products;

		}
	}
}
