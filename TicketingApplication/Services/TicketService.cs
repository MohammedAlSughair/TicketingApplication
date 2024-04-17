using TicketingApplication.Entities;
using TicketingApplication.Models;
using static TicketingApplication.Entities.EntityConstant;
using System.Linq.Expressions;
using AutoMapper;
using NLog;
namespace TicketingApplication.Services
{
	public class TicketService : ITicketService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IActionService _actionService;
		 
		public TicketService(IUnitOfWork unitOfWork,  IMapper mapper,
								IHttpContextAccessor contextAccessor, IActionService actionService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
			_actionService = actionService;
		}


		public IEnumerable<TicketsViewModel> GetAllTicket(string userid, string usertype)
		{
			try
			{
				Expression<Func<Tickets, object>>[] includes = _actionService.GetIncludes();

				if (usertype == UserType.Admin.ToString())

					return _mapper.Map<IEnumerable<Tickets>, IEnumerable<TicketsViewModel>>(
						_unitOfWork.TicketsRepository.GetAll(includes)
						);

				else return _mapper.Map<IEnumerable<Tickets>, IEnumerable<TicketsViewModel>>(
					_unitOfWork.TicketsRepository.GetAllByFilter(x => x.TechnicianID == Convert.ToInt32(userid), includes, o => o.ID)
					);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public TicketsViewModel GetTicket(int id)
		{
			try
			{				
				return _mapper.Map<Tickets, TicketsViewModel>(_unitOfWork.TicketsRepository.GetById(id));
			}
			catch (Exception ex)
			{
				throw;
			}
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
			catch (Exception ex)
			{
				throw;
			}
		}

		public Tickets GetTicketForUpdate(int id)
		{
			try
			{
				return _unitOfWork.TicketsRepository.GetById(id);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public bool UpdateTicketStatus(TicketFormViewModel ticketForm, int userid)
		{
			try
			{
				Tickets ticket = GetTicketForUpdate(ticketForm.TicketID);
				Status newStatus = (Status)_actionService.ReturnStatusFromAction(ticketForm.TicketAction, userid);
				if (_actionService.CheckTickrtAction(ticket.Status, newStatus, userid))
				{
					ticket.SolvedDate = ticketForm.SolvedDate;
					ticket.Status = newStatus;
					if (newStatus == Status.AdminApproved)
						ticket.SolvedDate = DateTime.Now;

					TicketTransaction ticketTransaction = new TicketTransaction
					{
						TicketID = ticket.ID,
						UserID = userid,
						OldStatus = ticket.Status,
						NewStatus = newStatus,
						ActionDate = DateTime.Now,
						Note = ticketForm.Note,
					};

					_unitOfWork.TicketTransactionRepository.AddEntity(ticketTransaction);
					_unitOfWork.TicketsRepository.UpdateEntity(ticket);
					_unitOfWork.Save();

					return true;
				}
				else
				{
					ticket.SolvedDate = ticketForm.SolvedDate;
					if (newStatus == Status.AdminApproved)
						ticket.SolvedDate = DateTime.Now;

					TicketTransaction ticketTransaction = new TicketTransaction
					{
						TicketID = ticket.ID,
						UserID = userid,
						OldStatus = ticket.Status,
						NewStatus = ticket.Status,
						ActionDate = DateTime.Now,
						Note = ticketForm.Note,
					};

					_unitOfWork.TicketTransactionRepository.AddEntity(ticketTransaction);
					_unitOfWork.TicketsRepository.UpdateEntity(ticket);
					_unitOfWork.Save();

					return true;
				}
			}
			catch(Exception ex) { throw; }
		}
	}
}
