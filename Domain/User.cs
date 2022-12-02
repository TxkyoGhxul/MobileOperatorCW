using Domain.Base;

namespace Domain;
public class User : PersonEntity
{
    public string Adress { get; set; }
    public string Passport { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               Name == user.Name &&
               Surname == user.Surname &&
               MiddleName == user.MiddleName &&
               Adress == user.Adress &&
               Passport == user.Passport;
    }

    public override string ToString()
    {
        return $"Id: {Id}. Name: {Name}. Surname: {Surname}. " +
               $"MiddleName: {MiddleName}. Adress: {Adress}. Passport: {Passport}";
    }
}
