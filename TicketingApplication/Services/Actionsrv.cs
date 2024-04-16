using TicketingApplication.Entities;
using TicketingApplication.Models;
using TicketingApplication.Repository;
using Microsoft.IdentityModel.Tokens;
using static TicketingApplication.Entities.EntityConstant;

namespace TicketingApplication.Services
{
	public class Actionsrv : IActionsrv
	{
		//private readonly IRepository<Tickets> _ticketrepository;
		//private readonly IRepository<User> _userrepository;

		private readonly IUnitOfWork _unitOfWork;


		public Actionsrv(IUnitOfWork unitOfWork /*,IRepository<Tickets> ticktrepository, IRepository<User> userrepository*/)
		{
			//_ticketrepository = ticktrepository;
			//_userrepository = userrepository;
			_unitOfWork = unitOfWork;

		}
		public List<EntityConstantViewModel> GetTicketAction(int ticketId, int userid)
		{
			var usertype = _unitOfWork.UserRepository.GetById(userid).UserType;

			List<EntityConstantViewModel> action = new List<EntityConstantViewModel>();

			if (ticketId == 0 && usertype == UserType.Technician)
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

				if (usertype == UserType.Technician)
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

				if (usertype == UserType.Admin && (status == Status.Pending|| status == Status.TechnicianReturn))
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

		public bool CheckTickrtAction(Status oldstatus, Status newstatus, int userid)
		{
			var usertype = _unitOfWork.UserRepository.GetById(userid).UserType;

			if (oldstatus == Status.AdminReturnToTechnician)
			{
				if (usertype == UserType.Technician)
				{
					if (newstatus == Status.TechnicianReturn || newstatus ==Status.TechnicianApprovedSolved || newstatus == Status.TechnicianCanceled)
					{
						return true;
					}
				}

				if (usertype == UserType.Technician)
				{
					if (newstatus == Status.TechnicianReturn)
					{
						return true;
					}
				}
			}

			if (oldstatus == Status.Pending || oldstatus == Status.TechnicianReturn)
			{
				if (usertype == UserType.Admin)
				{
					if (newstatus == Status.AdminNotApproved || newstatus == Status.AdminReturnToTechnician || newstatus == Status.AdminApproved)
					{
						return true;
					}
				}
			}

			return false;
		}

		public int ReturnStatusFromAction(TicketAction ticketAction, int userid)
		{
			int status = 0;
			var usertype = _unitOfWork.UserRepository.GetById(userid).UserType;
			if (ticketAction == TicketAction.AddNew && usertype == UserType.Technician)
				status = (int)Status.Pending;

			if (ticketAction == TicketAction.NotApproved && usertype == UserType.Technician)
				status = (int)Status.TechnicianReturn;

			if (ticketAction == TicketAction.Approved && usertype == UserType.Technician)
				status = (int)Status.TechnicianApprovedSolved;

			if (ticketAction == TicketAction.SendToAdmin && usertype == UserType.Technician)
				status = (int)Status.TechnicianReturn;

			if (ticketAction == TicketAction.Cancel && usertype == UserType.Technician)
				status = (int)Status.TechnicianCanceled;

			if (ticketAction == TicketAction.Approved && usertype == UserType.Admin)
				status = (int)Status.AdminApproved;		

			if (ticketAction == TicketAction.NotApproved && usertype == UserType.Admin)
				status = (int)Status.AdminNotApproved;		

			if (ticketAction == TicketAction.ReturnToTechnician && usertype == UserType.Admin)
				status = (int)Status.AdminReturnToTechnician;

			return status;
		}
	}
}
