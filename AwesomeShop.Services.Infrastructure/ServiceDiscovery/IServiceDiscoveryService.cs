using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Infrastructure.ServiceDiscovery
{
    public interface IServiceDiscoveryService
    {
        Task<Uri> GetServiceUri(string serviceName, string requestUrl);
    }
}
