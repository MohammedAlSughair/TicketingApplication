using static  TicketingApplication.Entities.EntityConstant;
using System.Net.Sockets;

namespace  TicketingApplication.Entities
{
	public class TicketTransaction
	{
		public int ID { get; set; }
		public int TicketID { get; set; }
		public Tickets Ticket { get; set; }
		public int UserID { get; set; }
		public User User { get; set; }
		public Status OldStatus { get; set; }
		public Status NewStatus { get; set; }
		public DateTime ActionDate { get; set; }
		public string? Note { get; set; }
	}
}
