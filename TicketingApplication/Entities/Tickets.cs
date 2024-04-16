using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Metadata;
using static  TicketingApplication.Entities.EntityConstant;


namespace  TicketingApplication.Entities
{
	public class Tickets
	{
		public int ID { get; set; }
		public int TicketNumber { get; set; }
		public int TagID { get; set; }
		public Tags Tag { get; set; }
		public int TechnicianID { get; set; }
		public Technicians Technician { get; set; }
		public DateTime TicketDate { get; set; }
		public int CustomerID { get; set; }
		public Customers Customer { get; set; }
		public int BranchId { get; set; }
		public CustomerBranch Branch { get; set; }
		public TicketType TicketType { get; set; }
		public Status Status { get; set; }
		public DateTime? SolvedDate { get; set; }
		public int CreateUserId { get; set; }
		public TicketTransaction TicketTransaction { get; set; }

	}
}
