using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Entities
{
	public class TicketTransaction
	{
		public int ID { get; set; }
		public int TicketID { get; set; }
		public Ticket Ticket { get; set; }
		public int FromUserID { get; set; }
		public User FromUser { get; set; }
		public Status FromStatus { get; set; }
		public Status ToStatus { get; set; }
		public DateTime ActionDate { get; set; }
		public string? Note { get; set; }
	}
}
