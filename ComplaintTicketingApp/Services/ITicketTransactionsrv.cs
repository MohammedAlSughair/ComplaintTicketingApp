using ComplaintTicketingApp.Models;

namespace ComplaintTicketingApp.Services
{
	public interface ITicketTransactionsrv
	{
		IEnumerable<TicketTransactionViewModel> GetTransaction(int TicketId);
	}
}
