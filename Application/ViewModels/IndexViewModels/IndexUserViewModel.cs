using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexUserViewModel
{
    [Display(Name = "Идентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Имя пользователя")]
    public string Name { get; set; }


    [Display(Name = "Фамилия пользователя")]
    public string Surname { get; set; }


    [Display(Name = "Отчество пользователя")]
    public string MiddleName { get; set; }


    [Display(Name = "Должность пользователя")]
    public string Passport { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Surname.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               MiddleName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Passport.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
