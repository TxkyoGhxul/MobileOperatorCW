using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.IndexViewModels;
public class IndexSMSViewModel
{
    [Display(Name = "Индентификатор")]
    public Guid Id { get; set; }


    [Display(Name = "Дата написания сообщения")]
    public DateTime Date { get; set; }


    [Display(Name = "Номер, с кот. написали сообщение")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Сообщение")]
    public string Message { get; set; }

    public bool IsContainFilter(string filter)
    {
        return Id.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               Message.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
               PhoneNumber.Contains(filter, StringComparison.OrdinalIgnoreCase);
    }
}
