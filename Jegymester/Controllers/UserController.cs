using Jegymester.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jegymester.DataContext.Dtos;
using Jegymester.DataContext.Entities;


namespace Jegymester.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto userDto)
        {
            try
            {
                var result = await _userService.Register(userDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userDto)
        {
            try
            {
                var token = await _userService.Login(userDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("update")]
        //public async Task<IActionResult> Update([FromBody] UserDto userDto)
        //{
        //    try
        //    {
        //        var result = await _userService.Update(userDto);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPost("list tickets")]

        public async Task<IActionResult> GetUserTickets([FromBody] int userId)
        {
            try
            {
                var result = await _userService.GetUserTickets(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost("delete ticket")]
        //public async Task<IActionResult> CancelTicket([FromBody] int ticketId)
        //{
        //    int userId = _userService.(); // Implementáld a felhasználó azonosítását

        //    var result = await _userService.CancelTicket(userId, ticketId);

        //    return result switch
        //    {
        //        TicketDelete.Success => Ok("A jegy sikeresen törölve."),
        //        TicketDelete.TicketNotFound => NotFound("A jegy nem található."),
        //        TicketDelete.NotOwner => Forbid("Nincs jogosultságod ennek a jegynek a törlésére."),
        //        TicketDelete.ScreeningTooSoon => BadRequest("A vetítés 4 órán belül kezdődik, nem törölhető."),
        //        _ => StatusCode(500, "Ismeretlen hiba történt.")
        //    };
        //}




    }
}
