namespace ComplaintTicketingApp.Entities
{
	public class EntityConstant
	{
		public enum UserType
		{
			Admin = 1,
			User = 2
		}

		public enum Status
		{
			Pending = 0,
			UserReturn = 1,
			AdminApproved = 2,
			AdminReturnToUser = 3,
			AdminNotApproved = 4,
			UserApprovedSolved = 5,
			UserCanceled = 6
		}

		public enum TicketAction
		{
			AddNew = 0,
			Approved = 1,
			NotApproved = 2,
			ReturnToUser = 3,
			SendToAdmin = 4,
			Cancel = 5
		}
	}
}
