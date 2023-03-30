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
    public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryResponse>
    {
    }
    public class GetAllOrderQueryResponse
    {
        public List<Order> Orders { get; set; }
    }
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;

        public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            List<Order> orders = _orderReadRepository.GetAll(false).ToList();

            return new() { Orders = orders };
        }
    }
}
