namespace SimpleCQRS.MessageBus
{
    public interface IHandler<T>
    {
        void Handle(T message);
    }
}
