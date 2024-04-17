using  TicketingApplication.Models;

namespace  TicketingApplication.Services
{
	public interface IUserService
	{
		IEnumerable<UserViewModel> GetAllUser();
		UserViewModel GetUser(UserViewModel userViewModel);
	}
}
