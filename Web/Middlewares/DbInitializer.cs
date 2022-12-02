using Domain;
using Persistence;

namespace Web.Middlewares;
public class DbInitializer
{
    public static void Initialize(ApplicationDbContext db)
    {
        var positionInitializer = new PositionsInitializer(db);
        positionInitializer.Initialize();

        var employeesInitializer = new EmployeesInitializer(db);
        employeesInitializer.Initialize();

        var tariffTypesInitializer = new TariffTypesInitializer(db);
        tariffTypesInitializer.Initialize();

        var tariffInitializer = new TariffsInitializer(db);
        tariffInitializer.Initialize();

        var usersInitializer = new UsersInitializer(db);
        usersInitializer.Initialize();

        var contractsInitializer = new ContractsInitializer(db);
        contractsInitializer.Initialize();

        var smssInitializer = new SMSsInitializer(db);
        smssInitializer.Initialize();

        var callsInitializer = new CallsInitializer(db);
        callsInitializer.Initialize();

        var internetTrafficsInitializer = new InternetTrafficsInitializer(db);
        internetTrafficsInitializer.Initialize();
    }

    private class PositionsInitializer
    {
        private readonly ApplicationDbContext _db;

        public PositionsInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var positions = Enumerable.Range(1, 10).Select(x => new Position
            {
                Name = $"Position{x}",
                Salary = x * 100
            });

            foreach (var position in positions)
            {
                _db.Positions.Add(position);
            }

            _db.SaveChanges();
        }
    }

    private class EmployeesInitializer
    {
        private readonly ApplicationDbContext _db;

        public EmployeesInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var positionsCount = _db.Positions.Count();

            var employees = Enumerable.Range(1, 50).Select(x => new Employee
            {
                Name = $"Name{x}",
                Surname = $"Surname{x}",
                MiddleName = $"MiddleName{x}",
                PositionId = _db.Positions.ToArray()[new Random().Next(positionsCount)].Id
            });

            foreach (var employee in employees)
            {
                _db.Employees.Add(employee);
            }

            _db.SaveChanges();
        }
    }

    private class UsersInitializer
    {
        private readonly ApplicationDbContext _db;

        public UsersInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var users = Enumerable.Range(1, 50).Select(x => new Domain.User
            {
                Name = $"Name{x}",
                Surname = $"Surname{x}",
                MiddleName = $"MiddleName{x}",
                Passport = $"Passport{x}",
                Adress = $"Adress{x}",
            });

            foreach (var user in users)
            {
                _db.Users.Add(user);
            }

            _db.SaveChanges();
        }
    }

    private class ContractsInitializer
    {
        private readonly ApplicationDbContext _db;

        public ContractsInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var random = new Random();

            var usersCount = _db.Users.Count();
            var employeesCount = _db.Employees.Count();
            var tariffsCount = _db.Tariffs.Count();

            var contracts = Enumerable.Range(1, 500).Select(x => new Contract
            {
                UserId = _db.Users.ToArray()[new Random().Next(usersCount)].Id,
                EmployeeId = _db.Employees.ToArray()[new Random().Next(employeesCount)].Id,
                TariffId = _db.Tariffs.ToArray()[new Random().Next(tariffsCount)].Id,
                PhoneNumber = $"{x}"
            });

            foreach (var contract in contracts)
            {
                _db.Contracts.Add(contract);
            }

            _db.SaveChanges();
        }
    }

    private class InternetTrafficsInitializer
    {
        private readonly ApplicationDbContext _db;

        public InternetTrafficsInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var contractsCount = _db.Contracts.Count();

            var internetTraffics = Enumerable.Range(1, 500).Select(x => new InternetTraffic
            {
                ContractId = _db.Contracts.ToArray()[new Random().Next(contractsCount)].Id,
                Date = DateTime.Now,
                MbSpent = x
            });

            foreach (var it in internetTraffics)
            {
                _db.InternetTraffics.Add(it);
            }

            _db.SaveChanges();
        }
    }

    private class CallsInitializer
    {
        private readonly ApplicationDbContext _db;

        public CallsInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var contractsCount = _db.Contracts.Count();

            var calls = Enumerable.Range(1, 500).Select(x => new Call
            {
                ContractId = _db.Contracts.ToArray()[new Random().Next(contractsCount)].Id,
                Date = DateTime.Now,
                TimeSpan = TimeSpan.FromMinutes(new Random().Next(100))
            });

            foreach (var call in calls)
            {
                _db.Calls.Add(call);
            }

            _db.SaveChanges();
        }
    }

    private class SMSsInitializer
    {
        private readonly ApplicationDbContext _db;

        public SMSsInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var contractsCount = _db.Contracts.Count();

            var smss = Enumerable.Range(1, 500).Select(x => new SMS
            {
                ContractId = _db.Contracts.ToArray()[new Random().Next(contractsCount)].Id,
                Date = DateTime.Now,
                Message = $"Message {x}"
            });

            foreach (var sms in smss)
            {
                _db.SMSs.Add(sms);
            }

            _db.SaveChanges();
        }
    }

    private class TariffsInitializer
    {
        private readonly ApplicationDbContext _db;

        public TariffsInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var tariffTypesCount = 2;

            var tariffs = Enumerable.Range(1, 25).Select(x => new Tariff
            {
                Name = $"Name {x}",
                Cost = x,
                LocalCost = x,
                TownCost = x,
                CountryCost = x,
                SMSCost = x,
                MbCost = x,
                TariffTypeId = _db.TariffTypes.ToArray()[new Random().Next(tariffTypesCount)].Id
            });

            foreach (var tariff in tariffs)
            {
                _db.Tariffs.Add(tariff);
            }

            _db.SaveChanges();
        }
    }

    private class TariffTypesInitializer
    {
        private readonly ApplicationDbContext _db;

        public TariffTypesInitializer(ApplicationDbContext db) => _db = db;

        public void Initialize()
        {
            var tariffTypes = Enumerable.Range(1, 2).Select(x => new TariffType
            {
                Name = $"Tariff Type {x}"
            });

            foreach (var tt in tariffTypes)
            {
                _db.TariffTypes.Add(tt);
            }

            _db.SaveChanges();
        }
    }
}
