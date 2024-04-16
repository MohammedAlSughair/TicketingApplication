using static  TicketingApplication.Entities.EntityConstant;
using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class TicketFormViewModel
	{
		public int ID { get; set; }
		public int TicketNumber { get; set; }
		public int TagID { get; set; }
		public int TechnicianID { get; set; }
		public DateTime TicketDate { get; set; }
		public int CustomerID { get; set; }
		public int BranchId { get; set; }
		public TicketType TicketType { get; set; }
		public Status Status { get; set; }
		public DateTime? SolvedDate { get; set; }

		public int TicketID { get; set; }
		public int UserID { get; set; }
		public Status OldStatus { get; set; }
		public Status NewStatus { get; set; }
		public DateTime ActionDate { get; set; }
		public string? Note { get; set; }

		public TicketAction TicketAction { get; set; }
	}
}
