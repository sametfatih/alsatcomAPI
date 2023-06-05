using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Products;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Products.Queries
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdProductQueryResponse : DataResult<VM_Product>
    {
        public GetByIdProductQueryResponse(VM_Product data, bool success) : base(data, success)
        {
        }

        public GetByIdProductQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetByIdProductQueryResponse(VM_Product data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = await _productReadRepository.GetByIdAsync(request.Id, false);
                VM_Product model = new()
                {
                    Name = product.Name,
                    BrandName = product.BrandName,
                    Stock = product.Stock,
                    Price = product.Price,
                    Description = product.Description,
                    DiscountedPrice = product.DiscountedPrice,
                };
                //todo if(!result)
                return new GetByIdProductQueryResponse(model, true, "Successful.");
            }
            catch
            {
                return new GetByIdProductQueryResponse(false, "Error occured.");
            }
        }
    }
}
