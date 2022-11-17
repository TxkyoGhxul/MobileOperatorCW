using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexCallViewModel
{
    [Display(Name = "Индентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Дата звонка")]
    public DateTime Date { get; set; }


    [Display(Name = "Номер, с кот. позвонили")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Длительность разговора")]
    public TimeSpan TimeSpan { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Id.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Date.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               PhoneNumber.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
