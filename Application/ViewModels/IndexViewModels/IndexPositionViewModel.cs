using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexPositionViewModel
{
    [Display(Name = "Индентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Должность")]
    public string Name { get; set; }


    [Display(Name = "Зарплата")]
    public decimal Salary { get; set; }

    public bool IsContainFilter(string filter) => Name.Contains(filter, StringComparison.OrdinalIgnoreCase);
}
