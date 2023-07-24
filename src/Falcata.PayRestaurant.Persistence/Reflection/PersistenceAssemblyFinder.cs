using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Falcata.PayRestaurant.Persistence.Reflection;

[ExcludeFromCodeCoverage]
public static class PersistenceAssemblyFinder
{ 
    public static Assembly GetAssembly() => typeof(PersistenceAssemblyFinder).Assembly;
}