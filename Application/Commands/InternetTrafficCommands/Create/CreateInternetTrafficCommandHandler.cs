using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.InternetTrafficCommands.Create;

public class CreateInternetTrafficCommandHandler : 
    IRequestHandler<CreateInternetTrafficCommand, IResponse<Guid>>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public CreateInternetTrafficCommandHandler(IFullRepository<InternetTraffic> repository) =>
        _repository = repository;

    public async Task<IResponse<Guid>> Handle(CreateInternetTrafficCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var traffic = request.ToDomain();

            var response = await _repository.InsertAsync(traffic, cancellationToken);

            return new Response<Guid>(response, Status.Created);
        }
        catch (Exception ex)
        {
            return new Response<Guid>(ex.Message, Status.NotCreated);
        }
    }
}
