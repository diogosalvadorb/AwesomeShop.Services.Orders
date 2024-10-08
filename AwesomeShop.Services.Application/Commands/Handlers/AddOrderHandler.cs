﻿using AwesomeShop.Services.Application.Dtos.IntegrationDto;
using AwesomeShop.Services.Core.Repository;
using AwesomeShop.Services.Infrastructure.MessageBus;
using AwesomeShop.Services.Infrastructure.ServiceDiscovery;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Application.Commands.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrder, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBusClient _messageBus;
        private readonly IServiceDiscoveryService _serviceDiscoveryService;
        public AddOrderHandler(IOrderRepository orderRepository, IMessageBusClient messageBus, IServiceDiscoveryService serviceDiscoveryService)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
            _serviceDiscoveryService = serviceDiscoveryService;
        }

        public async Task<Guid> Handle(AddOrder request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();

            var customerUrl = await _serviceDiscoveryService
                .GetServiceUri("CustomerServices", $"api/customers/{order.Customer.Id}");

            var httpClient = new HttpClient();

            var result = await httpClient.GetAsync(customerUrl);
            var stringResult = await result.Content.ReadAsStringAsync();

            var customerDto = JsonConvert.DeserializeObject<GetCustomerByIdDto>(stringResult);

            Console.WriteLine(customerDto.FullName);

            await _orderRepository.AddAsync(order);

            foreach (var @event in order.Events)
            {
                // OrderCreated = order-created
                var routingKey = @event.GetType().Name.ToDashCase();

                _messageBus.Publish(@event, routingKey, "order-service");
            }

            return order.Id;
        }
    }
}
