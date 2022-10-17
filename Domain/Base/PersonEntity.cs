using System.ComponentModel.DataAnnotations;

namespace Domain.Base;
public abstract class PersonEntity : NamedEntity
{
    [Required]
    public string Surname { get; set; }

    [Required]
    public string MiddleName { get; set; }
}
