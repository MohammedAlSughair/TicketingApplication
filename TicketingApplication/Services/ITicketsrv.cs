using  TicketingApplication.Models;

namespace  TicketingApplication.Services
{
	public interface ITicketsrv
	{
		IEnumerable<TicketsViewModel> GetAllTicket(string userid, string usertype);
		TicketsViewModel GetTicket(int id);
		bool AddTicket(TicketFormViewModel ticket);
		bool UpdateTicketStatus(TicketFormViewModel ticketForm, int userid);
	}
}
