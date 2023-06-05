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
    public class GetAllOrderQueryResponse : DataResult<List<VM_Order>>
    {
        public GetAllOrderQueryResponse(List<VM_Order> data, bool success) : base(data, success)
        {
        }

        public GetAllOrderQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetAllOrderQueryResponse(List<VM_Order> data, bool success, string message) : base(data, success, message)
        {
        }
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

                return new GetAllOrderQueryResponse(orders, true,"Successful.");
            }
            catch
            {
                return new GetAllOrderQueryResponse(false, "Error occured.");
            }
        }
    }
}
