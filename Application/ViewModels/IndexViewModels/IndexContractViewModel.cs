using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexContractViewModel
{
    [Display(Name = "Индентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Дата заключения договора")]
    public DateOnly Date { get; set; }


    [Display(Name = "Название тарифа")]
    public string Tariff { get; set; }


    [Display(Name = "Фамилия работника")]
    public string EmployeeSurname { get; set; }


    [Display(Name = "Фамилия пользователя")]
    public string UserSurname { get; set; }


    [Display(Name = "Номер телефона")]
    public string PhoneNumber { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Tariff.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Id.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Date.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               EmployeeSurname.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               UserSurname.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               PhoneNumber.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
