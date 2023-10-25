using API.Repositories;

namespace API.Services
{
	public class LoginService : ILoginService
	{
		private readonly IUserRepository _userRepository;

		public LoginService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public bool IsValid(string? email, string? password)
		{
			// Valida las credenciales del usuario.

			var user = _userRepository.GetUserByUsername(email ?? "");

			return user != null && user.Password == password;
		}
	}
}