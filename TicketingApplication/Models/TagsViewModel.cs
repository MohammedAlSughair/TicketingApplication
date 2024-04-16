using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class TagsViewModel
	{
		public int ID { get; set; }
		public int TagNumber { get; set; }
		public int CustomerID { get; set; }
		public CustomersViewModel Customer { get; set; }
	}
}
