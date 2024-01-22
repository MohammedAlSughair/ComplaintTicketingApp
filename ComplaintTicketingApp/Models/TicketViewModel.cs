using ComplaintTicketingApp.Entities;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Models
{
	public class TicketViewModel
	{
		public int ID { get; set; }
		public int? CategoryID { get; set; }
		public CategoryViewModel? Category { get; set; }
		public string IssueDescription { get; set; }
		public int? UserID { get; set; }
		public UserViewModel? EntryUser { get; set; }
		public int? DocumentID { get; set; }
		public DocumentViewModel Document { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? SolvedDate { get; set; }
		public Status Status { get; set; }
		public int? AdminUserID { get; set; }
		public UserViewModel? AdminUser { get; set; }
		public DateTime IssueDate { get; set; }
		public TicketTransactionViewModel TicketTransaction { get; set; }
	}
}
