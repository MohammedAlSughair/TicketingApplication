namespace TicketingApplication.Entities
{
	public class Areas
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int CityId { get; set; }
		public Cities City { get; set; }
	}
}
