using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class AreasViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int CityId { get; set; }
		public CitiesViewModel City { get; set; }
	}
}
