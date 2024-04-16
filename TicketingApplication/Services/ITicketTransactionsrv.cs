using  TicketingApplication.Models;

namespace  TicketingApplication.Services
{
	public interface ITicketTransactionsrv
	{
		IEnumerable<TicketTransactionViewModel> GetTransaction(int TicketId);
	}
}
