using TicketingApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketingApplication.Controllers
{
	[Route("api/ticket/{ticketid}/tickettransaction")]
	[ApiController]
	public class TicketTransactionController : ControllerBase
	{
		private readonly ITicketTransactionService _ticketTransactionService;
		public TicketTransactionController(ITicketTransactionService ticketTransactionService)
		{
			_ticketTransactionService = ticketTransactionService;
		}

		[HttpGet]
		public IActionResult Get(int ticketid)
		{
			return Ok(_ticketTransactionService.GetTransaction(ticketid));
		}
	}
}
