using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexInternetTrafficViewModel
{
    [Display(Name = "Индентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Дата исп. интернета")]
    public DateTime Date { get; set; }


    [Display(Name = "Номер, с кот. исп. интернет")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Количество потраченных Mб интернета")]
    public int MbSpent { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Id.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               PhoneNumber.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
