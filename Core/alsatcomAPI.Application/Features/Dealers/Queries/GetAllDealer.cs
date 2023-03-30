using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Dealers;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Dealers.Queries
{
    public class GetAllDealerQueryRequest : IRequest<GetAllDealerQueryResponse>
    {
    }
    public class GetAllDealerQueryResponse
    {
        public DataResult<List<VM_Dealer>> Result { get; set; }
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
            try
            {
                List<VM_Dealer> dealers = _dealerReadRepository.GetAll(false).Select(d => new VM_Dealer
                {
                    Name = d.Name,
                    Adress = d.Adress,
                    CompanyName = d.CompanyName,
                    Description = d.Description
                }).ToList();

                return new() { Result = new SuccessDataResult<List<VM_Dealer>>(dealers) };
            }
            catch
            {
                return new() { Result = new ErrorDataResult<List<VM_Dealer>>() };
            }
        }
    }
}
