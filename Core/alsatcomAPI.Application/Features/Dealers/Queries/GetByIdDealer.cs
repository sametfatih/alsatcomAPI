using alsatcomAPI.Application.Repositories;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
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
            Dealer dealer = await _dealerReadRepository.GetByIdAsync(request.Id, false);
            //todo if(!result)
            return new() { Name = dealer.Name, Adress = dealer.Adress, CompanyName = dealer.CompanyName, Description = dealer.Description };
           
        }
    }
}
