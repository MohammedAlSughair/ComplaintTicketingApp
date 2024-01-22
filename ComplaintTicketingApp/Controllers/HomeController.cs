using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComplaintTicketingApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUsersrv _usersrv;

		public HomeController(IUsersrv usersrv, ILogger<HomeController> logger)
		{
			_usersrv = usersrv;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetInt32("userId") == null)
			{
				Response.Cookies.Append("userid", "");
				Response.Cookies.Append("usertype", "");
				return View();
			}
			else
				return RedirectToAction("Main", new { type = Request.Cookies["usertype"] });
		}

		[HttpPost]
		public IActionResult Login([Bind(include: "Name,Password")] UserViewModel userViewModel)
		{
			var user = _usersrv.GetUser(userViewModel);
			if (user != null)
			{
				ViewData["usertype"] = user.UserType.ToString();
				HttpContext.Session.SetInt32("userId", user.ID);
				HttpContext.Session.SetInt32("userType", user.ID);
				Response.Cookies.Append("userid", user.ID.ToString());
				Response.Cookies.Append("usertype", user.UserType.ToString());
				return Json(new { redirectToUrl = Url.Action("Main", "Home", new { type = user.UserType.ToString() }) });
				;
			}

			ViewData["error"] = "The User Not Found.";
			return BadRequest("The User Not Found.");
		}
		public IActionResult Main(string type)
		{
			ViewData["usertype"] = type;
			return View();
		}

		public IActionResult ComplaintTicket(string type)
		{
			ViewData["usertype"] = type;
			return View();
		}

		public IActionResult Users()
		{
			return View();
		}

		public IActionResult Categories()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}		

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
