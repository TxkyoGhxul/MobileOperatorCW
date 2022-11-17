using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexEmployeeViewModel
{
    [Display(Name = "Идентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Имя сотрудника")]
    public string Name { get; set; }


    [Display(Name = "Фамилия сотрудника")]
    public string Surname { get; set; }


    [Display(Name = "Отчество сотрудника")]
    public string MiddleName { get; set; }


    [Display(Name = "Должность сотрудника")]
    public string Position { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Surname.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               MiddleName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Position.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
