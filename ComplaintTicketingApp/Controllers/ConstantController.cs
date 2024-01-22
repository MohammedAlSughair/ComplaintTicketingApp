using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConstantController : ControllerBase
	{
		[HttpGet]
		public ActionResult Get()
		{
			Dictionary<int, string> Enumval = new Dictionary<int, string>();

			foreach (var value in Enum.GetValues(typeof(Status)))
			{
				Enumval.Add((int)value, ((Status)value).ToString());
			}

			return Ok(Enumval);
		}
	}
}
