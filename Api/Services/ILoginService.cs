namespace API.Services
{
	public interface ILoginService
	{
		bool IsValid(string email, string password);
	}
}
