using Domain.Base;

namespace Domain;
public class Position : NamedEntity
{
    public decimal Salary { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Position position &&
               Name == position.Name &&
               Salary == position.Salary;
    }

    public override string ToString()
    {
        return $"Id: {Id}. Name: {Name}. Salary: {Salary}";
    }
}
