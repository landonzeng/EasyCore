using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCore.EventBus.Abstractions
{
    public interface IEventBusBuilder
    {
        IServiceCollection Services { get; }
        IConfiguration Configuration { get; }
    }
}
