using Demo.Example.Handlers;
using Demo.Example.Model;

namespace Demo.Example.Handlers
{
    public interface IHandlerCreator
    {
        bool HasHandler(HandlerType handlerType);

        IHandler CreateHandler(HandlerType handlerType, HandlerOptions options);
    }
}
