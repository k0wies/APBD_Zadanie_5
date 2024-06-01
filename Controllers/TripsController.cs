using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;
using Zadanie7.Models.DTOs.Request;

namespace Zadanie7.Controllers
{
    [ApiController]
    [Route("api/trips")]
    public class TripsController : ControllerBase
    {
        private readonly ITripsRepository _tripRepository;

        public TripsController(ITripsRepository tripsRepository)
        {
            _tripRepository = tripsRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            try
            {
                var trips = await _tripRepository.GetTripsAsync();
                return Ok(trips);
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddTripToClient([FromRoute] int idTrip, [FromBody] AddTripToClientRequestDTO dto)
        {
            try
            {
                await _tripRepository.AddTripToClientAsync(idTrip, dto);
                return Ok("Your request processed successfully");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}