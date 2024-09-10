using AwesomeShop.Services.Application.Dtos.ViewModels;
using MediatR;
using System;

namespace AwesomeShop.Services.Application.Queries
{
    public class GetOrderById : IRequest<OrderViewModel>
    {
        public GetOrderById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
