using ComplaintTicketingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintTicketingApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentController : ControllerBase
	{
		private readonly IDocumentsrv _documentsrv;
		public DocumentController(IDocumentsrv documentsrv)
		{
			_documentsrv = documentsrv;
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var file = _documentsrv.GetFile(id);
			var stream = new MemoryStream(file.UploadFile);
			return new FileStreamResult(stream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/plain"))
			{
				FileDownloadName = file.FileName + file.FileExtension
			};
		}
	}
}
