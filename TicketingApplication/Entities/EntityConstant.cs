namespace TicketingApplication.Entities
{
	public class EntityConstant
	{
		public enum UserType
		{
			Admin = 1,
			Technician = 2
		}
		public enum TicketType
		{
			Manual = 1,
			Visit = 2
		}

		public enum Status
		{
			Pending = 0,
			TechnicianReturn = 1,
			AdminApproved = 2,
			AdminReturnToTechnician = 3,
			AdminNotApproved = 4,
			TechnicianApprovedSolved = 5,
			TechnicianCanceled = 6
		}

		public enum TicketAction
		{
			AddNew = 0,
			Approved = 1,
			NotApproved = 2,
			ReturnToTechnician = 3,
			SendToAdmin = 4,
			Cancel = 5
		}
	}
}
