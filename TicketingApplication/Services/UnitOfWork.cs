using TicketingApplication.Entities;
using TicketingApplication.Repository;

namespace TicketingApplication.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TSDBContext _context;
        Repository<Tickets> _ticketsRepository;

		public UnitOfWork(TSDBContext context )
        {
            _context = context;
            TicketTransactionRepository = new Repository<TicketTransaction>(_context);
			UserRepository = new Repository<User>(_context);

		}
		public IRepository<Tickets> TicketsRepository 
        {
            get
            {
                if (_ticketsRepository == null)
                {
					_ticketsRepository = new Repository<Tickets>(_context);
                }
                return _ticketsRepository;
            }
        }

		public IRepository<TicketTransaction> TicketTransactionRepository { get;}
		public IRepository<User> UserRepository { get; }



		public void Save()
        {
            _context.SaveChanges();               
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
					_context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

