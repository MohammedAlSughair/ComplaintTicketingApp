using AutoMapper;
using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Repository;

namespace ComplaintTicketingApp.Services
{
	public class Categorysrv : ICategorysrv
	{
		public readonly IRepository<Category> _repository;
		public readonly IMapper _mapper;
		public Categorysrv(IRepository<Category> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public IEnumerable<CategoryViewModel> GetCategory()
		{
			return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_repository.GetAll(null));
		}
	}

}
