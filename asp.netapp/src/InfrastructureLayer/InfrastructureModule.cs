using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure_Layer;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("PasswordDb"));

        services.AddScoped<IPasswordEntryRepository, PasswordEntryRepository>();

        return services;
    }
}