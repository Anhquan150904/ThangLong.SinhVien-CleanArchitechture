using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThangLong.Domain.Repositories;
using ThangLong.Infrastructure.Data;
using ThangLong.Infrastructure.Repositories;

namespace ThangLong.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("Default");
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));

        services.AddScoped<ISinhVienRepository, SinhVienRepository>();
        return services;
    }
}
