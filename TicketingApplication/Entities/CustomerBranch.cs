namespace TicketingApplication.Entities
{
	public class CustomerBranch
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public int CustomerId { get; set; }
		public Customers Customer { get; set; }
	}
}
