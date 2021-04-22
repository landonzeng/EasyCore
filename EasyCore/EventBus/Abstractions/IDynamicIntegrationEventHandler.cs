using System.Threading.Tasks;

namespace EasyCore.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task<bool> Handle(string eventData);
    }
}