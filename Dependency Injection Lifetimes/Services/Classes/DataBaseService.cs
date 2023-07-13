using Dependency_Injection_Lifetimes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection_Lifetimes.Services.Classes;

public class DataBaseService
{
    private readonly ISingletonService _singleton;
    private readonly ITransientService _transient;
    private readonly IScopedService _scoped;

    public DataBaseService(ISingletonService singleton,ITransientService transient,IScopedService scoped)
    {
        _singleton = singleton;
        _scoped = scoped;
        _transient = transient;
    }

    
    public void Save()
    {
        Console.WriteLine("\n|||||||||| DatabaseService ||||||||||\n");
        Console.WriteLine($"Singleton UID:\t \t {_singleton.ServiceUniqueIdentifier}");
        Console.WriteLine($"Transient UID:\t \t {_scoped.ServiceUniqueIdentifier}");
        Console.WriteLine($"Scoped UID:\t \t {_transient.ServiceUniqueIdentifier}");
    }
}