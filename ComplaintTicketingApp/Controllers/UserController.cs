using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public readonly IUsersrv _usersrv;
		public UserController(IUsersrv usersrv)
		{
			_usersrv = usersrv;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_usersrv.GetAllUser());
		}
	}
}
