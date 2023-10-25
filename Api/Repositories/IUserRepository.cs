using API.Models;

namespace API.Repositories
{
		public interface IUserRepository
		{
			User GetUserByUsername(string email);
			//Task<User> SaveUser(User user);
			//Task<User> UpdateUser(User user);
			//Task DeleteUser(string username);
		}
	
}
