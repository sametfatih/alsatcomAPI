using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Orders.Commands
{
    public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
    {
        public string Id { get; set; }
    }
    public class DeleteOrderCommandResponse : Result
    {
        public DeleteOrderCommandResponse(bool success) : base(success)
        {
        }

        public DeleteOrderCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;

        public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _orderWriteRepository.RemoveAsync(request.Id);
                await _orderWriteRepository.SaveAsync();

                return new DeleteOrderCommandResponse(true);
            }
            catch
            {
                return new DeleteOrderCommandResponse(false);
            }
        }
    }
}
