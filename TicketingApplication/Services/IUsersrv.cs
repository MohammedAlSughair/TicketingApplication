using  TicketingApplication.Models;

namespace  TicketingApplication.Services
{
	public interface IUsersrv
	{
		IEnumerable<UserViewModel> GetAllUser();
		UserViewModel GetUser(UserViewModel userViewModel);
	}
}
