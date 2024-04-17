using System.Linq.Expressions;
using TicketingApplication.Entities;
using  TicketingApplication.Models;
using static  TicketingApplication.Entities.EntityConstant;

namespace  TicketingApplication.Services
{
	public interface IActionService
	{
		List<EntityConstantViewModel> GetTicketAction(int ticketId, int userid);

		bool CheckTickrtAction(Status oldstatus, Status newstatus, int userid);

		int ReturnStatusFromAction(TicketAction ticketAction, int userid);
		 Expression<Func<Tickets, object>>[] GetIncludes();
	}
}
