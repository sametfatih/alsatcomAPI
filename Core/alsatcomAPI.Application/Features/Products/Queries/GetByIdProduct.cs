using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Products.Queries
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdProductQueryResponse
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public float Stock { get; set; }
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public string Description { get; set; }
        public Dealer Dealer { get; set; }
        public ICollection<Order> Orders { get; set; }
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
            Product product = await _productReadRepository.GetByIdAsync(request.Id,false);
            //todo if(!result)
            return new()
            {
                Name = product.Name,
                BrandName = product.BrandName,
                Stock = product.Stock,
                Price = product.Price,
                Description = product.Description,
                DiscountedPrice = product.DiscountedPrice,
                Dealer = product.Dealer,
                Orders = product.Orders
            };

        }
    }
}
