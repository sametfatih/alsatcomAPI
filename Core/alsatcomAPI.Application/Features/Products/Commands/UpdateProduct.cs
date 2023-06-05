using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Products.Commands
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public string Description { get; set; }
    }
    public class UpdateProductCommandResponse : Result
    {
        public UpdateProductCommandResponse(bool success) : base(success)
        {
        }

        public UpdateProductCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = await _productReadRepository.GetByIdAsync(request.Id);
                product.Name = request.Name;
                product.BrandName = request.BrandName;
                product.Description = request.Description;
                product.Stock = request.Stock;
                product.Price = request.Price;
                product.Description = request.Description;
                if (request.DiscountedPrice != 0)
                    product.DiscountedPrice = request.DiscountedPrice;

                await _productWriteRepository.SaveAsync();

                return new UpdateProductCommandResponse(true);
            }
            catch
            {
                return new UpdateProductCommandResponse(false);
            }
        }
    }
}
