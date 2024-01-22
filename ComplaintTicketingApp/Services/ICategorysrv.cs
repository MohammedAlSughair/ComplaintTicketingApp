using ComplaintTicketingApp.Models;

namespace ComplaintTicketingApp.Services
{
	public interface ICategorysrv
	{
		IEnumerable<CategoryViewModel> GetCategory();
	}
}
