using Application.Common.Mappers;
using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.InternetTrafficCommands.Update;

public class UpdateInternetTrafficCommandHandler :
    IRequestHandler<UpdateInternetTrafficCommand, IResponse<Unit>>
{
    private readonly IFullRepository<InternetTraffic> _repository;

    public UpdateInternetTrafficCommandHandler(IFullRepository<InternetTraffic> repository) =>
        _repository = repository;

    public async Task<IResponse<Unit>> Handle(UpdateInternetTrafficCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var traffic = request.ToDomain();

            await _repository.UpdateAsync(traffic, cancellationToken);

            return new Response<Unit>(Unit.Value, Status.Updated);
        }
        catch (Exception ex)
        {
            return new Response<Unit>(ex.Message, Status.NotUpdated);
        }
    }
}
