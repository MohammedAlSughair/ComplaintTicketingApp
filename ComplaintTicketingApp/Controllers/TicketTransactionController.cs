using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/ticket/{ticketid}/tickettransaction")]
	[ApiController]
	public class TicketTransactionController : ControllerBase
	{
		private readonly ITicketTransactionsrv _ticketTransactionsrv;
		public TicketTransactionController(ITicketTransactionsrv ticketTransactionsrv)
		{
			_ticketTransactionsrv = ticketTransactionsrv;
		}

		[HttpGet]
		public IActionResult Get(int ticketid)
		{
			return Ok(_ticketTransactionsrv.GetTransaction(ticketid));
		}
	}
}
