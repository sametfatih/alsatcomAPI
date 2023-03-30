using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Orders;
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
        public DataResult<List<VM_Order>> Result { get; set; }
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
            try
            {
                List<VM_Order> orders = _orderReadRepository.GetAll(false).Select(o => new VM_Order
                {
                    CustomerId = o.CustomerId.ToString(),
                    Adress = o.Adress,

                }).ToList();

                return new() { Result = new SuccessDataResult<List<VM_Order>>(orders) };
            }
            catch
            {
                return new() { Result = new ErrorDataResult<List<VM_Order>>() };
            }
        }
    }
}
