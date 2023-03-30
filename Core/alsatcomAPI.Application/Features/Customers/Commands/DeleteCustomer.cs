using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Customers.Commands
{
    public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
    {
        public string Id { get; set; }
    }
    public class DeleteCustomerCommandResponse
    {
        public IResult Result { get; set; }
    }
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
    {
        
        readonly ICustomerWriteRepository _customerWriteRepository;

        public DeleteCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _customerWriteRepository.RemoveAsync(request.Id);
                await _customerWriteRepository.SaveAsync();
                return new() { Result = new SuccessResult() };
            }
            catch
            {
                return new() { Result = new ErrorResult() };
            }
        }
    }
}
