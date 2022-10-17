using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IMediator, Mediator>();
        //services.AddSingleton<ApplicationDbContext>();

        //// Services registration
        //services.AddTransient<IRepository<Call>, CallRepository>();
        //services.AddTransient<IRepository<Contract>, ContractRepository>();
        //services.AddTransient<IRepository<Employee>, EmployeeRepository>();
        //services.AddTransient<IRepository<InternetTraffic>, InternetTrafficRepository>();
        //services.AddTransient<IRepository<Position>, PositionRepository>();
        //services.AddTransient<IRepository<SMS>, SMSRepository>();
        //services.AddTransient<IRepository<Tariff>, TariffRepository>();
        //services.AddTransient<IRepository<TariffType>, TariffTypeRepository>();
        //services.AddTransient<IRepository<User>, UserRepository>();

        //// Async services registration
        //services.AddTransient<IAsyncRepository<Call>, CallRepository>();
        //services.AddTransient<IAsyncRepository<Contract>, ContractRepository>();
        //services.AddTransient<IAsyncRepository<Employee>, EmployeeRepository>();
        //services.AddTransient<IAsyncRepository<InternetTraffic>, InternetTrafficRepository>();
        //services.AddTransient<IAsyncRepository<Position>, PositionRepository>();
        //services.AddTransient<IAsyncRepository<SMS>, SMSRepository>();
        //services.AddTransient<IAsyncRepository<Tariff>, TariffRepository>();
        //services.AddTransient<IAsyncRepository<TariffType>, TariffTypeRepository>();
        //services.AddTransient<IAsyncRepository<User>, UserRepository>();

        services.AddTransient<IFullRepository<Call>, CallRepository>();
        services.AddTransient<IFullRepository<Contract>, ContractRepository>();
        services.AddTransient<IFullRepository<Employee>, EmployeeRepository>();
        services.AddTransient<IFullRepository<InternetTraffic>, InternetTrafficRepository>();
        services.AddTransient<IFullRepository<Position>, PositionRepository>();
        services.AddTransient<IFullRepository<SMS>, SMSRepository>();
        services.AddTransient<IFullRepository<Tariff>, TariffRepository>();
        services.AddTransient<IFullRepository<TariffType>, TariffTypeRepository>();
        services.AddTransient<IFullRepository<User>, UserRepository>();


        //services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(myConnectionString));
        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        return services;
    }
}
