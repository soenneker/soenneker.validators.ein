using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Validators.Ein.Abstract;

namespace Soenneker.Validators.Ein.Registrars;

/// <summary>
/// A validation module checking the syntax of Employer identification numbers (EINs)
/// </summary>
public static class EinValidatorRegistrar
{
    /// <summary>
    /// Adds <see cref="IEinValidator"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddEinValidatorAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IEinValidator, EinValidator>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IEinValidator"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddEinValidatorAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IEinValidator, EinValidator>();

        return services;
    }
}
