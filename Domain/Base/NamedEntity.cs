using System.ComponentModel.DataAnnotations;

namespace Domain.Base;
public abstract class NamedEntity : BaseEntity
{
    [Required]
    public string Name { get; set; }
}
