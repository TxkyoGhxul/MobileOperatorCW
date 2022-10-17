using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.TariffTypeCommands.Create;
public class CreateTariffTypeCommandHandler : IRequestHandler<CreateTariffTypeCommand, Guid>
{
    private readonly IFullRepository<TariffType> _repository;

    public CreateTariffTypeCommandHandler(IFullRepository<TariffType> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateTariffTypeCommand request, CancellationToken cancellationToken)
    {
        TariffType tariffType = new TariffType
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        return await _repository.InsertAsync(tariffType, cancellationToken);
    }
}
