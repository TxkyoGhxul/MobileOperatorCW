using System.ComponentModel.DataAnnotations;

namespace Domain.Base;
public abstract class NamedEntity : BaseEntity
{
    [Required]
    public string Name { get; set; }
}

public abstract class NamedEntity<T> : BaseEntity<T>
{
    [Required]
    public string Name { get; set; }
}
