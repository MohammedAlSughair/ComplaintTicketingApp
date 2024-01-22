using System.ComponentModel.DataAnnotations;

namespace ComplaintTicketingApp.Entities
{
	public class Document
	{
		public int ID { get; set; }
		public byte[] UploadFile { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
	}
}
