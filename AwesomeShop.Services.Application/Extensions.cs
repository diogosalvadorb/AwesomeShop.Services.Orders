using AwesomeShop.Services.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Services.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddOrder));

            return services;
        }
    }
}
