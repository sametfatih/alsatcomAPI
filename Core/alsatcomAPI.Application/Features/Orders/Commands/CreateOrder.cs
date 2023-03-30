using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Orders.Commands
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string CustomerId { get; set; }
        public string Adress { get; set; }       
        public List<string> Products { get; set; }
    }
    public class CreateOrderCommandResponse
    {
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly ICustomerReadRepository _customerReadRepository;
        readonly IProductReadRepository _productReadRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, IProductReadRepository productReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
          
            ICollection<Product> products = _productReadRepository.GetWhere(p => request.Products.Contains(p.Id.ToString())).ToList();        
            Customer customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);

            Order order = new() { Customer = customer, Adress = request.Adress, Products = products};
            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            return new();
        }
    }
}
