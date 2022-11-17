using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexTariffTypeViewModel
{
    [Display(Name = "Индентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Тип тарификации")]
    public string Name { get; set; }

    public bool IsContainFilter(string filter) => Name.Contains(filter, StringComparison.OrdinalIgnoreCase);
}
