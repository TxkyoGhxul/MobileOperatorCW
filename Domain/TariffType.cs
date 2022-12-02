using Domain.Base;

namespace Domain;
public class TariffType : NamedEntity
{
    public virtual ICollection<Tariff> Tariffs { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is TariffType type &&
               Name == type.Name;
    }

    public override string ToString() => $"Id: {Id}. Name: {Name}";
}
