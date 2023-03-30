using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Application.ViewModels.Products;
using MediatR;

namespace alsatcomAPI.Application.Features.Products.Queries
{
    public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
    }
    public class GetAllProductQueryResponse
    {
        public DataResult<List<VM_Product>> Result { get; set; }
    }
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<VM_Product> products = _productReadRepository.GetAll(false).Select(p => new VM_Product
                {
                    Name = p.Name,
                    BrandName = p.BrandName,
                    Description = p.Description,
                    DiscountedPrice = p.DiscountedPrice,
                    Price = p.Price,
                    Stock = p.Stock
                }).ToList();

                return new() { Result = new SuccessDataResult<List<VM_Product>>(products) };
            }
            catch
            {
                return new() { Result = new ErrorDataResult<List<VM_Product>>() };
            }
        }
    }
}
