using AwesomeShop.Services.Application.Dtos.ViewModels;
using AwesomeShop.Services.Core.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Application.Queries.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderById, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderViewModel> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            var orderViewModel = OrderViewModel.FromEntity(order);

            return orderViewModel;
        }
    }
}
