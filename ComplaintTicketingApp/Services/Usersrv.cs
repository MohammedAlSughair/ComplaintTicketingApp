using AutoMapper;
using ComplaintTicketingApp.Entities;
using ComplaintTicketingApp.Models;
using ComplaintTicketingApp.Repository;
using static ComplaintTicketingApp.Entities.EntityConstant;

namespace ComplaintTicketingApp.Services
{
	public class Usersrv : IUsersrv
	{
		public readonly IRepository<User> _repository;
		public readonly IMapper _mapper;
		public Usersrv(IRepository<User> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public IEnumerable<UserViewModel> GetAllUser()
		{
			return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(
				_repository.GetAllByFilter(x => x.UserType == UserType.User, null, null));
		}		
		public UserViewModel GetUser(UserViewModel userViewModel)
		{
			if (CheckUser(userViewModel))
			{
				return GetUserInformation(userViewModel);
			}
			else
			{
				return null;
			}
		}
		private bool CheckUser(UserViewModel userViewModel)
		{
			var user = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(
					_repository.GetAllByFilter(
					x => x.Name == userViewModel.Name && x.Password == userViewModel.Password,
					null, null));
			if (user.Count() == 1)
			{
				return true;
			}
			return false;
		}

		private UserViewModel GetUserInformation(UserViewModel userViewModel)
		{
			var user = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(
					_repository.GetAllByFilter(
					x => x.Name == userViewModel.Name && x.Password == userViewModel.Password,
					null, null));

			return user.FirstOrDefault();
		}
	}
}
