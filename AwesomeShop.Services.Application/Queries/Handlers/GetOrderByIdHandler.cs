﻿using AwesomeShop.Services.Application.Dtos.ViewModels;
using AwesomeShop.Services.Core.Repository;
using AwesomeShop.Services.Infrastructure.CacheStorage;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Application.Queries.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderById, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICacheService _cacheService;
        public GetOrderByIdHandler(IOrderRepository orderRepository, ICacheService cacheService)
        {
            _orderRepository = orderRepository;
            _cacheService = cacheService;
        }

        public async Task<OrderViewModel> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var cacheKey = request.Id.ToString();

            var orderViewModel = await _cacheService.GetAsync<OrderViewModel>(cacheKey);

            if (orderViewModel == null) 
            {
                var order = await _orderRepository.GetByIdAsync(request.Id);

                orderViewModel = OrderViewModel.FromEntity(order);

                await _cacheService.SetAsync(cacheKey, orderViewModel);
            }
            

            return orderViewModel;
        }
    }
}
