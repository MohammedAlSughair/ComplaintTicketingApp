using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActionController : ControllerBase
	{
		private readonly IActionsrv _actionsrv;
		public ActionController(IActionsrv actionsrv)
		{
			_actionsrv = actionsrv;
		}

		[HttpGet("{ticketid}")]
		public IActionResult Get(int ticketid)
		{
			return Ok(_actionsrv.GetTicketAction(ticketid, (int)HttpContext.Session.GetInt32("userId")));
		}
	}
}
