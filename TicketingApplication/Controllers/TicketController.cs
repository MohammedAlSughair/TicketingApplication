using TicketingApplication.Models;
using TicketingApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingApplication.Repository;
using NLog;

namespace TicketingApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly ITicketService _ticketService;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();


		public TicketController(ITicketService ticketService)
		{
			_ticketService = ticketService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_ticketService.GetAllTicket(Request.Cookies["userid"], Request.Cookies["usertype"]));
			}
			catch (Exception ex)
			{
				_logger.Info("Message: " + ex.Message + " --InnerException: " + ex.InnerException);
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				return Ok(_ticketService.GetTicket(id));
			}
			catch (Exception ex)
			{
				_logger.Info("Message: " + ex.Message );
				return BadRequest();
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody] TicketFormViewModel tickets)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_ticketService.AddTicket(tickets);
					return Ok();
				}
				else return BadRequest(ModelState);
			}

			catch (Exception ex)
			{
				_logger.Info("Message: " + ex.Message + " --InnerException: " + ex.InnerException);
				return BadRequest("Faild to save the Ticket");
			}
		}

		[HttpPut]
		public IActionResult Put([FromBody] TicketFormViewModel ticket)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_ticketService.UpdateTicketStatus(ticket, 1);
					return Ok();
				}
				else return BadRequest(ModelState);
			}
			catch (Exception ex)
			{
				_logger.Info("Message: " + ex.Message + " --InnerException: " + ex.InnerException);
				return BadRequest("Faild to Update Ticket");
			}
		}
	}
}
