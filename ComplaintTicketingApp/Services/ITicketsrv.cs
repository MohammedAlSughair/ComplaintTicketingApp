using ComplaintTicketingApp.Models;

namespace ComplaintTicketingApp.Services
{
	public interface ITicketsrv
	{
		IEnumerable<TicketViewModel> GetAllTicket(string userid, string usertype);
		TicketViewModel GetTicket(int id);
		bool AddTicket(TicketFormViewModel ticket);
		bool UpdateTicketStatus(TicketFormViewModel ticketForm, int userid);
	}
}
