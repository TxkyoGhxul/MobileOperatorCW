using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Employee : PersonEntity
{
    [Required]
    public Guid PositionId { get; set; }
    public virtual Position Position { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Employee employee &&
               Name == employee.Name &&
               Surname == employee.Surname &&
               MiddleName == employee.MiddleName &&
               PositionId.Equals(employee.PositionId);
    }

    public override string ToString() => 
        $"Id: {Id}. Name: {Name}. Surname: {Surname}. " +
        $"MiddleName: {MiddleName}. Position id: {PositionId}";
}
