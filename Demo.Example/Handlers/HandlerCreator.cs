using Demo.Example.Handlers;
using Demo.Example.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Demo.Example.Handlers
{
    public class HandlerCreator : IHandlerCreator
    {
        private readonly Dictionary<HandlerType, Func<HandlerOptions, IHandler>> _handlers;

        public HandlerCreator(
            Func<IFirstHandler> firstHandlerCreator,
            Func<ISecondHandler> secondHandlerCreator)
        {
            _handlers = new Dictionary<HandlerType, Func<HandlerOptions, IHandler>>()
            {
                { HandlerType.First, (opt) => firstHandlerCreator() },
                { HandlerType.Second, (opt) => secondHandlerCreator() }
            };
        }

        public bool HasHandler(HandlerType handlerType)
        {
            return _handlers.ContainsKey(handlerType);
        }

        public IHandler CreateHandler(HandlerType handlerType, HandlerOptions options)
        {
            if (!_handlers.ContainsKey(handlerType))
            {
                throw new InvalidEnumArgumentException(nameof(handlerType));
            }
            return _handlers[handlerType](options);
        }
    }
}
