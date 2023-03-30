using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Dealers.Commands
{
    public class CreateDealerCommandRequest : IRequest<CreateDealerCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string CompanyName { get; set; }
    }
    public class CreateDealerCommandResponse
    {
    }
    public class CreateDealerCommandHandler : IRequestHandler<CreateDealerCommandRequest, CreateDealerCommandResponse>
    {
        readonly IDealerWriteRepository _dealerWriteRepository;

        public CreateDealerCommandHandler(IDealerWriteRepository dealerWriteRepository)
        {
            _dealerWriteRepository = dealerWriteRepository;
        }

        public async Task<CreateDealerCommandResponse> Handle(CreateDealerCommandRequest request, CancellationToken cancellationToken)
        {
            Dealer dealer = new() { Name = request.Name, Description = request.Description, Adress = request.Adress, CompanyName = request.CompanyName };
            await _dealerWriteRepository.AddAsync(dealer);
            await _dealerWriteRepository.SaveAsync();

            return new();
        }
    }
}
