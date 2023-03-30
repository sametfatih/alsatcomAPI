using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.ErrorResults;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using MediatR;

namespace alsatcomAPI.Application.Features.Products.Commands
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public string Id { get; set; }
    }
    public class DeleteProductCommandResponse
    {
        public Result Result { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _productWriteRepository.RemoveAsync(request.Id);
                await _productWriteRepository.SaveAsync();

                return new() { Result = new SuccessResult() };
            }
            catch
            {
                return new() { Result = new ErrorResult() };
            }
        }
    }
}
