using inventario.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace inventario.Data

{
	public class GetDataLoginUser
	{
		public HttpResponseMessage getData(string username, string password)
		{
			// Crea una instancia del cliente de API web
			var client = new HttpClient();

			// Crea una solicitud HTTP
			var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5214/api/Login");

			LoginDto requestContent = new() { Email = username, Password = password };
			request.Content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");

			// Envia la solicitud
			return client.Send(request);
		}

		string StreamToString(Stream stream)
		{
			stream.Position = 0;
			using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
			return reader.ReadToEnd();
		}
	}
}