using AutoMapper;
using  TicketingApplication.Entities;
using  TicketingApplication.Models;
using System.Linq.Expressions;

namespace TicketingApplication.Services
{
	public class TicketTransactionService : ITicketTransactionService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public TicketTransactionService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public IEnumerable<TicketTransactionViewModel> GetTransaction(int TicketId)
		{
			try
			{
				Expression<Func<TicketTransaction, object>>[] includes = new Expression<Func<TicketTransaction, object>>[] {
					x => x.User,
			};

				return _mapper.Map<IEnumerable<TicketTransaction>, IEnumerable<TicketTransactionViewModel>>(
					_unitOfWork.TicketTransactionRepository.GetAllByFilter(x => x.TicketID == TicketId, includes, o => o.ID)
					);
			}
			catch (Exception ex) { throw; }
		}

	}
}
