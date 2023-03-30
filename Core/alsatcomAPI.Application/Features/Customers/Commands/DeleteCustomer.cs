using alsatcomAPI.Application.Repositories;
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
            await _customerWriteRepository.RemoveAsync(request.Id);
            await _customerWriteRepository.SaveAsync();

            return new();
        }
    }
}
