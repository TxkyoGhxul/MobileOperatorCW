using Application.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.TariffCommands.Update;
public record UpdateTariffCommand([Display(Name = "Идентификатор")] Guid Id,

    [Display(Name = "Название тарифа")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Название тарифа должно содержать от 3 до 25 символов")]
    string Name,

    [Display(Name = "Стоимость тарифа")]
    decimal Cost,

    [Display(Name = "Стоимость местных звонков")]
    decimal LocalCost,

    [Display(Name = "Стоимость городских звонков")]
    decimal TownCost,

    [Display(Name = "Стоимость межстранных звонков")]
    decimal CountryCost,

    [Display(Name = "Стоимость отправки смс")]
    decimal SMSCost,

    [Display(Name = "Стоимость одного мб интернета")]
    decimal MbCost,

    [Display(Name = "Идентификатор типа тарификации")]
    Guid TariffTypeId) : IRequest<IResponse<Unit>>;
