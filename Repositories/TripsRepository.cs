using Microsoft.EntityFrameworkCore;
using Zadanie7.Interfaces;
using Zadanie7.Models;
using Zadanie7.Models.DTOs;

namespace Zadanie7.Repositories;

public class TripsRepository : ITripsRepository
{
    private readonly ApbdZadanie7Context _context;

    public TripsRepository(ApbdZadanie7Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TripDTO>> GetTripsAsync()
    {
        var result = await _context
            .Trips
            .Select(e =>
                new TripDTO
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    MaxPeople = e.MaxPeople,
                    Countries = e.IdCountries
                        .Select(e =>
                            new CountryDTO { Name = e.Name }),
                    Clients = e.ClientTrips
                        .Select(e => new ClientDTO
                            { FirstName = e.IdClientNavigation.FirstName, 
                                LastName = e.IdClientNavigation.LastName })
                }).ToListAsync();
        return result;
    }
}