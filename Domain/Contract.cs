using Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Contract : BaseEntity
{
    public DateTime Date { get; set; }
    public string PhoneNumber { get; set; }

    [Required]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    [Required]
    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    [Required]
    public Guid TariffId { get; set; }
    public virtual Tariff Tariff { get; set; }

    public virtual ICollection<Call> Calls { get; set; }
    public virtual ICollection<InternetTraffic> InternetTraffics { get; set; }
    public virtual ICollection<SMS> SMSs { get; set; }

    [NotMapped]
    public double AvgCallDurationMins => Calls.Average(x => x.TimeSpan.Minutes);

    [NotMapped]
    public int AmountTransferredData => InternetTraffics.Sum(x => x.MbSpent);

    [NotMapped]
    public int CountSMS => SMSs.Count;

    public override bool Equals(object? obj)
    {
        return obj is Contract contract &&
               Date == contract.Date &&
               PhoneNumber == contract.PhoneNumber &&
               UserId.Equals(contract.UserId) &&
               EmployeeId.Equals(contract.EmployeeId) &&
               TariffId.Equals(contract.TariffId);
    }

    public override string ToString()
    {
        return $"Id: {Id}. User Id: {UserId}. Employee: {EmployeeId}. " +
            $"Date: {Date.ToShortDateString()}. Tariff Id: {TariffId}. Number: {PhoneNumber}";
    }
}
