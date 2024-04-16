 using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class CitiesViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int CountryId { get; set; }
		public CountriesViewModel Country { get; set; }
	}
}
