using AutoMapper;
using TicketingApplication.Entities;
using TicketingApplication.Models;
using static TicketingApplication.Entities.EntityConstant;

namespace TicketingApplication.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		public readonly IMapper _mapper;
		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public IEnumerable<UserViewModel> GetAllUser()
		{
			try
			{
				return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(
					_unitOfWork.UserRepository.GetAllByFilter(x => x.UserType == UserType.Technician, null, null));
			}
			catch (Exception ex) { throw; }
		}
		public UserViewModel GetUser(UserViewModel userViewModel)
		{
			try
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
			catch (Exception ex) { throw; }
		}
		private bool CheckUser(UserViewModel userViewModel)
		{
			try
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
			catch (Exception ex) { throw; }
		}

		private UserViewModel GetUserInformation(UserViewModel userViewModel)
		{
			try
			{
				var user = _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(
						_unitOfWork.UserRepository.GetAllByFilter(
						x => x.Name == userViewModel.Name && x.Password == userViewModel.Password,
						null, null));

				return user.FirstOrDefault();
			}
			catch (Exception ex) { throw; }
		}
	}
}
