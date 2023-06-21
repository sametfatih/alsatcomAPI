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
    public class GetAllProductQueryResponse : DataResult<List<VM_Product>>
    {
        public GetAllProductQueryResponse(List<VM_Product> data, bool success) : base(data, success)
        {
        }

        public GetAllProductQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetAllProductQueryResponse(List<VM_Product> data, bool success, string message) : base(data, success, message)
        {
        }
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
                List<VM_Product> products = _productReadRepository.GetWhere(p => p.Status == true,false).Select(p => new VM_Product
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    BrandName = p.BrandName,
                    Description = p.Description,
                    DiscountedPrice = p.DiscountedPrice,
                    Price = p.Price,
                    Stock = p.Stock,
                    CreatedDate = p.CreatedDate,
                    Status = p.Status,
                    UpdatedDate = p.UpdatedDate
                }).ToList();

                return new GetAllProductQueryResponse(products, true, "Successful.");
            }
            catch
            {
                return new GetAllProductQueryResponse(false, "Error occured.");
            }
        }
    }
}
