using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCore.DependencyInjection
{
    public interface IEasyBuilder
    {
        IServiceCollection Services { get; }
        IConfiguration Configuration { get; }
    }
}