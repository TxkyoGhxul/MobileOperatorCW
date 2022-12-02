using Domain.Base;

namespace Domain;
public class Call : BaseEntity
{
    public Guid ContractId { get; set; }
    public virtual Contract Contract { get; set; }

    public TimeSpan TimeSpan { get; set; }

    public DateTime Date { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Call call &&
               ContractId.Equals(call.ContractId) &&
               TimeSpan.Equals(call.TimeSpan) &&
               Date == call.Date;
    }

    public override string ToString()
    {
        return $"Id: {Id}. TimeSpan: {TimeSpan}. Date: {Date.ToShortDateString()}";
    }
}
