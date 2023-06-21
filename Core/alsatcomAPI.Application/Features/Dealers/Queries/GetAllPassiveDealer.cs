using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.ViewModels.Dealers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Dealers.Queries
{
    public class GetAllPassiveDealerQueryRequest : IRequest<GetAllPassiveDealerQueryResponse>
    {
    }
    public class GetAllPassiveDealerQueryResponse : DataResult<List<VM_Dealer>>
    {
        public GetAllPassiveDealerQueryResponse(List<VM_Dealer> data, bool success) : base(data, success)
        {
        }

        public GetAllPassiveDealerQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetAllPassiveDealerQueryResponse(List<VM_Dealer> data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class GetAllPassiveDealerQueryHandler : IRequestHandler<GetAllPassiveDealerQueryRequest, GetAllPassiveDealerQueryResponse>
    {
        readonly IDealerReadRepository _dealerReadRepository;

        public GetAllPassiveDealerQueryHandler(IDealerReadRepository dealerReadRepository)
        {
            _dealerReadRepository = dealerReadRepository;
        }

        public async Task<GetAllPassiveDealerQueryResponse> Handle(GetAllPassiveDealerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<VM_Dealer> dealers = _dealerReadRepository.GetWhere(d=>d.Status == false ,false).Select(d => new VM_Dealer
                {
                    Id = d.Id.ToString(),
                    Name = d.Name,
                    Adress = d.Adress,
                    CompanyName = d.CompanyName,
                    Description = d.Description,
                    Rating = d.Rating,
                    Status = d.Status,
                    CreatedDate = d.CreatedDate,
                    UpdatedDate = d.UpdatedDate,
                }).ToList();

                return new GetAllPassiveDealerQueryResponse(dealers, true, "Successful");
            }
            catch
            {
                return new GetAllPassiveDealerQueryResponse(false, "Error occured.");
            }
        }
    }
}
