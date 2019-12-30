using System.Threading.Tasks;

namespace EasyCore.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(string eventData);
    }
}
