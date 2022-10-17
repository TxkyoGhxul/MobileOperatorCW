using Application.Interfaces;
using Bogus;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using System.Diagnostics.Contracts;

namespace ConsoleApp1;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        // установка пути к текущему каталогу
        builder.SetBasePath(Directory.GetCurrentDirectory());
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile("appsettings.json");
        // создаем конфигурацию
        var config = builder.Build();
        // получаем строку подключения
        string connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var options = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;

        Console.WriteLine("1.Тест\n");
        Task(options);
        Console.WriteLine("1.Тест\n");
    }

    private static void Task(DbContextOptions<ApplicationDbContext> options)
    {
        var smss = new SMSRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var contracts = new ContractRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var employees = new EmployeeRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var inttraffs = new InternetTrafficRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var positions = new PositionRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var calls = new CallRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var tariffs = new TariffRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var tts = new TariffTypeRepository(new ApplicationDbContext(options)).SelectAll().Take(10);
        var users = new UserRepository(new ApplicationDbContext(options)).SelectAll().Take(10);

        foreach (var item in smss)
            Console.WriteLine(item);

        foreach (var item in contracts)
            Console.WriteLine(item);

        foreach (var item in employees)
            Console.WriteLine(item);

        foreach (var item in inttraffs)
            Console.WriteLine(item);

        foreach (var item in positions)
            Console.WriteLine(item);

        foreach (var item in calls)
            Console.WriteLine(item);

        foreach (var item in tariffs)
            Console.WriteLine(item);

        foreach (var item in tts)
            Console.WriteLine(item);

        foreach (var item in users)
            Console.WriteLine(item);
    }
}
