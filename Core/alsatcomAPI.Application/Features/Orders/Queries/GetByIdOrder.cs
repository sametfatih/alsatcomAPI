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
    public class GetByIdOrderQueryResponse
    {
        public DataResult<VM_Order> Result { get; set; }
        //public List<Product> Products { get; set; }
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

                return new() { Result = new SuccessDataResult<VM_Order>(model) };
            }
            catch
            {
                return new() { Result = new ErrorDataResult<VM_Order>() };
            }

        }
    }
}
