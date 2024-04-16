using  TicketingApplication.Entities;

namespace  TicketingApplication.Models
{
	public class CustomerLocationViewModel
	{
		public int ID { get; set; }
		public int CustomerId { get; set; }
		public CustomersViewModel Customer { get; set; }
		public int BranchId { get; set; }
		public CustomerBranchViewModel Branch { get; set; }
		public int CountryId { get; set; }
		public CountriesViewModel Country { get; set; }
		public int CityId { get; set; }
		public CitiesViewModel City { get; set; }
		public int AreaId { get; set; }
		public AreasViewModel Area { get; set; }
	}
}
