using System.ComponentModel.DataAnnotations;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Entities
{
	public class Ticket
	{
		public int ID { get; set; }
		public int? CategoryID { get; set; }
		public Category? Category { get; set; }
		public string IssueDescription { get; set; }
		public int? DocumentID { get; set; }
		public Document Document { get; set; }
		public int? UserID { get; set; }
		public User? EntryUser { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? SolvedDate { get; set; }
		public Status Status { get; set; }
		public int? AdminUserID { get; set; }
		public User AdminUser { get; set; }
		public DateTime IssueDate { get; set; }
		public TicketTransaction TicketTransaction { get; set; }
	}
}
