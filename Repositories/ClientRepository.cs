using Microsoft.EntityFrameworkCore;
using Zadanie7.Interfaces;
using Zadanie7.Models;

namespace Zadanie7.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApbdZadanie7Context _context;

    public ClientRepository(ApbdZadanie7Context context)
    {
        _context = context;
    }

    public async Task DeleteClientAsync(int idClient)
    {
        bool hasTrips = await _context.ClientTrips.AnyAsync(row => row.IdClient == idClient);

        if (hasTrips) throw new Exception("Client has one or more trips!");

        Client client = await _context.Clients.Where(row => row.IdClient == idClient).FirstOrDefault();
        _ = _context.Remove(client);

        await _context.SaveChangesAsync();
    }
    
}