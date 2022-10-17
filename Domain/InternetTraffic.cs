using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class InternetTraffic : BaseEntity
{
    [Required]
    public Guid ContractId { get; set; }
    public virtual Contract Contract { get; set; }

    public DateTime Date { get; set; }

    public int MbSpent { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}. Date: {Date.ToShortDateString()}. Mb spent: {MbSpent}";
    }
}
