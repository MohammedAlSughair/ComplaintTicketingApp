using ComplaintTicketingApp.Entities;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Models
{
	public class TicketFormViewModel
	{
		public int TicketID { get; set; }
		public int? CategoryID { get; set; }
		public Category? Category { get; set; }
		public string? IssueDescription { get; set; }
		public int? UserID { get; set; }
		public UserViewModel? EntryUser { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? SolvedDate { get; set; }
		public Status Status { get; set; }
		public int? AdminUserID { get; set; }
		public UserViewModel? AdminUser { get; set; }
		public DateTime IssueDate { get; set; }

		public int FromUserID { get; set; }
		public UserViewModel? FromUser { get; set; }
		public int? ToUserID { get; set; }
		public UserViewModel? ToUser { get; set; }
		public Status FromStatus { get; set; }
		public Status ToStatus { get; set; }
		public DateTime ActionDate { get; set; }
		public string? Note { get; set; }

		public byte[]? UploadFile { get; set; }
		public string? FileExtension { get; set; }
		public string? FileName { get; set; }

		public TicketAction TicketAction { get; set; }
	}
}
