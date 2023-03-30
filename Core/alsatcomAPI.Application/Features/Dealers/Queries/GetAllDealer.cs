using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Dealers.Queries
{
    public class GetAllDealerQueryRequest : IRequest<GetAllDealerQueryResponse>
    {
    }
    public class GetAllDealerQueryResponse
    {
        public List<Dealer> Dealers { get; set; }
    }
    public class GetAllDealerQueryHandler : IRequestHandler<GetAllDealerQueryRequest, GetAllDealerQueryResponse>
    {
        readonly IDealerReadRepository _dealerReadRepository;

        public GetAllDealerQueryHandler(IDealerReadRepository dealerReadRepository)
        {
            _dealerReadRepository = dealerReadRepository;
        }

        public async Task<GetAllDealerQueryResponse> Handle(GetAllDealerQueryRequest request, CancellationToken cancellationToken)
        {
            List<Dealer> dealers = _dealerReadRepository.GetAll(false).ToList();

            return new() { Dealers = dealers };
        }
    }
}
