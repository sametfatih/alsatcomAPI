using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Customers;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Customers.Queries
{
    public class GetByIdCustomerQueryRequest : IRequest<GetByIdCustomerQueryResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdCustomerQueryResponse : DataResult<VM_Customer>
    {
        public GetByIdCustomerQueryResponse(VM_Customer data, bool success) : base(data, success)
        {
        }

        public GetByIdCustomerQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetByIdCustomerQueryResponse(VM_Customer data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetByIdCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = await _customerReadRepository.GetByIdAsync(request.Id, false);
                VM_Customer model = new() { Name = customer.Name, Email = customer.Email };

                return new GetByIdCustomerQueryResponse(model, true, "Successful.");
            }
            catch
            {
                return new GetByIdCustomerQueryResponse(false, "Error occured.");
            }
        }
    }
}
