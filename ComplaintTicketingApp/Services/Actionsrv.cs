using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Repository;
using Microsoft.IdentityModel.Tokens;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Services
{
	public class Actionsrv : IActionsrv
	{
		private readonly IRepository<Ticket> _ticketrepository;
		private readonly IRepository<User> _userrepository;

		public Actionsrv(IRepository<Ticket> ticktrepository, IRepository<User> userrepository)
		{
			_ticketrepository = ticktrepository;
			_userrepository = userrepository;
		}
		public List<EntityConstantViewModel> GetTicketAction(int ticketId, int userid)
		{
			var usertype = _userrepository.GetById(userid).UserType;

			List<EntityConstantViewModel> action = new List<EntityConstantViewModel>();

			if (ticketId == 0 && usertype == UserType.User)
			{
				action.Add(new EntityConstantViewModel()
				{
					ID = (int)TicketAction.AddNew,
					Name = "Add New"
				});
			}
			else
			{
				var status = _ticketrepository.GetById(ticketId).Status;

				if (usertype == UserType.User)
				{
					if (status == Status.AdminReturnToUser)
					{
						action.Add(new EntityConstantViewModel()
						{
							ID = (int)TicketAction.SendToAdmin,
							Name = "Send To Admin"
						});

						action.Add(new EntityConstantViewModel()
						{
							ID = (int)TicketAction.Cancel,
							Name = "Cancel Complaint"
						});

						action.Add(new EntityConstantViewModel()
						{
							ID = (int)TicketAction.Approved,
							Name = "User Approved Solved"
						});						
					}					
				}

				if (usertype == UserType.Admin && (status == Status.Pending|| status == Status.UserReturn))
				{
					action.Add(new EntityConstantViewModel()
					{
						ID = (int)TicketAction.Approved,
						Name = "Approved"
					});

					action.Add(new EntityConstantViewModel()
					{
						ID = (int)TicketAction.NotApproved,
						Name = "Not Approved"
					});

					action.Add(new EntityConstantViewModel()
					{
						ID = (int)TicketAction.ReturnToUser,
						Name = "Return To User"
					});
				}
			}

			return action;
		}

		public bool CheckTickrtAction(Status oldstatus, Status newstatus, int userid)
		{
			var usertype = _userrepository.GetById(userid).UserType;

			if (oldstatus == Status.AdminReturnToUser)
			{
				if (usertype == UserType.User)
				{
					if (newstatus == Status.UserReturn ||newstatus ==Status.UserApprovedSolved || newstatus == Status.UserCanceled)
					{
						return true;
					}
				}

				if (usertype == UserType.User)
				{
					if (newstatus == Status.UserReturn)
					{
						return true;
					}
				}
			}

			if (oldstatus == Status.Pending || oldstatus == Status.UserReturn)
			{
				if (usertype == UserType.Admin)
				{
					if (newstatus == Status.AdminNotApproved || newstatus == Status.AdminReturnToUser || newstatus == Status.AdminApproved)
					{
						return true;
					}
				}
			}

			return false;
		}

		public int ReturnStatusFromAction(TicketAction ticketAction, int userid)
		{
			int status = 0;
			var usertype = _userrepository.GetById(userid).UserType;
			if (ticketAction == TicketAction.AddNew && usertype == UserType.User)
				status = (int)Status.Pending;

			if (ticketAction == TicketAction.NotApproved && usertype == UserType.User)
				status = (int)Status.UserReturn;

			if (ticketAction == TicketAction.Approved && usertype == UserType.User)
				status = (int)Status.UserApprovedSolved;

			if (ticketAction == TicketAction.SendToAdmin && usertype == UserType.User)
				status = (int)Status.UserReturn;

			if (ticketAction == TicketAction.Cancel && usertype == UserType.User)
				status = (int)Status.UserCanceled;

			if (ticketAction == TicketAction.Approved && usertype == UserType.Admin)
				status = (int)Status.AdminApproved;		

			if (ticketAction == TicketAction.NotApproved && usertype == UserType.Admin)
				status = (int)Status.AdminNotApproved;		

			if (ticketAction == TicketAction.ReturnToUser && usertype == UserType.Admin)
				status = (int)Status.AdminReturnToUser;

			return status;
		}
	}
}
