using System.Diagnostics.Metrics;

namespace TicketingApplication.Entities
{
	public class CustomerLocation
	{
		public int ID { get; set; }
		public int CustomerId { get; set; }
		public Customers Customer { get; set; }
		public int BranchId { get; set; }
		public CustomerBranch Branch { get; set; }
		public int CountryId { get; set; }
		public Countries Country { get; set; }
		public int CityId { get; set; }
		public Cities City { get; set; }
		public int AreaId { get; set; }
		public Areas Area { get; set; }
	}
}
