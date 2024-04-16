using  TicketingApplication.Entities;
using static  TicketingApplication.Entities.EntityConstant;

namespace  TicketingApplication.Models
{
	public class UserViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set; }
	}
}