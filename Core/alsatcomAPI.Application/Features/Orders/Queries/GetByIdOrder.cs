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
    public class GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdOrderQueryResponse : DataResult<VM_Order>
    {
        public GetByIdOrderQueryResponse(VM_Order data, bool success) : base(data, success)
        {
        }

        public GetByIdOrderQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetByIdOrderQueryResponse(VM_Order data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IProductReadRepository _productReadRepository;

        public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository, IProductReadRepository productReadRepository)
        {
            _orderReadRepository = orderReadRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //Order order = await _orderReadRepository.GetByIdWithInclude(request.Id,false);
                //todo if(!result)
                Order order = await _orderReadRepository.GetByIdAsync(request.Id);
                VM_Order model = new() { CustomerId = order.CustomerId.ToString(), Adress = order.Adress };

                return new GetByIdOrderQueryResponse(model, true, "Succesfull.");
            }
            catch
            {
                return new GetByIdOrderQueryResponse(false, "Error occured.");
            }

        }
    }
}
