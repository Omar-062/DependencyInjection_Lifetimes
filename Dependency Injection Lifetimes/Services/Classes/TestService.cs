using Dependency_Injection_Lifetimes.Services.Interfaces;

namespace Dependency_Injection_Lifetimes.Services.Classes;

public class TestService:ISingletonService,IScopedService,ITransientService
{
    public string ServiceUniqueIdentifier { get; } = Guid.NewGuid().ToString();
}