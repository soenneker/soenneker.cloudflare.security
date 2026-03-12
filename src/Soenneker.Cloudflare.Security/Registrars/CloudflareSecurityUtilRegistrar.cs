using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cloudflare.Security.Abstract;
using Soenneker.Cloudflare.Utils.Client.Registrars;

namespace Soenneker.Cloudflare.Security.Registrars;

/// <summary>
/// A utility for managing Cloudflare Security settings
/// </summary>
public static class CloudflareSecurityUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ICloudflareSecurityUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudflareSecurityUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCloudflareClientUtilAsSingleton().TryAddSingleton<ICloudflareSecurityUtil, CloudflareSecurityUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ICloudflareSecurityUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudflareSecurityUtilAsScoped(this IServiceCollection services)
    {
        services.AddCloudflareClientUtilAsSingleton().TryAddScoped<ICloudflareSecurityUtil, CloudflareSecurityUtil>();

        return services;
    }
}
