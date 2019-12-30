using EasyCore.EventBus.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyCore.EventBus.Abstractions
{
    public interface IIntegrationEventLogService
    {
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(string module);
        Task SaveEventAsync(IntegrationEvent @event, object transaction);
        Task MarkEventAsPublishedAsync(long eventId);
        Task MarkEventAsInProgressAsync(long eventId);
        Task MarkEventAsFailedAsync(long eventId);
    }
}