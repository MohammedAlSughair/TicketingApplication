using TicketingApplication.Entities;
using TicketingApplication.Models;
using static TicketingApplication.Entities.EntityConstant;
using System.Linq.Expressions;
using AutoMapper;
namespace TicketingApplication.Services
{
	public class Ticketsrv : ITicketsrv
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IActionsrv _actionsrv;
		 
		public Ticketsrv(IUnitOfWork unitOfWork,  IMapper mapper,
								IHttpContextAccessor contextAccessor, IActionsrv actionsrv)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
			_actionsrv = actionsrv;
		}


		public IEnumerable<TicketsViewModel> GetAllTicket(string userid, string usertype)
		{
			Expression<Func<Tickets, object>>[] includes = new Expression<Func<Tickets, object>>[] {
					a => a.Tag,
					b => b.Technician,
					c => c.Customer,
					d=>d.Branch
			};

			if (usertype == "Admin")
				return _mapper.Map<IEnumerable<Tickets>, IEnumerable<TicketsViewModel>>(
					_unitOfWork.TicketsRepository.GetAll(includes)
					);
			else return _mapper.Map<IEnumerable<Tickets>, IEnumerable<TicketsViewModel>>(
				_unitOfWork.TicketsRepository.GetAllByFilter(x => x.TechnicianID == x.TechnicianID, includes, o => o.ID)
				);
		}

		public TicketsViewModel GetTicket(int id)
		{
			return _mapper.Map<Tickets, TicketsViewModel>(_unitOfWork.TicketsRepository.GetById(id));
		}


		public bool AddTicket(TicketFormViewModel ticketForm)
		{
			try
			{
				//int userid = (int)_contextAccessor.HttpContext.Session.GetInt32("userId");
				Tickets ticket = new Tickets
				{
					TicketNumber = ticketForm.TicketNumber,
					TagID = ticketForm.TagID,
					TechnicianID = ticketForm.TechnicianID,
					TicketDate = ticketForm.TicketDate,

					CustomerID = ticketForm.CustomerID,
					BranchId = ticketForm.BranchId,
					TicketType = ticketForm.TicketType,
					Status = Status.Pending,
					TicketTransaction = new TicketTransaction
					{
						UserID = 1,
						OldStatus = Status.Pending,
						NewStatus = Status.Pending,
						ActionDate = DateTime.Now,
					}
				};

				_unitOfWork.TicketsRepository.AddEntity(ticket);
				_unitOfWork.Save();

				return true;
			}
			catch
			{
				return false;
			}
		}

		public Tickets GetTicketForUpdate(int id)
		{
			return _unitOfWork.TicketsRepository.GetById(id);
		}
		public bool UpdateTicketStatus(TicketFormViewModel ticketForm, int userid)
		{
			try
			{
				Tickets tvm = GetTicketForUpdate(ticketForm.TicketID);
				Status newstatus = (Status)_actionsrv.ReturnStatusFromAction(ticketForm.TicketAction, userid);
				if (_actionsrv.CheckTickrtAction(tvm.Status, newstatus, userid))
				{
					tvm.SolvedDate = ticketForm.SolvedDate;
					tvm.Status = newstatus;
					if (newstatus == Status.AdminApproved)
						tvm.SolvedDate = DateTime.Now;

					TicketTransaction tt = new TicketTransaction
					{
						TicketID = tvm.ID,
						UserID = userid,
						OldStatus = tvm.Status,
						NewStatus = newstatus,
						ActionDate = DateTime.Now,
						Note = ticketForm.Note,
					};

					_unitOfWork.TicketTransactionRepository.AddEntity(tt);
					_unitOfWork.TicketsRepository.UpdateEntity(tvm);
					_unitOfWork.Save();

					return true;
				}
				else
				{
					tvm.SolvedDate = ticketForm.SolvedDate;
					if (newstatus == Status.AdminApproved)
						tvm.SolvedDate = DateTime.Now;

					TicketTransaction tt = new TicketTransaction
					{
						TicketID = tvm.ID,
						UserID = userid,
						OldStatus = tvm.Status,
						NewStatus = tvm.Status,
						ActionDate = DateTime.Now,
						Note = ticketForm.Note,
					};

					_unitOfWork.TicketTransactionRepository.AddEntity(tt);
					_unitOfWork.TicketsRepository.UpdateEntity(tvm);
					_unitOfWork.Save();

					return true;
				}
			}
			catch { return false; }
		}
	}
}
