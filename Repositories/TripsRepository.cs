using Microsoft.EntityFrameworkCore;
using Zadanie7.Interfaces;
using Zadanie7.Models;
using Zadanie7.Models.DTOs;
using Zadanie7.Models.DTOs.Request;

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

    public async Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDTO dto)
    {
        bool ClientExists = await _context.Clients.AnyAsync(row => row.Pesel == dto.Pesel);

        Client wantedClient;
        if (!ClientExists)
        {
            wantedClient = new Client
            {
                IdClient = await _context.Clients.Select(row => row.IdClient).MaxAsync() + 1,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Telephone = dto.Telephone,
                Pesel = dto.Pesel
            };

            await _context.Clients.AddAsync(wantedClient);
            await _context.SaveChangesAsync();
        }
        else
        {
            wantedClient = await _context.Clients.FirstOrDefaultAsync(row => row.Pesel == dto.Pesel);
        }

        bool TripExists = await _context.Trips.AnyAsync(row => row.IdTrip == idTrip);
        if (!TripExists) throw new Exception($"There is no such trip with ID: {idTrip}!");

        bool isClientAlreadyReservedThisTrip = await _context.ClientTrips.AnyAsync(row => row.IdClient == wantedClient.IdClient);
        if (isClientAlreadyReservedThisTrip) throw new Exception("Client is already reserved that trip!");
        {
            
        }
        
        await _context.ClientTrips.AddAsync(new ClientTrip
        {
            IdClient = wantedClient.IdClient,
            IdTrip = idTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = dto.PaymentDate
        });
        await _context.SaveChangesAsync();
    }
}