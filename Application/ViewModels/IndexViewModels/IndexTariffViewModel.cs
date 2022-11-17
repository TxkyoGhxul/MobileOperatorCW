using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexTariffViewModel
{
    [Display(Name = "Идентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Название тарифа")]
    public string Name { get; set; }


    [Display(Name = "Стоимость тарифа")]
    public decimal Cost { get; set; }


    [Display(Name = "Стоимость одного мб интернета")]
    public decimal MbCost { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Id.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Name.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
