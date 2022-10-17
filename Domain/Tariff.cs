using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Tariff : NamedEntity
{
    public decimal Cost { get; set; }
    public decimal LocalCost { get; set; }
    public decimal TownCost { get; set; }
    public decimal CountryCost { get; set; }
    public decimal SMSCost { get; set; }
    public decimal MbCost { get; set; }

    [Required]
    public Guid TariffTypeId { get; set; }
    public virtual TariffType TariffType { get; set; }

    public virtual List<Contract> Contracts { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}. Name: {Name}. Cost: {Cost}. LocalCost: {LocalCost}. " +
               $"TownCost: {TownCost}. CountryCost: {CountryCost}. SMSCost: {SMSCost}. MbCost: {MbCost}";
    }
}
