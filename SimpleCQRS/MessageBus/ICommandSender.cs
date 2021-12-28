using SimpleCQRS.Commands;

namespace SimpleCQRS.MessageBus
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;

    }
}
