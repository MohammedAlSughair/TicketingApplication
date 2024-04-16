using  TicketingApplication.Repository;
using  TicketingApplication.Entities;
using  TicketingApplication.Repository;

namespace  TicketingApplication.Services
{
	public interface IUnitOfWork
	{
		IRepository<Tickets> TicketsRepository { get; }
		public IRepository<TicketTransaction> TicketTransactionRepository { get; }
		public IRepository<User> UserRepository { get; }

		public void Save();
	}
}
