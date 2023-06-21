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
    public class GetAllDealerQueryResponse : DataResult<List<VM_Dealer>>
    {
        public GetAllDealerQueryResponse(List<VM_Dealer> data, bool success) : base(data, success)
        {
        }

        public GetAllDealerQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetAllDealerQueryResponse(List<VM_Dealer> data, bool success, string message) : base(data, success, message)
        {
        }
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
                List<VM_Dealer> dealers = _dealerReadRepository.GetWhere(d => d.Status == true ,false).Select(d => new VM_Dealer
                {
                    Id = d.Id.ToString(),
                    Name = d.Name,
                    Adress = d.Adress,
                    CompanyName = d.CompanyName,
                    Description = d.Description,
                    Rating = d.Rating,
                    Status = d.Status,
                    CreatedDate = d.CreatedDate,
                    UpdatedDate  = d.UpdatedDate,
                }).ToList();

                return new GetAllDealerQueryResponse(dealers, true , "Successful");
            }
            catch
            {
                return new GetAllDealerQueryResponse(false, "Error occured.");
            }
        }
    }
}
