using alsatcomAPI.Application.Features.Dealers.Commands;
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

namespace alsatcomAPI.Application.Features.Dealers.Commands
{
    public class UpdateDealerCommandRequest : IRequest<UpdateDealerCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
    }
    public class UpdateDealerCommandResponse 
    {
        public Result Result { get; set; }
    }
    public class UpdateDealerCommandHandler : IRequestHandler<UpdateDealerCommandRequest, UpdateDealerCommandResponse>
    {
        readonly IDealerReadRepository _dealerReadRepository;
        readonly IDealerWriteRepository _dealerWriteRepository;

        public UpdateDealerCommandHandler(IDealerReadRepository dealerReadRepository, IDealerWriteRepository dealerWriteRepository)
        {
            _dealerReadRepository = dealerReadRepository;
            _dealerWriteRepository = dealerWriteRepository;
        }

        public async Task<UpdateDealerCommandResponse> Handle(UpdateDealerCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {

                Dealer dealer = await _dealerReadRepository.GetByIdAsync(request.Id);
                dealer.Name = request.Name;
                dealer.Description = request.Description;
                dealer.Adress = request.Adress;
                dealer.CompanyName = request.CompanyName;

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
