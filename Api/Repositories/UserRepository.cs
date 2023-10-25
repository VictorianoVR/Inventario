
using API.Context;
using API.Models;
using API.Repositories;


namespace Api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly InventarioDbContext _dbContext;

		public UserRepository(InventarioDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public  User GetUserByUsername(string email)
		{ 
			return  _dbContext.Users.FirstOrDefault(u => u.Email == email);		 
		}

		//public async Task<User> SaveUser(User user)
		//{
		//	return await _dbContext.Users.AddAsync(user);
		//}

		//public async Task<User> UpdateUser(User user)
		//{
		//	return await _dbContext.Users.ExecuteUpdateAsync(user);
		//}

		//public Task DeleteUser(string username)
		//{
		//	return _dbContext.Users.Where(u => u.Username == username).DeleteAsync();
		//}
	}
}
