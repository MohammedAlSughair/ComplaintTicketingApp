using AutoMapper;
using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComplaintTicketingApp.Services
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<Ticket, TicketViewModel>().ReverseMap();
			CreateMap<TicketTransaction, TicketTransactionViewModel>().ReverseMap();
			CreateMap<User, UserViewModel>().ReverseMap();
			CreateMap<Category, CategoryViewModel>().ReverseMap();
			CreateMap<Document, DocumentViewModel>().ReverseMap();
		}
	}
}
