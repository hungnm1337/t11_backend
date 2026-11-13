using Microsoft.Extensions.DependencyInjection;
using t11.Application.Services;

namespace t11.Infrastructure.Services;

public static class CrudServiceRegistration
{
    public static IServiceCollection AddCrudServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudService<,,,>));
        services.AddScoped<IPhieuNhapTransactionService, PhieuNhapTransactionService>();
        services.AddScoped<IPhieuDieuChuyenTransactionService, PhieuDieuChuyenTransactionService>();
        return services;
    }
}
