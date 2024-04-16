namespace TicketingApplication.Entities
{
	public class Cities
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int CountryId { get; set; }
		public Countries Country { get; set; }
	}
}
