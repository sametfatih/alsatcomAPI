using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Products.Commands
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string DealerId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
    public class CreateProductCommandResponse
    {
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IDealerReadRepository _dealerReadRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IDealerReadRepository dealerReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _dealerReadRepository = dealerReadRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                Dealer dealer = await _dealerReadRepository.GetByIdAsync(request.DealerId);

                if (dealer != null)
                {
                    Product product = new()
                    {
                        Dealer = dealer,
                        Name = request.Name,
                        BrandName = request.BrandName,
                        Description = request.Description,
                        Stock = request.Stock,
                        Price = request.Price
                    };
                    await _productWriteRepository.AddAsync(product);
                    await _productWriteRepository.SaveAsync();
                }
            }
            return new();
        }
    }
}
