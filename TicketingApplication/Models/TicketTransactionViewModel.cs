using static  TicketingApplication.Entities.EntityConstant;
using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class TicketTransactionViewModel
	{
		public int ID { get; set; }
		public int TicketID { get; set; }
		public TicketsViewModel Ticket { get; set; }
		public int UserID { get; set; }
		public UserViewModel User { get; set; }
		public Status OldStatus { get; set; }
		public Status NewStatus { get; set; }
		public DateTime ActionDate { get; set; }
		public string? Note { get; set; }
	}
}
