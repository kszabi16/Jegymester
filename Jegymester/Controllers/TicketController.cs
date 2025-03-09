using Microsoft.AspNetCore.Mvc;
using Jegymester.DataContext.Dtos;
using Jegymester.Services;

namespace Jegymester.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        //[HttpPost("buy ticket")]
        //public async Task<IActionResult> BuyTicket([FromBody] CreateTicketDto ticketDto)
        //{
        //    try
        //    {
        //        var result = await _ticketService.BuyTicket(ticketDto);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpGet("Get user tickets")]
        public async Task<IActionResult> GetUserTickets(int userId)
        {
            try
            {
                var result = await _ticketService.GetUserTickets(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        


    }
}
