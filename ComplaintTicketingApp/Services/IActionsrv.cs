using ComplaintTicketingApp.Models;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Services
{
	public interface IActionsrv
	{
		List<EntityConstantViewModel> GetTicketAction(int ticketId, int userid);

		bool CheckTickrtAction(Status oldstatus, Status newstatus, int userid);

		int ReturnStatusFromAction(TicketAction ticketAction, int userid);
	}
}
