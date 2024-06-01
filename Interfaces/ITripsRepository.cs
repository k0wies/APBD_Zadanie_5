using Zadanie7.Models.DTOs;
using Zadanie7.Models.DTOs.Request;

namespace Zadanie7.Interfaces;

public interface ITripsRepository
{
   Task<IEnumerable<TripDTO>> GetTripsAsync();
   Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDTO dto);
}