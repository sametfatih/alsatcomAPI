using alsatcomAPI.Application.Repositories;
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
            await _dealerWriteRepository.RemoveAsync(request.Id);
            await _dealerWriteRepository.SaveAsync();

            return new();
        }
    }
}
