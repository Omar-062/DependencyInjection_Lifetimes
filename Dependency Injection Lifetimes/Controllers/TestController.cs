using Dependency_Injection_Lifetimes.Services.Classes;
using Dependency_Injection_Lifetimes.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection_Lifetimes.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController:ControllerBase
{
    private readonly ISingletonService _singleton;
    private readonly ITransientService _transient;
    private readonly IScopedService _scoped;
    private readonly DataBaseService _dbService;

    public TestController(ISingletonService singleton,ITransientService transient,IScopedService scoped,DataBaseService dbService)
    {
        _singleton = singleton;
        _scoped = scoped;
        _transient = transient;
        _dbService = dbService; 
    }

    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("\n|||||||||| TestController ||||||||||\n");
        Console.WriteLine($"Singleton UID:\t \t {_singleton.ServiceUniqueIdentifier}");
        Console.WriteLine($"Transient UID:\t \t {_scoped.ServiceUniqueIdentifier}");
        Console.WriteLine($"Scoped UID:\t \t {_transient.ServiceUniqueIdentifier}");
        _dbService.Save();
        return Ok();
    }
}