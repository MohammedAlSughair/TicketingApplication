using  TicketingApplication.Models;

namespace  TicketingApplication.Services
{
	public interface ITicketTransactionService
	{
		IEnumerable<TicketTransactionViewModel> GetTransaction(int TicketId);
	}
}
