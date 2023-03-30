using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Dealers;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Dealers.Queries
{
    public class GetByIdDealerQueryRequest : IRequest<GetByIdDealerQueryResponse>
    {
        public  string Id { get; set; }
    }                   
    public class GetByIdDealerQueryResponse
    {
        public DataResult<VM_Dealer> Result { get; set; }
    }
    public class GetByIdDealerQueryHandler : IRequestHandler<GetByIdDealerQueryRequest, GetByIdDealerQueryResponse>
    {
        readonly IDealerReadRepository _dealerReadRepository;

        public GetByIdDealerQueryHandler(IDealerReadRepository dealerReadRepository)
        {
            _dealerReadRepository = dealerReadRepository;
        }

        public async Task<GetByIdDealerQueryResponse> Handle(GetByIdDealerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Dealer dealer = await _dealerReadRepository.GetByIdAsync(request.Id, false);
                VM_Dealer model = new() { Name = dealer.Name, Adress = dealer.Adress, CompanyName = dealer.CompanyName, Description = dealer.Description };

                return new() { Result = new SuccessDataResult<VM_Dealer>(model) };
            }
            catch
            {
                return new() { Result = new ErrorDataResult<VM_Dealer>() };
            }
        }
    }
}
