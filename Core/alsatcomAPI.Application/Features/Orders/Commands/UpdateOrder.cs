using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Orders.Commands
{
    public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
    {
        public string Id { get; set; }
        public string Adress { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
    public class UpdateOrderCommandResponse
    {
        public Result Result { get; set; }
    }
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;

        public UpdateOrderCommandHandler(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _orderReadRepository.GetByIdAsync(request.Id);
                order.Adress = request.Adress;
                if (request.Products != null)
                    order.Products = request.Products;

                await _orderWriteRepository.SaveAsync();

                return new() { Result = new SuccessResult() };
            }
            catch
            {
                return new() { Result = new ErrorResult() };
            }
        }
    }
}
