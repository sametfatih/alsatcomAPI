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

namespace alsatcomAPI.Application.Features.Dealers.Commands
{
    public class DeleteDealerCommandRequest : IRequest<DeleteDealerCommandResponse>
    {
        public string Id { get; set; }
    }
    public class DeleteDealerCommandResponse
    {
        public Result Result { get; set; }
    }
    public class DeleteDealerCommandHandler : IRequestHandler<DeleteDealerCommandRequest, DeleteDealerCommandResponse>
    {
        readonly IDealerWriteRepository _dealerWriteRepository;

        public DeleteDealerCommandHandler(IDealerWriteRepository dealerWriteRepository)
        {
            _dealerWriteRepository = dealerWriteRepository;
        }

        public async Task<DeleteDealerCommandResponse> Handle(DeleteDealerCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _dealerWriteRepository.RemoveAsync(request.Id);
                await _dealerWriteRepository.SaveAsync();

                return new() { Result = new SuccessResult()};
            }
            catch
            {
                return new() { Result = new ErrorResult() };
            }
        }
    }
}
