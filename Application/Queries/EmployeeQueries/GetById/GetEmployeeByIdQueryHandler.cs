using Application.Common.Responses;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Queries.EmployeeQueries.GetById;

public class GetEmployeeByIdQueryHandler : 
    IRequestHandler<GetEmployeeByIdQuery, IResponse<Employee>>
{
    private readonly IFullRepository<Employee> _repository;

    public GetEmployeeByIdQueryHandler(IFullRepository<Employee> repository) =>
        _repository = repository;

    public async Task<IResponse<Employee>> Handle(GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.SelectByIdAsync(request.Id, cancellationToken);

            return new Response<Employee>(response);
        }
        catch (Exception ex)
        {
            return new Response<Employee>(ex.Message);
        }
    }
}
