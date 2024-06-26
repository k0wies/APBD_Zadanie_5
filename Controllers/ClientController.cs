using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;

namespace Zadanie7.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository repository)
    {
        _clientRepository = repository;
    }

    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
    {
        try
        {
            await _clientRepository.DeleteClientAsync(idClient);
            return Ok($"Client ID: {idClient} deleted");
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }
}