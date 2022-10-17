using Domain.Base;

namespace Domain;
public class TariffType : NamedEntity
{
    public virtual ICollection<Tariff> Tariffs { get; set; }

    public override string ToString() => $"Id: {Id}. Name: {Name}";
}
