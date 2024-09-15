using AwesomeShop.Services.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System;

namespace AwesomeShop.Services.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddOrder));

            return services;
        }

        public static string ToDashCase(this string text)
        {
            // OrderCreated = order-created
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (text.Length < 2)
            {
                return text;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(text[0]));
            for (int i = 1; i < text.Length; ++i)
            {
                char c = text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('-');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }

            Console.WriteLine($"ToDashCase: " + sb.ToString());

            return sb.ToString();
        }
    }
}
