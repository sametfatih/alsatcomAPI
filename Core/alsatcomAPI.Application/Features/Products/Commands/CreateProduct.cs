using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Domain.Entities;
using MediatR;

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
    public class CreateProductCommandResponse : Result
    {
        public CreateProductCommandResponse(bool success) : base(success)
        {
        }

        public CreateProductCommandResponse(bool success, string message) : base(success, message)
        {
        }
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
            try
            {
                Dealer dealer = await _dealerReadRepository.GetByIdAsync(request.DealerId);

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

                return new CreateProductCommandResponse(true);
            }
            catch
            {
                return new CreateProductCommandResponse(false);
            }
        }
    }
}
