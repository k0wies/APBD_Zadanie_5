using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;

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
            var result = _tripRepository.GetTripsAsync();
            return Ok(result);
        }
    }
}