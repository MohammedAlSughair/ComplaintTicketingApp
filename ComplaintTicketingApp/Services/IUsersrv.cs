using ComplaintTicketingApp.Models;

namespace ComplaintTicketingApp.Services
{
	public interface IUsersrv
	{
		IEnumerable<UserViewModel> GetAllUser();
		UserViewModel GetUser(UserViewModel userViewModel);
	}
}
