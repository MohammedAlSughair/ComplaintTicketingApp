namespace ComplaintTicketingApp.Models
{
	public class DocumentViewModel
	{
		public int ID { get; set; }
		public byte[] UploadFile { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
	}
}
