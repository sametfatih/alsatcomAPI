using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Orders.Queries
{
    public class GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdOrderQueryResponse
    {
        public Guid CustomerId { get; set; }
        public string Adress { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;

        public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderReadRepository.GetByIdWithInclude(request.Id,false);
            //todo if(!result)
            return new()
            {
                Customer = order.Customer,
                Products = order.Products,
                Adress = order.Adress
            };

        }
    }
}
