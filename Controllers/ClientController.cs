using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;

namespace Zadanie7.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : Controller
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository repository)
    {
        _clientRepository = repository;
    }
}