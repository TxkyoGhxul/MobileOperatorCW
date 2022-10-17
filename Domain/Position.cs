using Domain.Base;

namespace Domain;
public class Position : NamedEntity
{
    public decimal Salary { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}. Name: {Name}. Salary: {Salary}";
    }
}
