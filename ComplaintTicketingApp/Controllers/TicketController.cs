using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly ITicketsrv _ticketsrv;
		public TicketController(ITicketsrv ticketsrv)
		{
			_ticketsrv = ticketsrv;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_ticketsrv.GetAllTicket(Request.Cookies["userid"], Request.Cookies["usertype"]));
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				return Ok(_ticketsrv.GetTicket(id));
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody] TicketFormViewModel tickets)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_ticketsrv.AddTicket(tickets);
					return Ok();
				}
				else return BadRequest(ModelState);
			}
			catch
			{
				return BadRequest("Faild to save the Ticket");
			}
		}

		[HttpPut]
		public IActionResult Put([FromBody] TicketFormViewModel ticket)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_ticketsrv.UpdateTicketStatus(ticket, (int)HttpContext.Session.GetInt32("userId"));
					return Ok();
				}
				else return BadRequest(ModelState);
			}
			catch
			{
				return BadRequest("Faild to Update Ticket");
			}
		}
	}
}
