using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Repository;
using static ComplaintTicketingApp.Entities.EntityConstant;
using System.Linq.Expressions;
using AutoMapper;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Azure.Core;
using Microsoft.AspNetCore.Http;
namespace ComplaintTicketingApp.Services
{
	public class Ticketsrv : ITicketsrv
	{
		private readonly IRepository<Ticket> _repository;
		private readonly IRepository<TicketTransaction> _TicketTransactionrepository;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IActionsrv _actionsrv;

		public Ticketsrv(IRepository<Ticket> repository, IMapper mapper,
						IHttpContextAccessor contextAccessor, IActionsrv actionsrv, IRepository<TicketTransaction> TicketTransactionrepository)
		{
			_repository = repository;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
			_actionsrv = actionsrv;
			_TicketTransactionrepository = TicketTransactionrepository;
		}

		public IEnumerable<TicketViewModel> GetAllTicket(string userid, string usertype)
		{
			Expression<Func<Ticket, object>>[] includes = new Expression<Func<Ticket, object>>[] {
					x => x.Category,
					uu =>uu.EntryUser,
					au =>au.AdminUser
			};

			if (usertype == "Admin")
				return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketViewModel>>(
					_repository.GetAll(includes)
					);
			else return _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketViewModel>>(
				_repository.GetAllByFilter(x => x.ID == x.ID, includes, o => o.ID)
				);
		}

		public TicketViewModel GetTicket(int id)
		{
			return _mapper.Map<Ticket, TicketViewModel>(_repository.GetById(id));
		}


		public bool AddTicket(TicketFormViewModel ticketForm)
		{
			try
			{
				int userid = (int)_contextAccessor.HttpContext.Session.GetInt32("userId");
				Ticket ticket = new Ticket
				{
					CategoryID = ticketForm.CategoryID,
					UserID = userid,
					IssueDescription = ticketForm.IssueDescription,
					Document = new Document
					{
						UploadFile = ticketForm.UploadFile,
						FileExtension = ticketForm.FileExtension,
						FileName = ticketForm.FileName
					},
					DueDate = ticketForm.DueDate,
					Status = Status.Pending,
					IssueDate = DateTime.Now,
					TicketTransaction = new TicketTransaction
					{
						FromUserID = userid,
						FromStatus = Status.Pending,
						ToStatus = Status.Pending,
						ActionDate = DateTime.Now,
					}
				};

				_repository.AddEntity(ticket);
				if (_repository.SaveChange())
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}		

		public Ticket GetTicketForUpdate(int id)
		{
			return _repository.GetById(id);
		}
		public bool UpdateTicketStatus(TicketFormViewModel ticketForm, int userid)
		{
			try
			{
				Ticket tvm = GetTicketForUpdate(ticketForm.TicketID);
				Status newstatus = (Status)_actionsrv.ReturnStatusFromAction(ticketForm.TicketAction, userid);
				if (_actionsrv.CheckTickrtAction(tvm.Status, newstatus, userid))
				{
					tvm.SolvedDate = ticketForm.SolvedDate;
					tvm.Status = newstatus;
					tvm.AdminUserID = userid;
					if (newstatus == Status.AdminApproved)
						tvm.SolvedDate = DateTime.Now;

					TicketTransaction tt = new TicketTransaction
					{
						TicketID = tvm.ID,
						FromUserID = userid,
						FromStatus = tvm.Status,
						ToStatus = newstatus,
						ActionDate = DateTime.Now,
						Note = ticketForm.Note,
					};
					_TicketTransactionrepository.AddEntity(tt);

					if (_TicketTransactionrepository.SaveChange())
					{
						_repository.UpdateEntity(tvm);
						if (_repository.SaveChange())
						{
							return true;
						}
						return false;
					}
					return false;
				}
				else
				{
					tvm.SolvedDate = ticketForm.SolvedDate;
					tvm.AdminUserID = userid;
					if (newstatus == Status.AdminApproved)
						tvm.SolvedDate = DateTime.Now;

					TicketTransaction tt = new TicketTransaction
					{
						TicketID = tvm.ID,
						FromUserID = userid,
						FromStatus = tvm.Status,
						ToStatus = tvm.Status,
						ActionDate = DateTime.Now,
						Note = ticketForm.Note,
					};
					_TicketTransactionrepository.AddEntity(tt);

					if (_TicketTransactionrepository.SaveChange())
					{
						_repository.UpdateEntity(tvm);
						if (_repository.SaveChange())
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;

			}
			catch { return false; }			
		}
	}
}
