using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class SMS : BaseEntity
{
    [Required]
    public Guid ContractId { get; set; }
    public virtual Contract Contract { get; set; }

    public string Message { get; set; }

    public DateTime Date { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is SMS sMS &&
               ContractId.Equals(sMS.ContractId) &&
               Message == sMS.Message &&
               Date == sMS.Date;
    }

    public override string ToString()
    {
        return $"Id: {Id}. Message: {Message}. Date: {Date}";
    }
}
