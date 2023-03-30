using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Customers.Commands
{
    public class UpdateCustomerCommandRequest: IRequest<UpdateCustomerCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class UpdateCustomerCommandResponse
    {
    }
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;
        readonly ICustomerWriteRepository _customerWriteRepository;

        public UpdateCustomerCommandHandler(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerReadRepository.GetByIdAsync(request.Id);
            customer.Name = request.Name;
            customer.Email = request.Email;

            await _customerWriteRepository.SaveAsync();

            return new();
        }
    }
}
