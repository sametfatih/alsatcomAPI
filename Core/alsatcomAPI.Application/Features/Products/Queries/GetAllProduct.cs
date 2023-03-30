using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Domain.Entities;
using MediatR;

namespace alsatcomAPI.Application.Features.Products.Queries
{
    public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
    }
    public class GetAllProductQueryResponse
    {
        public List<Product> Products { get; set; }
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
            List<Product> products = _productReadRepository.GetAll(false).ToList();

            return new() { Products = products };
        }
    }
}
