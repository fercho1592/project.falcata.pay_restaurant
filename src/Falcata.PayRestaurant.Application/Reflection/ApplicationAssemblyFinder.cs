using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Falcata.PayRestaurant.Application.Reflection;

[ExcludeFromCodeCoverage]
public static class ApplicationAssemblyFinder
{
    public static Assembly GetAssembly() => typeof(ApplicationAssemblyFinder).Assembly;
}