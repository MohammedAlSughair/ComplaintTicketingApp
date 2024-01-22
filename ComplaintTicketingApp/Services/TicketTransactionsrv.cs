using AutoMapper;
using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Repository;
using System.Linq.Expressions;

namespace ComplaintTicketingApp.Services
{
	public class TicketTransactionsrv:ITicketTransactionsrv
	{
		private readonly IRepository<TicketTransaction> _repository;
		private readonly IMapper _mapper;
		public TicketTransactionsrv(IRepository<TicketTransaction> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<TicketTransactionViewModel> GetTransaction(int TicketId)
		{
			Expression<Func<TicketTransaction, object>>[] includes = new Expression<Func<TicketTransaction, object>>[] {
					x => x.FromUser,					
			};

			return _mapper.Map<IEnumerable<TicketTransaction>, IEnumerable<TicketTransactionViewModel>>(
				_repository.GetAllByFilter(x => x.TicketID == TicketId, includes, o => o.ID)
				);
		}

	}
}
