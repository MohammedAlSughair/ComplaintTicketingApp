using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		public readonly ICategorysrv _categorysrv;
		public CategoryController(ICategorysrv categorysrv)
		{
			_categorysrv = categorysrv;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_categorysrv.GetCategory());
		}
	}
}
