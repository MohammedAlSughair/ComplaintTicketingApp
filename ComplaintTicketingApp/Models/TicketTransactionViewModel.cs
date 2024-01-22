using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Models
{
	public class TicketTransactionViewModel
	{
		public int ID { get; set; }
		public int TicketID { get; set; }
		public TicketViewModel Ticket { get; set; }
		public int FromUserID { get; set; }
		public UserViewModel FromUser { get; set; }
		public Status FromStatus { get; set; }
		public Status ToStatus { get; set; }
		public DateTime ActionDate { get; set; }
		public string? Note { get; set; }
	}
}
