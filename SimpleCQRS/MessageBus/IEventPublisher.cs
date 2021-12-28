using SimpleCQRS.Domain;

namespace SimpleCQRS.MessageBus
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}
