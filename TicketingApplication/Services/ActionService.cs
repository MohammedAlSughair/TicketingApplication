using TicketingApplication.Entities;
using TicketingApplication.Models;
using TicketingApplication.Repository;
using Microsoft.IdentityModel.Tokens;
using static TicketingApplication.Entities.EntityConstant;
using System.Linq.Expressions;

namespace TicketingApplication.Services
{
	public class ActionService : IActionService
	{
		private readonly IUnitOfWork _unitOfWork;


		public ActionService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}
		public List<EntityConstantViewModel> GetTicketAction(int ticketId, int userId)
		{
			try
			{
				var userType = _unitOfWork.UserRepository.GetById(userId).UserType;

				List<EntityConstantViewModel> action = new List<EntityConstantViewModel>();

				if (ticketId == 0 && userType == UserType.Technician)
				{
					action.Add(new EntityConstantViewModel()
					{
						ID = (int)TicketAction.AddNew,
						Name = "Add New"
					});
				}
				else
				{
					var status = _unitOfWork.TicketsRepository.GetById(ticketId).Status;

					if (userType == UserType.Technician)
					{
						if (status == Status.AdminReturnToTechnician)
						{
							action.Add(new EntityConstantViewModel()
							{
								ID = (int)TicketAction.SendToAdmin,
								Name = "Send To Admin"
							});

							action.Add(new EntityConstantViewModel()
							{
								ID = (int)TicketAction.Cancel,
								Name = "Cancel Complaint"
							});

							action.Add(new EntityConstantViewModel()
							{
								ID = (int)TicketAction.Approved,
								Name = "User Approved Solved"
							});
						}
					}

					if (userType == UserType.Admin && (status == Status.Pending || status == Status.TechnicianReturn))
					{
						action.Add(new EntityConstantViewModel()
						{
							ID = (int)TicketAction.Approved,
							Name = "Approved"
						});

						action.Add(new EntityConstantViewModel()
						{
							ID = (int)TicketAction.NotApproved,
							Name = "Not Approved"
						});

						action.Add(new EntityConstantViewModel()
						{
							ID = (int)TicketAction.ReturnToTechnician,
							Name = "Return To User"
						});
					}
				}

				return action;
			}
			catch (Exception ex) { throw; }
		}

		public bool CheckTickrtAction(Status oldstatus, Status newstatus, int userid)
		{
			try
			{
				var userType = _unitOfWork.UserRepository.GetById(userid).UserType;

				if (oldstatus == Status.AdminReturnToTechnician)
				{
					if (userType == UserType.Technician)
					{
						if (newstatus == Status.TechnicianReturn || newstatus == Status.TechnicianApprovedSolved || newstatus == Status.TechnicianCanceled)
						{
							return true;
						}
					}

					if (userType == UserType.Technician)
					{
						if (newstatus == Status.TechnicianReturn)
						{
							return true;
						}
					}
				}

				if (oldstatus == Status.Pending || oldstatus == Status.TechnicianReturn)
				{
					if (userType == UserType.Admin)
					{
						if (newstatus == Status.AdminNotApproved || newstatus == Status.AdminReturnToTechnician || newstatus == Status.AdminApproved)
						{
							return true;
						}
					}
				}

				return false;
			}
			catch (Exception ex) { throw; }
		}

		public int ReturnStatusFromAction(TicketAction ticketAction, int userid)
		{
			try
			{
				int status = 0;
				var userType = _unitOfWork.UserRepository.GetById(userid).UserType;
				if (ticketAction == TicketAction.AddNew && userType == UserType.Technician)
					status = (int)Status.Pending;

				if (ticketAction == TicketAction.NotApproved && userType == UserType.Technician)
					status = (int)Status.TechnicianReturn;

				if (ticketAction == TicketAction.Approved && userType == UserType.Technician)
					status = (int)Status.TechnicianApprovedSolved;

				if (ticketAction == TicketAction.SendToAdmin && userType == UserType.Technician)
					status = (int)Status.TechnicianReturn;

				if (ticketAction == TicketAction.Cancel && userType == UserType.Technician)
					status = (int)Status.TechnicianCanceled;

				if (ticketAction == TicketAction.Approved && userType == UserType.Admin)
					status = (int)Status.AdminApproved;

				if (ticketAction == TicketAction.NotApproved && userType == UserType.Admin)
					status = (int)Status.AdminNotApproved;

				if (ticketAction == TicketAction.ReturnToTechnician && userType == UserType.Admin)
					status = (int)Status.AdminReturnToTechnician;

				return status;
			}
			catch (Exception ex) { throw; }
		}


		public Expression<Func<Tickets, object>>[] GetIncludes()
		{
			try
			{
				Expression<Func<Tickets, object>>[] includes = new Expression<Func<Tickets, object>>[] {
					a => a.Tag,
					b => b.Technician,
					c => c.Customer,
					d=>d.Branch
			};

				return includes;
			}
			catch (Exception ex) { throw; }
		}
	}
}
