using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Cached;

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

        //services.AddTransient<IMediator, Mediator>();
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

        services.AddScoped<IFullRepository<Call>, CallRepository>();
        services.Decorate<IFullRepository<Call>, CallCachedRepository>();

        services.AddScoped<IFullRepository<Contract>, ContractRepository>();
        services.Decorate<IFullRepository<Contract>, ContractRepository>();

        services.AddScoped<IFullRepository<Employee>, EmployeeRepository>();
        services.Decorate<IFullRepository<Employee>, EmployeeRepository>();

        services.AddScoped<IFullRepository<InternetTraffic>, InternetTrafficRepository>();
        services.Decorate<IFullRepository<InternetTraffic>, InternetTrafficRepository>();

        services.AddScoped<IFullRepository<Position>, PositionRepository>();
        services.Decorate<IFullRepository<Position>, PositionRepository>();

        services.AddScoped<IFullRepository<SMS>, SMSRepository>();
        services.Decorate<IFullRepository<SMS>, SMSRepository>();

        services.AddScoped<IFullRepository<Tariff>, TariffRepository>();
        services.Decorate<IFullRepository<Tariff>, TariffRepository>();

        services.AddScoped<IFullRepository<TariffType>, TariffTypeRepository>();
        services.Decorate<IFullRepository<TariffType>, TariffTypeCachedRepository>();

        services.AddScoped<IFullRepository<User>, UserRepository>();
        services.Decorate<IFullRepository<User>, UserCachedRepository>();


        //services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(myConnectionString));
        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        return services;
    }
}
