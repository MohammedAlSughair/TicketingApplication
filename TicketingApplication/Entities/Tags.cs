namespace TicketingApplication.Entities
{
	public class Tags
	{
		public int ID { get; set; }
		public int TagNumber { get; set; }
		public int CustomerID { get; set; }
		public Customers Customer { get; set; }
	}
}
