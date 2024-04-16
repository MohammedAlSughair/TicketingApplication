using static  TicketingApplication.Entities.EntityConstant;

namespace  TicketingApplication.Entities
{
	public class User
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set; }
	}
}
