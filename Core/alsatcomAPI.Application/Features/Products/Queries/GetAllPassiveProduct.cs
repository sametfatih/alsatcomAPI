using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.ViewModels.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Products.Queries
{
    public class GetAllPassiveProductQueryRequest : IRequest<GetAllPassiveProductQueryResponse>
    {
    }
    public class GetAllPassiveProductQueryResponse : DataResult<List<VM_Product>>
    {
        public GetAllPassiveProductQueryResponse(List<VM_Product> data, bool success) : base(data, success)
        {
        }

        public GetAllPassiveProductQueryResponse(bool success, string message) : base(success, message)
        {
        }

        public GetAllPassiveProductQueryResponse(List<VM_Product> data, bool success, string message) : base(data, success, message)
        {
        }
    }
    public class GetAllPassiveProductQueryHandler : IRequestHandler<GetAllPassiveProductQueryRequest, GetAllPassiveProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllPassiveProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllPassiveProductQueryResponse> Handle(GetAllPassiveProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<VM_Product> products = _productReadRepository.GetWhere(p => p.Status == false, false).Select(p => new VM_Product
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

                return new GetAllPassiveProductQueryResponse(products, true, "Successful.");
            }
            catch
            {
                return new GetAllPassiveProductQueryResponse(false, "Error occured.");
            }
        }
    }
}
