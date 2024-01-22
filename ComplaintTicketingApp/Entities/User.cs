using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Entities
{
	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set; }
	}
}
