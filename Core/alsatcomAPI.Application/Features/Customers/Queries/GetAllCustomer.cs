using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Customers;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Customers.Queries
{
    public class GetAllCustomerQueryRequest : IRequest<GetAllCustomerQueryResponse>
    {
    }
    public class GetAllCustomerQueryResponse :  DataResult<List<VM_Customer>>
    {
        public GetAllCustomerQueryResponse(List<VM_Customer> data, bool success) : base(data, success)
        {
        }

        public GetAllCustomerQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetAllCustomerQueryResponse(List<VM_Customer> data, bool success, string message) : base(data,success,message)
        {
        }


    }
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetAllCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<VM_Customer> customers = _customerReadRepository.GetAll(false).Select(c => new VM_Customer
                {
                    Name = c.Name,
                    Email = c.Email
                }).ToList();
                return new GetAllCustomerQueryResponse(customers,true,"Successful.");
            }
            catch
            {
                return new GetAllCustomerQueryResponse(false, "Error occured.");
            }
        }
    }
}
