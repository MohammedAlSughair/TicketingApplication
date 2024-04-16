using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class CustomerBranchViewModel
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public int CustomerId { get; set; }
		public CustomersViewModel Customer { get; set; }
	}
}
