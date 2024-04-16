using static  TicketingApplication.Entities.EntityConstant;
using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class TicketsViewModel
	{
		public int ID { get; set; }
		public int TicketNumber { get; set; }
		public int TagID { get; set; }
		public TagsViewModel Tag { get; set; }
		public int TechnicianID { get; set; }
		public TechniciansViewModel Technician { get; set; }
		public DateTime TicketDate { get; set; }
		public int CustomerID { get; set; }
		public CustomersViewModel Customer { get; set; }
		public int BranchId { get; set; }
		public CustomerBranchViewModel Branch { get; set; }
		public TicketType TicketType { get; set; }
		public Status Status { get; set; }
		public DateTime? SolvedDate { get; set; }
		public int CreateUserId { get; set; }

		public TicketTransactionViewModel TicketTransaction { get; set; }
	}
}
