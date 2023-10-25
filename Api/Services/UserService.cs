using API.Dtos;
using API.Models;

namespace API.Services
{
	public class UserService
	{
		UserService(LoginDto model)
		{


			var modelData = new User()
			{
				Email = model.Email ?? "",
				Password = model.Password ?? ""
			};


		}
	}
}