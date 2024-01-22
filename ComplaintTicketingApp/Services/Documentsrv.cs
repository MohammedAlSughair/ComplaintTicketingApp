using AutoMapper;
using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Repository;

namespace ComplaintTicketingApp.Services
{
	public class Documentsrv : IDocumentsrv
	{
		public readonly IRepository<Document> _reposetory;
		public readonly IMapper _mapper;
		public Documentsrv(IRepository<Document> repository, IMapper mapper)
		{
			_reposetory = repository;
			_mapper = mapper;
		}

		public DocumentViewModel GetFile(int id)
		{
			return _mapper.Map<Document, DocumentViewModel>(_reposetory.GetById(id));
		}		
	}
}
