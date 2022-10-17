using System.ComponentModel.DataAnnotations;

namespace Domain.Base;
public abstract class BaseEntity : IEntity<Guid>
{
    [Required]
    public Guid Id { get; set; }
}
