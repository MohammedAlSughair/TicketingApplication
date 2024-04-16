using AutoMapper;
using TicketingApplication.Entities;
using TicketingApplication.Models;
using static TicketingApplication.Entities.EntityConstant;

namespace TicketingApplication.Services
{
	public class Usersrv : IUsersrv
	{
		private readonly IUnitOfWork _unitOfWork;
		public readonly IMapper _mapper;
		public Usersrv(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public IEnumerable<UserViewModel> GetAllUser()
		{
			return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(
				_unitOfWork.UserRepository.GetAllByFilter(x => x.UserType == UserType.Technician, null, null));
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
					_unitOfWork.UserRepository.GetAllByFilter(
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
					_unitOfWork.UserRepository.GetAllByFilter(
					x => x.Name == userViewModel.Name && x.Password == userViewModel.Password,
					null, null));

			return user.FirstOrDefault();
		}
	}
}
