using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Customers.Commands
{
    public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class UpdateCustomerCommandResponse
    {
        public DataResult<Customer> Result { get; set; }
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
            try
            {
                Customer customer = await _customerReadRepository.GetByIdAsync(request.Id);
                customer.Name = request.Name;
                customer.Email = request.Email;
                await _customerWriteRepository.SaveAsync();
                return new() { Result = new SuccessDataResult<Customer>(customer, "Müşteri başarıyla güncellendi.") };
            }
            catch
            {
                return new() { Result = new ErrorDataResult<Customer>("Müşteri listelenirken bir hata oluştu.") };
            }
        }
    }
}
